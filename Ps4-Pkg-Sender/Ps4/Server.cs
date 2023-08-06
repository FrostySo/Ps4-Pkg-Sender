using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Ps4_Pkg_Sender.Exceptions;
using Ps4_Pkg_Sender.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Ps4_Pkg_Sender.Ps4 {
    public class Server {

        private static Random random = new Random();

        int currentProcessPid;

        public string PS4IP { get; set; }
        public string ServerIp { get; set; }
        public static int ServerPort { get; set; } = 8080;

        public bool IsRunning { get; internal set; }

        private bool _portInUse;

        const string NodeJsHttpServerScript = "const {{ exec }} = require('child_process'); console.log('PID:', process.pid); const httpServerProcess = exec('http-server \\\"{0}\\\" -p {1}',); httpServerProcess.stdout.pipe(process.stdout); httpServerProcess.stderr.pipe(process.stderr);";

        const string NodeJsPidPattern = @"PID: (\d+)";

        private HashSet<int> AlreadyRunningNodeProcesses = new HashSet<int>();

        Process cmdProcess;

        private bool IsPortOpen(int port) {
            IPGlobalProperties ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
            TcpConnectionInformation[] tcpConnInfoArray = ipGlobalProperties.GetActiveTcpConnections();
            foreach (TcpConnectionInformation tcpi in tcpConnInfoArray) {
                if (tcpi.LocalEndPoint.Port == port) {
                    return false;
                }
            }
            return true;
        }

        private int GetRandomPort() {
            return random.Next(29170, 29998);
        }

        private int GetNextBestPort() {
            if (!IsPortOpen(ServerPort)) {
                ServerPort = GetRandomPort();
            }
            return ServerPort;
        }

        public bool StartServer(PkgInfo info) {
            AlreadyRunningNodeProcesses.Clear();
            Logger.WriteLine("::StartServer - Starting server in directory " + Path.GetDirectoryName(info.FilePath), Logger.Type.StandardOutput);
            cmdProcess = new Process();
            foreach (var proc in NodeJSUtil.GetNodeProcesses()) {
                AlreadyRunningNodeProcesses.Add(proc.Id);
            }
            var directoryPath = Path.GetDirectoryName(info.FilePath);
            _portInUse = false;
            cmdProcess.StartInfo = new ProcessStartInfo() {
                FileName = "cmd.exe",
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                Arguments = $"/C http-server \"{directoryPath}\" -p {GetNextBestPort()}"
            };

            if (Directory.GetLogicalDrives().Contains(directoryPath)) {
                cmdProcess.StartInfo.Arguments = cmdProcess.StartInfo.Arguments.Replace(@"\", @"\\");
            }

            cmdProcess.Start();
            cmdProcess.BeginOutputReadLine();
            cmdProcess.BeginErrorReadLine();
            cmdProcess.ErrorDataReceived += Cmd_ErrorDataReceived;
            cmdProcess.OutputDataReceived += Cmd_OutputDataReceived;
            cmdProcess.Exited += Cmd_Exited;
            cmdProcess.EnableRaisingEvents = true;
            //Assumption will be that it should always be found
            currentProcessPid = 0;

            while (cmdProcess.Handle == IntPtr.Zero) {
                System.Threading.Thread.Sleep(100);
            }

            while (!cmdProcess.HasExited) {
                if (IsRunning) {
                    var nodeProcesses = NodeJSUtil.GetNodeProcesses().ToList();
                    currentProcessPid = nodeProcesses.Find(proc => !AlreadyRunningNodeProcesses.Contains(proc.Id)).Id;
                    return true;
                }

                if (_portInUse) {
                    KillCmdProcess();
                    throw new ServerInitializationException("Address already in use");
                }
                Thread.Sleep(50);
            }

            return false;
        }

        private void Cmd_OutputDataReceived(object sender, DataReceivedEventArgs e) {
            if (e.Data == null) return;
            Logger.WriteLine($"Cmd::Out -> {e.Data}", Logger.Type.StandardOutput);
            if (e.Data.ToLower().Contains("starting up http-server, serving")) {
                IsRunning = true;
            }
        }

        private void Cmd_ErrorDataReceived(object sender, DataReceivedEventArgs e) {
            if (e.Data == null) return;
            Logger.WriteLine($"Cmd::Err -> {e.Data}", Logger.Type.StandardOutput);

            if (e.Data.Contains("EADDRINUSE")) {
                IsRunning = false;
                _portInUse = true;
            }
        }

        private void Cmd_Exited(object sender, EventArgs e) {
            IsRunning = false;
            var process = sender as Process;
            if (process != null) {
                Logger.WriteLine($"Cmd::Exited:Out", Logger.Type.StandardOutput);
            }
        }

        private void KillProcess(int pid) {
            try {
                ProcessUtil.KillProcessAndChildren(pid);
            } catch {

            }
        }

        private void KillCmdProcess() {
            if(cmdProcess != null && !cmdProcess.HasExited) {
                try {
                    cmdProcess.Kill();
                } catch {

                }
            }
        }

        public void RestartServer(PkgInfo info) {
            Logger.WriteLine("Restarting Server", Logger.Type.DebugOutput);
            var wasRunning = IsRunning;
            StopServer();
            if (wasRunning) {
                Thread.Sleep(2000);
            }
            StartServer(info);
        }

        public void StopServer() {
            KillCmdProcess();
            Logger.WriteLine("Killed Old Server Process", Logger.Type.DebugOutput);
            KillProcess(currentProcessPid);
            IsRunning = false;
        }

        public DataTrasmittedProgress GetInstallProgress(long taskID) {
            if (taskID == 0) return null;
            var response = HttpUtil.Post($"http://{PS4IP}:12800/api/get_task_progress", $"{{\"task_id\":{taskID}}}");
            Logger.WriteLine("::GetInstallProgress - " + response, Logger.Type.StandardOutput);
            var progress = JsonConvert.DeserializeObject<Json.Ps4Progress>(response);
            return new DataTrasmittedProgress(progress.LengthTotal, progress.TransferredTotal, progress.RestSecTotal);
        }


        private int RecoverTaskID(PkgInfo pkgInfo) {
            var url = $"http://{PS4IP}:12800/api/find_task";
            var json = $"{{\"content_id\":\"{pkgInfo.ContentID}\", \"sub_type\":{(int)pkgInfo.Type}}}";
            var response = HttpUtil.Post(url, json);
            Logger.WriteLine("::RecoverTaskID - " + response, Logger.Type.StandardOutput);
            if (response.Contains("task_id")) {
                return int.Parse(JToken.Parse(response)["task_id"].ToString());
            }
            if (response.Contains("error_code")) {
                throw new RPIErrorThrownException(long.Parse(JToken.Parse(response)["error_code"].ToString()));
            }
            return -1;
        }

        public bool TryRecoverTaskID(PkgInfo pkgInfo, out long id) {
            id = -1;
            id = RecoverTaskID(pkgInfo);
            if (id != -1) {
                return true;
            }
            //Because it checks the title id instead of content id
            //this will return true if the game is installed
            //there is no way of knowing the patch is installed accurately
            //So we just return false and assume it's not.
            if (pkgInfo.Type == Enums.PkgType.Patch || pkgInfo.Type == Enums.PkgType.Additional_Content) {
                return false;
            }
            var url = $"http://{PS4IP}:12800/api/is_exists";
            var json = $"{{\"title_id\":\"{pkgInfo.TitleID}\"}}";
            var response = HttpUtil.Post(url, json);
            if (response.Contains("task_id")) {
                id = int.Parse(JToken.Parse(response)["task_id"].ToString());
                return true;
            }
            Logger.WriteLine("::GetTaskID.AppExists - " + response, Logger.Type.StandardOutput);

            //App is already installed, usually a task ID comes with it but I'm not certain 
            //If this happens with DLC/Themes
            //Better safe than sorry
            return response.Contains("\"exists\": \"true\"");
        }

        public bool InitiateInstall(PkgInfo pkgInfo, bool skipInstallCheck, out long id) {
            id = 0;
            if (!skipInstallCheck && TryRecoverTaskID(pkgInfo, out id)) {
                if (id == -1) { //App is already installed and no id was returned
                    id = 0xAFFFFFF; //The flag we will use to determine if it is installed
                }
                return true;
            }
            var response = HttpUtil.Post($"http://{PS4IP}:12800/api/install",
            HttpUtil.GetInstallJson(pkgInfo.GetFilePaths(), ServerIp, ServerPort));
            //{ "status": "fail", "error_code": 0x80990004 }
            if (response.Contains("task_id")) {
                id = long.Parse(JToken.Parse(response)["task_id"].ToString());
                return true;
            }
            if (response.Contains("{ \"status\": \"fail\"")) {
                throw new RPIErrorThrownException(long.Parse(JToken.Parse(response)["error_code"].ToString()));
            }
            return false;
        }

        public bool Uninstall(PkgInfo pkgInfo) {
            var url = $"http://{PS4IP}:12800/api/uninstall_";
            var json = "";
            switch (pkgInfo.Type) {
                case Enums.PkgType.Game:
                    url += "game";
                    json = $"{{\"title_id\":\"{pkgInfo.TitleID}\"}}";
                    break;

                case Enums.PkgType.Patch:
                    json = $"{{\"title_id\":\"{pkgInfo.TitleID}\"}}";
                    url += "patch";
                    break;

                case Enums.PkgType.Additional_Content:
                    url += "ac";
                    json = $"{{\"content_id\":\"{pkgInfo.ContentID}\"}}";
                    break;

                case Enums.PkgType.Addon_Theme:
                    url += "theme";
                    json = $"{{\"content_id\":\"{pkgInfo.ContentID}\"}}";
                    break;
            }

            var response = HttpUtil.Post(url, json);
            if (response.Contains("success")) {
                return true;
            }
            return false;
        }
    }
}
