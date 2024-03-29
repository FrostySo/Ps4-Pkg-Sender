﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Ps4_Pkg_Sender.Controls.Sorting;
using Ps4_Pkg_Sender.Enums;
using Ps4_Pkg_Sender.Exceptions;
using Ps4_Pkg_Sender.Extensions;
using Ps4_Pkg_Sender.Models;
using Ps4_Pkg_Sender.Ps4;
using Ps4_Pkg_Sender.Services;
using Ps4_Pkg_Sender.UI;
using Ps4_Pkg_Sender.Utilities;
using Ps4_Pkg_Sender.WinApi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Ps4_Pkg_Sender {
    public partial class MainForm : Form {

        bool connected = false;

        bool processing = false;

        IntPtr listViewHwnd = IntPtr.Zero;
        List<QueueItem> ps4PkgList = new List<QueueItem>();

        ListViewColumnSorter listViewColumnSorter;

        public static Json.AppSettings Settings = new Json.AppSettings();

        BackgroundWorker queueBackgroundWorker;

        FileRenameService fileRenameService = new FileRenameService();

        HashSet<int> QueueItemToIgnoreSet = new HashSet<int>();

 

        static Server server;

      

        private Server GetServerDetails() {
            server = new Server();
            server.PS4IP = textBoxPS4IP.Text;
            server.ServerIp = comboBoxServerIP.SelectedItem.ToString();
            return server;
        }

        private string GetFileVersion() {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fileVersionInfo = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
            return fileVersionInfo.FileVersion.Substring(0,fileVersionInfo.FileVersion.LastIndexOf('.'));
        }

        public MainForm() {
            InitializeComponent();
            this.Text = $"Ps4 Pkg Sender v{GetFileVersion()}";
            Themer.LoadTheme();
            Themer.ApplyTheme(this);
            listViewColumnSorter = new ListViewColumnSorter();
            listViewItemsQueue.ListViewItemSorter = listViewColumnSorter;
            queueBackgroundWorker = new BackgroundWorker();
            queueBackgroundWorker.WorkerReportsProgress = true;
            queueBackgroundWorker.WorkerSupportsCancellation = true;
            queueBackgroundWorker.DoWork += queueWorker_DoWork;
            queueBackgroundWorker.ProgressChanged += queueWorker_ProgressChanged;
            fileRenameService = new FileRenameService();
            fileRenameService.StartService();
        }

        public void SaveSettings() {
            var settings = new Json.AppSettings();
            settings.Ps4IP = textBoxPS4IP.Text;
            settings.ServerIP = comboBoxServerIP.SelectedItem.ToString();
            settings.RecursiveSearch = checkBoxRecursive.Checked;
            settings.ProgressCheckDelay = Settings.ProgressCheckDelay;
            settings.SkipInstallCheck = checkBoxSkipInstallCheck.Checked;
            settings.SoundSettings = Settings.SoundSettings;
            File.WriteAllText("settings.json", JsonConvert.SerializeObject(settings, Formatting.Indented));
            labelCheckDelay.Text = $"Check Delay:  {settings.ProgressCheckDelay}s";
            Settings = settings;
        }

        private void LoadSettings() {
            if (!File.Exists("settings.json")) {
                SaveSettings();
            }
            Settings = JsonConvert.DeserializeObject<Json.AppSettings>(File.ReadAllText("settings.json"));
            int serverIPIndex = this.comboBoxServerIP.FindStringExact(Settings.ServerIP);
            if (serverIPIndex != -1) {
                this.comboBoxServerIP.SelectedIndex = serverIPIndex;
            }
            this.textBoxPS4IP.Text = Settings.Ps4IP;
            checkBoxRecursive.Checked = Settings.RecursiveSearch;
            checkBoxSkipInstallCheck.Checked = Settings.SkipInstallCheck;
        }

        private void CheckPreRequesites() {

            if (!NodeJSUtil.IsNodeJsInstalled()) {
                MessageBox.Show("Node JS is not installed, please install it.\nExiting...", "Node JS Not Found");
                Environment.Exit(1);
            }

            if (!NodeJSUtil.IsHttpServerInstalled()) {
                var dr = 
                    MessageBox.
                    Show("Node JS http-server is not installed, would you like to install it?", 
                    "Install http-server?",
                    MessageBoxButtons.YesNo);
                if(dr == DialogResult.Yes) {
                    System.Threading.Tasks.Task.Run(() =>
                        this.InvokeIfRequired(() =>
                        MessageBox.Show("Installing Http-server... Please wait for the popup", "Installing")
                    ));
                    if (NodeJSUtil.InstallHttpServer()) {
                        MessageBox.Show("Successfully installed!", "Success");
                    } else {
                        MessageBox.Show("Failed To Install... Please run \"npm install http-server\" in cmd (without the quotes)\nExiting...", "Failed");
                        Environment.Exit(1);
                    }
                } else {

                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e) {
            CheckPreRequesites();
            this.listViewHwnd = listViewItemsQueue.Handle;
            PopulateValidIPs();
            this.listViewItemsQueue.Columns[listViewItemsQueue.Columns.Count - 1].Width = 254;
            this.listViewItemsQueue
                .GetType()
                .GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                .SetValue(listViewItemsQueue, true);
            LoadSettings();
            this.labelCheckDelay.Text = $"Check Delay: {Settings.ProgressCheckDelay}s";
            this.toolTipInfo.SetToolTip(this.labelCheckDelay, 
                "The amount of seconds before checking the progress of the application (higher = less risk of crashing)"
                );
            this.toolTipInfo.SetToolTip(this.checkBoxRecursive, 
                "If you are dragging folders to import, with this option ticked, it will search all subfolders inside that folder for pkg files"
                );
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            SaveSettings();
            if(server != null){
                server.StopServer();
            }
        }

        private void PopulateValidIPs() {
            foreach(var ip in Dns.GetHostEntry(Dns.GetHostName()).AddressList) {
                if(ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork) {
                    comboBoxServerIP.Items.Add(ip.ToString());
                }
            }

            if (File.Exists(Settings.CustomIPsFile)) {
                foreach(var line in File.ReadAllLines(Settings.CustomIPsFile)) {
                    if (AddServerIpForm.IsValidIP(line)) {
                        comboBoxServerIP.Items.Add(line);
                    }
                }
            }

            if(comboBoxServerIP.Items.Count > 0) {
                comboBoxServerIP.SelectedIndex = 0;
            }
        }

      
        private void buttonProcessQueue_Click(object sender, EventArgs e) {
            if (processing) {
                buttonProcessQueue.Text = "Process Queue";
                processing = false;
                queueBackgroundWorker.CancelAsync();
            } else {
                if (queueBackgroundWorker.IsBusy) {
                    MessageBox.Show("The background worker is still busy.\nPlease wait some seconds before trying again.", "Error");
                    return;
                }
                if(ps4PkgList.Count == 0) {
                    MessageBox.Show("The queue is empty. Please add some items first", "Error");
                    return;
                }
                if (!connected) {
                    MessageBox.Show("Please check your PS4's IP or ensure your firewall is not blocking the connection.","Could Not Establish Connection");
                    return;
                }
                SaveSettings();
                processing = true;
                buttonProcessQueue.Text = "Stop Queue";
                queueBackgroundWorker.RunWorkerAsync(GetServerDetails());
            }
        }

        private bool IsValidIP() {
            return AddServerIpForm.IsValidIP(textBoxPS4IP.Text);
        }

        private void ToggleConnected(bool connected) {
            this.connected = connected;
            if (connected) ChangeConnectedLabel(Themer.ThemeSettings.ConnectedLabel, "Connected");
            else ChangeConnectedLabel(Themer.ThemeSettings.DisconnectedLabel, "Not Connected");
        }

        private void ChangeConnectedLabel(ThemeItem connectionTheme, string text) {
            labelConnectionDisplay.ForeColor = connectionTheme.ForeColor;
            labelConnectionDisplay.BackColor= connectionTheme.BackColor;
            labelConnectionDisplay.Font = connectionTheme.Values["Font"] as Font;
            labelConnectionDisplay.Text = text;
        }

        private void timer1_Tick(object sender, EventArgs e) {
            if (IsValidIP() && !connected) {
                using (var pingSender = new Ping()) {
                    var pingOptions = new PingOptions() {
                        DontFragment = true,
                        Ttl = 5
                    };

                    var pingData = Encoding.ASCII.GetBytes("hello world");
                    const int timeout = 60;
                    try {
                        var reply = pingSender.Send(textBoxPS4IP.Text, timeout, pingData, pingOptions);
                        if (reply.Status == IPStatus.Success) {
                            ToggleConnected(true);
                            Logger.WriteLine("Successfully Pinged Device",Logger.Type.DebugOutput);
                        } else {
                            ToggleConnected(false);
                        }
                    } catch {

                    }
                }
            }
        }

        private void textBoxPS4IP_TextChanged(object sender, EventArgs e) {
            ToggleConnected(false);
        }

        #region ListView Stuff

        private void ColumnWidth(ColumnHeader header, int width) {
            listViewItemsQueue.InvokeIfRequired(() => header.Width = width);
        }

        ScrollBars GetControlVisibleScrollbars(Control ctl) {
            int wndStyle = Win32Api.GetWindowLong(listViewHwnd, Win32Api.GWL_STYLE);
            bool hsVisible = (wndStyle & Win32Api.WS_HSCROLL) != 0;
            bool vsVisible = (wndStyle & Win32Api.WS_VSCROLL) != 0;

            if (hsVisible)
                return vsVisible ? ScrollBars.Both : ScrollBars.Horizontal;
            else
                return vsVisible ? ScrollBars.Vertical : ScrollBars.None;
        }

        public ScrollBars GetVisibleScrollbars() {
            return GetControlVisibleScrollbars(listViewItemsQueue);
        }

        public void ResizeListViewColumns(ListView listView, IntPtr hwnd) {
            int i = 0;
            int TotalWidthUsed = 0;
            int Offset = 40;
            listView.InvokeIfRequired(() => listView.SuspendLayout());
            foreach (ColumnHeader item in listView.Columns) {
                int itemCount = listView.Items.Count;
                if (i == listView.Columns.Count - 1) {
                    int offsetWidth = 12;

                    if ((GetVisibleScrollbars() & ScrollBars.Vertical) == ScrollBars.Vertical) {
                        offsetWidth += 17;
                    }
                    int remainingWidth = (this.Width) - TotalWidthUsed - offsetWidth;
                    ColumnWidth(item, remainingWidth);
                } else {
                    if (itemCount > 0) {
                        int max = 0;
                        listView.InvokeIfRequired(() => {
                            int j = 0;
                            foreach (ListViewItem lvitem in listView.Items) {
                                int subItemCount = listView.Items[j].SubItems.Count - 1;
                                int index = item.Index > (subItemCount) ? subItemCount : item.Index;
                                var size = TextRenderer.MeasureText(listView.Items[j].SubItems[index].Text, listView.Font).Width;
                                if (size > max) {
                                    max = size;
                                }
                                ++j;
                            }
                        });
                        switch (item.Text) {
                            case "File Name":

                            break;

                            case "Title":
                            if (max < 220) {
                                ColumnWidth(item, max + 8 + Offset);
                            }
                            break;

                            default:
                            ColumnWidth(item, max + 8 + Offset);
                            break;
                        }
                    } else {
                        ColumnWidth(item, TextRenderer.MeasureText(item.Text, listView.Font).Width + 8 + Offset);
                    }

                    listView.InvokeIfRequired(() => TotalWidthUsed += item.Width);
                }

                listView.InvokeIfRequired(() => listView.ResumeLayout());
                ++i;
            }
            int maxTotalWidth = 797;
            listView.InvokeIfRequired(() => {
                this.listViewItemsQueue.Columns[listViewItemsQueue.Columns.Count - 1].Width = Math.Abs(maxTotalWidth - TotalWidthUsed - 3);
            });
        }

        private void listViewItemsQueue_DragEnter(object sender, DragEventArgs e) {
            if(e.Data.GetDataPresent(DataFormats.FileDrop)) {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void listViewItemsQueue_MouseUp(object sender, MouseEventArgs e) {
            if (processing) return;
            if (e.Button == MouseButtons.Right) {
                bool focusedItem = false;
                foreach (ListViewItem lvItem in listViewItemsQueue.SelectedItems) {
                    if (lvItem.Focused) {
                        if (lvItem.Bounds.Contains(e.Location)) {
                            focusedItem = true;
                        }
                        break;
                    }
                }

                if (focusedItem) {
                    contextMenuStripFocused.InvokeIfRequired(() => {
                        contextMenuStripFocused.Show(Cursor.Position);
                    });
                } else {
                    contextMenuStripNoFocus.InvokeIfRequired(() => {
                        contextMenuStripNoFocus.Show(Cursor.Position);
                    });
                }
            }
        }


        private void listViewItemsQueue_DragDrop(object sender, DragEventArgs e) {
            string[] filePaths = e.Data.GetData(DataFormats.FileDrop) as string[];
            if (filePaths != null && filePaths.Length > 0) {
                AddAllValidItems(filePaths);

                var jsonFiles = GetFilesForFileExtension(".json", filePaths, true);

                foreach (var jsonFile in jsonFiles) {

                    var queueItemList = ReadQueueItemJsonFile(jsonFile);
                    if (queueItemList == null) continue;
                    ImportQueueItems(queueItemList);
                }
            }
        }

        string[] GetFilesForFileExtension(string extension, string[] paths, bool searchDirectory) {
            List<string> fileList = new List<string>();
            foreach (var path in paths.Where(n => Path.GetExtension(n) == extension || Directory.Exists(n))) {
                if (Directory.Exists(path) && searchDirectory && checkBoxRecursive.Checked) {
                    fileList.AddRange(Directory.GetFiles(path, $"*{extension}", SearchOption.AllDirectories));
                } else if (File.Exists(path)) {
                    fileList.Add(path);
                }
            }

            return fileList.ToArray();
        }

     

        public void AutoUpdateColumnWidth(ListView lv) {
            for (int i = 0; i <= lv.Columns.Count - 1; i++) {
                lv.Columns[i].Width = -2;
            }
        }

        private void MainForm_Resize(object sender, EventArgs e) {
            AutoUpdateColumnWidth(listViewItemsQueue);
        }

        #endregion

        #region Item Queue Stuff
        private void AddItem(PkgInfo pkgInfo) {
            //Add To ListView
            ListViewItem listViewItem = new ListViewItem(pkgInfo.Title);
            listViewItem.Tag = pkgInfo.GetHashCode();
            listViewItem.SubItems.Add(Path.GetFileName(pkgInfo.FilePath));
            listViewItem.SubItems.Add(pkgInfo.Type.ToDisplayText());
            listViewItem.SubItems.Add(Enums.TaskType.Queued.ToString());
            this.listViewItemsQueue.InvokeIfRequired(() => listViewItemsQueue.Items.Add(listViewItem));
            QueueItem queueItem = new QueueItem(listViewItem, listViewItemsQueue, pkgInfo);
            ps4PkgList.Add(queueItem);
        }

        private void AddItem(QueueItemInfo queueItemInfo) {
            //Add To ListView
            var pkgInfo = queueItemInfo.PkgInfo;
            ListViewItem listViewItem = new ListViewItem(pkgInfo.Title);
            listViewItem.Tag = pkgInfo.GetHashCode();
            listViewItem.SubItems.Add(Path.GetFileName(pkgInfo.FilePath));
            listViewItem.SubItems.Add(pkgInfo.Type.ToDisplayText());
            var queueInfoText = queueItemInfo.Uninstall ? $"Marked for uninstall" : Enums.TaskType.Queued.ToString();
            listViewItem.SubItems.Add(queueInfoText);
            this.listViewItemsQueue.InvokeIfRequired(() => listViewItemsQueue.Items.Add(listViewItem));
            QueueItem queueItem = new QueueItem(listViewItem, listViewItemsQueue, queueItemInfo);
            ps4PkgList.Add(queueItem);
        }

        private bool SanitizePathNeeded(PkgInfo pkgInfo, out FileRenameInfo fileRenameInfo) {
            fileRenameInfo = null;
            var pattern = @"^[\\a-zA-Z0-9-_\.]+$";
            var currentFileName = Path.GetFileName(pkgInfo.FilePath);
            var match = Regex.Match(currentFileName, pattern);
            if (!Regex.IsMatch(currentFileName,pattern)) {

                fileRenameInfo = new FileRenameInfo() {
                    CurrentName = currentFileName,
                    CurrentPath = Path.GetFullPath(pkgInfo.FilePath),
                };

                pattern = pattern.Substring(1, pattern.Length - 2);
                string newFileName = "";
                var newMatch = Regex.Match(currentFileName, pattern);
                while (newMatch.Success) {
                    newFileName += newMatch.Value;
                    newMatch = newMatch.NextMatch();
                }
                int maxFileNameSize = 60;
                if(newFileName.Length > maxFileNameSize) {
                    //PS4 only seems to like titles < 60 (including ".pkg")
                    //So we eliminate the remainder from the start
                    //this is only used for renaming files, nothing more
                    //so it does not matter if the name looks weird. It's only temporary :)
                    newFileName = newFileName.Remove(0,newFileName.Length - maxFileNameSize);
                }
                fileRenameInfo.WantedName = newFileName;
                return true;
            }
            return false;
        }

        private void AddAllValidItems(string[] paths) {
            var pkgFilePaths = GetFilesForFileExtension(".pkg", paths, true);
            List<PkgInfo> pkgList = new List<PkgInfo>();
            List<PkgInfo> patchesList = new List<PkgInfo>();
            foreach (var filePath in pkgFilePaths) {
                var pkgFilePath = filePath;
              try {
                    var pkg = PS4_Tools.PKG.SceneRelated.Read_PKG(pkgFilePath);
                    PkgInfo pkgInfo = new PkgInfo();
                    pkgInfo.FilePath = pkgFilePath;
                    pkgInfo.TitleID = pkg.Param.TitleID;
                    pkgInfo.Title = pkg.Param.Title;
                    pkgInfo.Version = pkg.Param.APP_VER;
                    pkgInfo.Type = Enums.Parser.Parse(pkg.PKG_Type);
                    pkgInfo.ContentID = pkg.Content_ID;
                    //pkgInfo.PkgFiles = new string[] { Path.GetFileName(pkgFilePath) };

                    if (pkgInfo.Type == Enums.PkgType.Patch) {
                        patchesList.Add(pkgInfo);
                    } else {
                        AddItem(pkgInfo);
                    }
                } catch { }
            }


            //Handles multiple patches edge case
            var patchDict = new Dictionary<string, List<string>>();
            foreach (var patch in patchesList) {
                if (!patchDict.ContainsKey(patch.TitleID)) {
                    patchDict.Add(patch.TitleID, new List<string>());
                }

                if (System.Text.RegularExpressions.Regex.IsMatch(patch.FilePath, @"([A-Za-z0-9-_]+_\d.pkg)+")) {
                    patchDict[patch.TitleID].Add(Path.GetFileName(patch.FilePath));
                }
            }

            for (int i = 0; i < patchesList.Count; ++i) {
                var filePaths = patchDict[patchesList[i].TitleID];
                patchesList[i].PatchSegments = filePaths.ToArray();
                AddItem(patchesList[i]);
            }

            //Order by games -> patch -> DLC -> themes so nothing goes wrong
            //This will not change the order in the list view
            //But it is not necessary anyway, as each object has an instance
            //To the UI
            ps4PkgList.Sort();
            ResizeListViewColumns(this.listViewItemsQueue, listViewHwnd);
        }
        

        public void queueWorker_DoWork(object sender, DoWorkEventArgs e) {
            Server server = (Server)e.Argument;
            Queue<QueueItem> ps4PkgQueue = new Queue<QueueItem>();
            ps4PkgList.Where(pkg => pkg.TaskType == Enums.TaskType.Queued).ToList().ForEach(p => ps4PkgQueue.Enqueue(p));
            int totalQueue = ps4PkgQueue.Count;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            bool playErrorSound = false;
            while (ps4PkgQueue.Count > 0) {

                
                this.labelProgressNotify.InvokeIfRequired(() =>labelProgressNotify.Text = $"Items left in queue {ps4PkgQueue.Count} of {totalQueue}");
                var queueItem = ps4PkgQueue.Dequeue();
                var hashCode = queueItem.Info.PkgInfo.GetHashCode();
                if (QueueItemToIgnoreSet.Contains(hashCode)) {
                    QueueItemToIgnoreSet.Remove(hashCode);
                    continue;
                }
                try {
                    bool checkedPrereqs = false;
                    PkgTransfer pkgTransfer = new PkgTransfer(queueItem, queueBackgroundWorker, fileRenameService,server);
                    while (!queueBackgroundWorker.CancellationPending) {

                        if (!checkedPrereqs) {

                            if (SanitizePathNeeded(queueItem.Info.PkgInfo, out var renameInfo)) {
                                queueItem.FileRenameInfo = renameInfo;
                                if (!fileRenameService.Rename(renameInfo)) {
                                    throw new SkipItemException(Enums.TaskType.Failed, "Failed to sanitize file. Rename this file manually and re-add to the sender.");
                                }
                                queueItem.Info.PkgInfo.FilePath = renameInfo.CurrentPath;
                            }
                            checkedPrereqs = true;
                        }

                        var transferProgress = pkgTransfer.Transfer();
                      
                        if (transferProgress.TimeLeft > 0) {
                            this.progressBar1.InvokeIfRequired(() => progressBar1.ExtraText = $" ({transferProgress.TimeLeft})");
                        }

                        if (transferProgress.TransferStatus == Enums.TransferStatus.Completed) {
                            progressBar1.InvokeIfRequired(() => progressBar1.ResetProgressBar());
                            queueItem.UpdateTask(Enums.TaskType.Finished, queueItem.Info.Uninstall ? "Uninstalled" : "Installed", listViewItemsQueue);
                            server.StopServer();
                            System.Threading.Thread.Sleep(1000); //Sleep some seconds so we don't piss the server off
                            break;
                        }

                        System.Threading.Thread.Sleep(500);
                    }

                }  catch (SkipItemException ex) { 
                    //Skip Item
                    queueItem.UpdateTask(ex.TaskType, ex.Message, listViewItemsQueue);
                    server.StopServer();
                    playErrorSound = true;
                } catch (ServerInitializationException ex) {
                    queueItem.UpdateTask(Enums.TaskType.Failed,$"Failed to initialize server - {ex.Message}", listViewItemsQueue);
                    playErrorSound = true;
                }

                if (playErrorSound) {
                    if (Settings.SoundSettings.PlaySoundOnError) {
                        Json.SoundSettings.PlayErrorSound();
                    }
                    playErrorSound = false;
                }
              

                if (queueItem.FileRenameInfo != null) {
                    //Queue the file to the service, so we can rename it to the old filename
                    fileRenameService.FileRenameQueue.Enqueue(queueItem.FileRenameInfo);
                }
            }

            if (!queueBackgroundWorker.CancellationPending) {
                if (Settings.SoundSettings.PlayQueueFinishSound) {
                    Json.SoundSettings.PlayCompleteSound();
                }
                this.labelProgressNotify.InvokeIfRequired(() => labelProgressNotify.Text = $"All Done!");
                this.InvokeIfRequired(() => buttonProcessQueue_Click(null, null));
            } else {
                this.labelProgressNotify.InvokeIfRequired(() => labelProgressNotify.Text = $"Items left in queue {ps4PkgQueue.Count} of {totalQueue}");
            }
            server.StopServer();
            connected = false;
        }

        public void queueWorker_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            this.progressBar1.InvokeIfRequired((()=> {
                //When the JB fails to correctly initialize, the pkg sender breaks and sends some absurd values
                //Or it could be the fault of mira, who knows.

                //This prevents it from overflowing the progress bar
                if(e.ProgressPercentage < 0 || e.ProgressPercentage >=  int.MaxValue) {
                    return;
                }
                progressBar1.Value = e.ProgressPercentage;
                var progress = e.UserState as DataTrasmittedProgress;
                if(progress != null) {
                    progressBar1.SecondsRemaining = progress.SecondsLeft;
                }
            }));
        }

        #endregion

        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e) {
            ps4PkgList.Clear();
            this.listViewItemsQueue.Items.Clear();
        }

        private void ChangeItemStatus(Action<QueueItem> action) {
            foreach (ListViewItem item in this.listViewItemsQueue.SelectedItems) {
                var q = ps4PkgList
                    .Where(queueItem => queueItem.Info.PkgInfo.GetHashCode() == (int)item.Tag)
                    .FirstOrDefault();
                if (q != null) {
                    action?.Invoke(q);
                }
            }
        }
        private void markForUninstallToolStripMenuItem_Click(object sender, EventArgs e) {
            ChangeItemStatus(q => {
                q.UpdateTask(Enums.TaskType.Queued, "Marked for uninstall", this.listViewItemsQueue);
                q.Info.Uninstall = true;
            });
        }

        private void requeueItemToolStripMenuItem_Click(object sender, EventArgs e) {
            ChangeItemStatus(q => {
                q.UpdateTask(Enums.TaskType.Queued, this.listViewItemsQueue);
                q.Info.Uninstall = false; 
            });
        }

        private void themeToolStripMenuItem_Click(object sender, EventArgs e) {
            MarkItemAs(Enums.PkgType.Addon_Theme, this.listViewItemsQueue);
        }

        private void dLCToolStripMenuItem_Click(object sender, EventArgs e) {
            MarkItemAs(Enums.PkgType.Additional_Content, this.listViewItemsQueue);
        }

        private void patchToolStripMenuItem_Click(object sender, EventArgs e) {
            MarkItemAs(Enums.PkgType.Patch, this.listViewItemsQueue);
        }

        private void gameToolStripMenuItem_Click(object sender, EventArgs e) {
            MarkItemAs(Enums.PkgType.Game, this.listViewItemsQueue);
        }

        private void MarkItemAs(Enums.PkgType pkgType,ListView listView) {
            ChangeItemStatus(q => {
                q.UpdateType(pkgType, listView);
            });
            ps4PkgList.Sort(); //Re-sort so items get pushed to their specifiic order
        }

        private void label3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start("https://github.com/frostyso");
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e) {
            using (OpenFileDialog openFileDialog = new OpenFileDialog()) {
                openFileDialog.Multiselect = true;
                openFileDialog.Filter = "Pkg files (*.pkg)|*.pkg";
                if(openFileDialog.ShowDialog() == DialogResult.OK) {
                    AddAllValidItems(openFileDialog.FileNames);
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e) {
            listViewItemsQueue.BeginUpdate();
            //Delete from the reverse
            for (int i = listViewItemsQueue.Items.Count - 1; i >= 0; --i) {
                if (listViewItemsQueue.Items[i].Selected) {
                    QueueItemToIgnoreSet.Add((int)listViewItemsQueue.Items[i].Tag);
                    listViewItemsQueue.Items.RemoveAt(i);
                }
            }
            listViewItemsQueue.EndUpdate();
            for(int i= ps4PkgList.Count-1; i>=0; --i) {
                var hashCode = ps4PkgList[i].Info.PkgInfo.GetHashCode();
                if (QueueItemToIgnoreSet.Contains(hashCode)) {
                    ps4PkgList.RemoveAt(i);
                    QueueItemToIgnoreSet.Remove(hashCode);
                }
            }
        }

        private void listViewItemsQueue_ColumnClick(object sender, ColumnClickEventArgs e) {
            ListView myListView = (ListView)sender;

            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == listViewColumnSorter.SortColumn) {
                // Reverse the current sort direction for this column.
                if (listViewColumnSorter.Order == SortOrder.Ascending) {
                    listViewColumnSorter.Order = SortOrder.Descending;
                } else {
                    listViewColumnSorter.Order = SortOrder.Ascending;
                }
            } else {
                // Set the column number that is to be sorted; default to ascending.
                listViewColumnSorter.SortColumn = e.Column;
                listViewColumnSorter.Order = SortOrder.Ascending;
            }
            // Perform the sort with these new sort options.
            myListView.Sort();
        }

        private void linkLabelAddServerIp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            var ipForm = new AddServerIpForm();
            if(ipForm.ShowDialog() == DialogResult.OK) {
                comboBoxServerIP.Items.Add(ipForm.IP);
                var ipsList = new List<string>();
                if (File.Exists(Settings.CustomIPsFile)) {
                    ipsList.AddRange(File.ReadAllLines(Settings.CustomIPsFile));
                }
                ipsList.Add(ipForm.IP);
                File.WriteAllLines(Settings.CustomIPsFile, ipsList);
            }
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e) {
            if (listViewItemsQueue.SelectedItems.Count == 0)
                return;
            var ps4QueueListAsDict = ps4PkgList
                .ToDictionary(k => k.Info.PkgInfo.GetHashCode(), queueItem => queueItem);

            var queueItemList = new List<QueueItemInfo>();
            foreach (ListViewItem lvItem in listViewItemsQueue.SelectedItems) {
                if(ps4QueueListAsDict.TryGetValue((int)lvItem.Tag,out var queueItem)) {
                    queueItemList.Add(queueItem.Info);
                }
            }

            var json = JsonConvert.SerializeObject(queueItemList, Formatting.Indented);
            using (var saveFileDialog = new SaveFileDialog()) {
                saveFileDialog.Filter = "json files (*.json)|*.json";
                if (saveFileDialog.ShowDialog(this) == DialogResult.OK) {
                    File.WriteAllText(saveFileDialog.FileName, json);
                }
            }
        }

       

        private void importToolStripMenuItem_Click(object sender, EventArgs e) {
            List<QueueItemInfo> queueItemList = null;
            using (var openFileDialog = new OpenFileDialog()) {
                openFileDialog.Filter = "json files (*.json)|*.json";
                if(openFileDialog.ShowDialog(this) == DialogResult.OK) {
                    try {
                        queueItemList = JsonConvert.DeserializeObject<List<QueueItemInfo>>(File.ReadAllText(openFileDialog.FileName));
                    } catch {
                        MessageBox.Show(this, "Invalid json file format", $"File {openFileDialog.SafeFileName} Not Supported",MessageBoxButtons.OK);
                    }
                }
            }
            if (queueItemList == null) return;
            ImportQueueItems(queueItemList);
        }

        List<QueueItemInfo> ReadQueueItemJsonFile(string filePath) {
            try {
                return JsonConvert.DeserializeObject<List<QueueItemInfo>>(File.ReadAllText(filePath));
            } catch {
                MessageBox.Show(this, "Invalid json file format", $"File {Path.GetFileName(filePath)} Not Supported", MessageBoxButtons.OK);
                return null;
            }
        }


        private void ImportQueueItems(IEnumerable<QueueItemInfo> queueItems) {
            var skippedItems = new List<string>();
            foreach (var item in queueItems) {

                if (File.Exists(item.PkgInfo.FilePath)) {
                    AddItem(item.PkgInfo);
                } else {
                    skippedItems.Add(item.PkgInfo.Title);
                }
            }

            if(skippedItems.Count > 0) {
                MessageBox.Show("The Following Items have been skipped:\n" + string.Join(Environment.NewLine, skippedItems) + "\n\nReason: File not found");
            }
        }

        private void labelSettings_Click(object sender, EventArgs e) {
            var settings = new SettingsForm(this);
            settings.ShowDialog(this);
        }
      
    }
}
