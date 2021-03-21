using Ps4_Pkg_Sender.Exceptions;
using Ps4_Pkg_Sender.Extensions;
using Ps4_Pkg_Sender.Properties;
using Ps4_Pkg_Sender.Services;
using Ps4_Pkg_Sender.Utilities;
using System.Diagnostics;
using System.Net;
using System.Windows.Forms;
using static Ps4_Pkg_Sender.Exceptions.RPIErrorThrownException;
using static Ps4_Pkg_Sender.MainForm;

namespace Ps4_Pkg_Sender.Ps4 {
    public class PkgTransfer {

        System.ComponentModel.BackgroundWorker bgWorker;

        long taskId = 0;
        bool checkedFirstProgress = false;
        bool skipInstallCheck = false;
        Stopwatch stopwatch;
        QueueItem queueItem;
        FileRenameService fileRenameService;
        Server server;

        public PkgTransfer(QueueItem queueItem, System.ComponentModel.BackgroundWorker bgWorker, FileRenameService fileRenameService, Server server) {
            this.bgWorker = bgWorker;
            this.queueItem = queueItem;
            this.fileRenameService = fileRenameService;
            this.server = server;
            stopwatch = new Stopwatch();
            stopwatch.Start();
        }

        const long TaskFinishedSC = 0xAFFFFFF;

        public PkgTransferProgress Transfer() {
            var pkgTransferProgress = new PkgTransferProgress();
            try {

                switch (queueItem.TaskType) {
                    case Enums.TaskType.Uninstalling:
                    if (server.Uninstall(queueItem.PkgInfo)) {
                        pkgTransferProgress.TransferStatus = Enums.TransferStatus.Completed;
                        taskId = 0;
                    }
                    break;

                    case Enums.TaskType.Queued:
                    pkgTransferProgress.TransferStatus = Enums.TransferStatus.RequestingPkgSend;
                    if (queueItem.Uninstall) {
                        queueItem.UpdateTask(Enums.TaskType.Uninstalling);
                    } else {
                        queueItem.UpdateTask(Enums.TaskType.Sending);
                    }
                    break;

                    case Enums.TaskType.Sending:
                    pkgTransferProgress.TransferStatus = Enums.TransferStatus.InProgress;

                    if (taskId == 0) {
                        try {
                            if (server.InitiateInstall(queueItem.PkgInfo, skipInstallCheck, out taskId)) {
                                if (taskId == TaskFinishedSC) { //no task id provided but already installed
                                    pkgTransferProgress.TransferStatus = Enums.TransferStatus.Completed;
                                }
                            }
                        } catch (RPIErrorThrownException ex) {
                            bool doDefault = false;
                            switch (ex.StatusCode) {
                                case Ps4ErrorCode.SCE_BGFT_ERROR_TASK_NOENT:

                                //The API is so fked up that it returns random shit
                                //This here will handle this weird use case
                                //Most apps should install with this here.
                                if (!skipInstallCheck) {
                                    taskId = 0;
                                    skipInstallCheck = true;
                                } else {
                                    pkgTransferProgress.TransferStatus = Enums.TransferStatus.Completed;
                                    taskId = -1;
                                }
                                break;

                                case Ps4ErrorCode.SCE_KERNEL_ERROR_EINVAL:
                                if (skipInstallCheck) {
                                    doDefault = true;
                                } else {
                                    taskId = 0;
                                    skipInstallCheck = true;
                                }
                                break;

                                default:
                                doDefault = true;
                                break;
                            }

                            if (doDefault) {
                                throw new SkipItemException(Enums.TaskType.Failed, $"Could not install. Error: 0x{ex.ErrorCode.ToString("X")} ({ex.Message})");
                            }
                        }

                    }
                    break;
                }

                switch (pkgTransferProgress.TransferStatus) {
                    case Enums.TransferStatus.InProgress:
                    long checkDelayMillis = MainForm.Settings.ProgressCheckDelay.ToMilliseconds();
                    long timeLeft = (checkDelayMillis - stopwatch.ElapsedMilliseconds) / 1000;
                    pkgTransferProgress.TimeLeft = timeLeft;
                    if (stopwatch.ElapsedMilliseconds >= checkDelayMillis || !checkedFirstProgress) {
                        var progress = server.GetInstallProgress(taskId);
                        if (progress != null) {
                            var total = progress.GetPercentageComplete();
                            if (total > 0) {
                                checkedFirstProgress = true;
                            }
                            bgWorker.ReportProgress(total, progress);
                            if (total >= 100 || progress.ExceedsTotalLength()) {
                                pkgTransferProgress.TransferStatus = Enums.TransferStatus.Completed;
                                return pkgTransferProgress;
                            }
                            pkgTransferProgress.DataTrasmittedProgress = progress;
                            stopwatch.Restart();
                        }
                    }

                    //if (taskId != TaskFinishedSC) {
                    //    pkgTransferProgress.DataTrasmittedProgress = server.GetInstallProgress(taskId);
                    //}

                    break;
                }

            } catch (WebException ex) { //Best not to ask why I did it like this
                if (ex.Status == WebExceptionStatus.ProtocolError) {
                    var resp = ((HttpWebResponse)ex.Response);
                    if (resp.StatusCode == HttpStatusCode.RequestTimeout) {
                        throw new SkipItemException(Enums.TaskType.Timed_Out, "Operation timed out");
                    } else if (resp.StatusCode == HttpStatusCode.InternalServerError) {
                        Logger.WriteLine("::status error - " + ex.Message, Logger.Type.StandardOutput);
                        throw new SkipItemException(Enums.TaskType.Failed, "Something is wrong with the server. It returned HTTP 500");
                    }
                } else if (ex.Status == WebExceptionStatus.ConnectionClosed) {
                    throw new SkipItemException(Enums.TaskType.Failed, "Remote PKG Installer has crashed. Please restart it on your PS4");
                } else if (ex.Status == WebExceptionStatus.ConnectFailure) {
                    throw new SkipItemException(Enums.TaskType.Failed, "Couldn't Connect to RPI. Check your firewall settings or ensure that the application is running.");
                }
            }

            return pkgTransferProgress;
        }
    }
}
