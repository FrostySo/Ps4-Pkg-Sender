﻿namespace Ps4_Pkg_Sender {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBoxSkipInstallCheck = new System.Windows.Forms.CheckBox();
            this.labelProgressNotify = new System.Windows.Forms.Label();
            this.progressBar1 = new Ps4_Pkg_Sender.Controls.CustomProgressBar();
            this.checkBoxRecursive = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelSettings = new System.Windows.Forms.LinkLabel();
            this.linkLabelAddServerIp = new System.Windows.Forms.LinkLabel();
            this.labelCheckDelay = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelConnectionDisplay = new System.Windows.Forms.Label();
            this.labelConnectionStatus = new System.Windows.Forms.Label();
            this.textBoxPS4IP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxServerIP = new System.Windows.Forms.ComboBox();
            this.buttonProcessQueue = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStripFocused = new Controls.CustomContextMenu(this.components);
            this.requeueItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.markAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.themeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dLCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.patchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.markForUninstallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTipInfo = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuStripNoFocus = new Controls.CustomContextMenu(this.components);
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listViewItemsQueue = new Ps4_Pkg_Sender.Controls.CustomListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.contextMenuStripFocused.SuspendLayout();
            this.contextMenuStripNoFocus.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBoxSkipInstallCheck);
            this.panel1.Controls.Add(this.labelProgressNotify);
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Controls.Add(this.checkBoxRecursive);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.buttonProcessQueue);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 333);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 117);
            this.panel1.TabIndex = 1;
            // 
            // checkBoxSkipInstallCheck
            // 
            this.checkBoxSkipInstallCheck.AutoSize = true;
            this.checkBoxSkipInstallCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxSkipInstallCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxSkipInstallCheck.ForeColor = System.Drawing.Color.White;
            this.checkBoxSkipInstallCheck.Location = new System.Drawing.Point(431, 38);
            this.checkBoxSkipInstallCheck.Name = "checkBoxSkipInstallCheck";
            this.checkBoxSkipInstallCheck.Size = new System.Drawing.Size(129, 20);
            this.checkBoxSkipInstallCheck.TabIndex = 16;
            this.checkBoxSkipInstallCheck.Text = "Skip Install Check";
            this.checkBoxSkipInstallCheck.UseVisualStyleBackColor = true;
            // 
            // labelProgressNotify
            // 
            this.labelProgressNotify.AutoSize = true;
            this.labelProgressNotify.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProgressNotify.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelProgressNotify.Location = new System.Drawing.Point(431, 62);
            this.labelProgressNotify.Name = "labelProgressNotify";
            this.labelProgressNotify.Size = new System.Drawing.Size(71, 16);
            this.labelProgressNotify.TabIndex = 15;
            this.labelProgressNotify.Tag = "Big";
            this.labelProgressNotify.Text = "All Done!";
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.Color.Gray;
            this.progressBar1.ExtraText = null;
            this.progressBar1.FontColor = System.Drawing.Color.White;
            this.progressBar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(116)))), ((int)(((byte)(12)))));
            this.progressBar1.Location = new System.Drawing.Point(431, 83);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.SecondsRemaining = ((long)(0));
            this.progressBar1.Size = new System.Drawing.Size(357, 23);
            this.progressBar1.TabIndex = 14;
            // 
            // checkBoxRecursive
            // 
            this.checkBoxRecursive.AutoSize = true;
            this.checkBoxRecursive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxRecursive.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxRecursive.ForeColor = System.Drawing.Color.White;
            this.checkBoxRecursive.Location = new System.Drawing.Point(431, 12);
            this.checkBoxRecursive.Name = "checkBoxRecursive";
            this.checkBoxRecursive.Size = new System.Drawing.Size(192, 20);
            this.checkBoxRecursive.TabIndex = 13;
            this.checkBoxRecursive.Text = "Search Recursively for pkgs";
            this.checkBoxRecursive.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelSettings);
            this.groupBox1.Controls.Add(this.linkLabelAddServerIp);
            this.groupBox1.Controls.Add(this.labelCheckDelay);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.labelConnectionDisplay);
            this.groupBox1.Controls.Add(this.labelConnectionStatus);
            this.groupBox1.Controls.Add(this.textBoxPS4IP);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBoxServerIP);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(425, 117);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Server Settings";
            // 
            // labelSettings
            // 
            this.labelSettings.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(116)))), ((int)(((byte)(12)))));
            this.labelSettings.AutoSize = true;
            this.labelSettings.LinkColor = System.Drawing.Color.White;
            this.labelSettings.Location = new System.Drawing.Point(6, 82);
            this.labelSettings.Name = "labelSettings";
            this.labelSettings.Size = new System.Drawing.Size(59, 15);
            this.labelSettings.TabIndex = 20;
            this.labelSettings.TabStop = true;
            this.labelSettings.Tag = "Small";
            this.labelSettings.Text = "Settings";
            this.labelSettings.VisitedLinkColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelSettings.Click += new System.EventHandler(this.labelSettings_Click);
            // 
            // linkLabelAddServerIp
            // 
            this.linkLabelAddServerIp.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(116)))), ((int)(((byte)(12)))));
            this.linkLabelAddServerIp.AutoSize = true;
            this.linkLabelAddServerIp.LinkColor = System.Drawing.Color.White;
            this.linkLabelAddServerIp.Location = new System.Drawing.Point(160, 82);
            this.linkLabelAddServerIp.Name = "linkLabelAddServerIp";
            this.linkLabelAddServerIp.Size = new System.Drawing.Size(93, 15);
            this.linkLabelAddServerIp.TabIndex = 19;
            this.linkLabelAddServerIp.TabStop = true;
            this.linkLabelAddServerIp.Text = "Add Server IP";
            this.linkLabelAddServerIp.VisitedLinkColor = System.Drawing.SystemColors.ButtonHighlight;
            this.linkLabelAddServerIp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelAddServerIp_LinkClicked);
            // 
            // labelCheckDelay
            // 
            this.labelCheckDelay.AutoSize = true;
            this.labelCheckDelay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCheckDelay.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelCheckDelay.Location = new System.Drawing.Point(274, 75);
            this.labelCheckDelay.Name = "labelCheckDelay";
            this.labelCheckDelay.Size = new System.Drawing.Size(121, 15);
            this.labelCheckDelay.TabIndex = 18;
            this.labelCheckDelay.Tag = "Small";
            this.labelCheckDelay.Text = "Check Delay:  20s";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(259, 7);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1, 92);
            this.panel2.TabIndex = 16;
            // 
            // labelConnectionDisplay
            // 
            this.labelConnectionDisplay.AutoSize = true;
            this.labelConnectionDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelConnectionDisplay.ForeColor = System.Drawing.Color.Red;
            this.labelConnectionDisplay.Location = new System.Drawing.Point(274, 49);
            this.labelConnectionDisplay.Name = "labelConnectionDisplay";
            this.labelConnectionDisplay.Size = new System.Drawing.Size(121, 18);
            this.labelConnectionDisplay.TabIndex = 15;
            this.labelConnectionDisplay.Tag = "cLabel";
            this.labelConnectionDisplay.Text = "Not Connected";
            // 
            // labelConnectionStatus
            // 
            this.labelConnectionStatus.AutoSize = true;
            this.labelConnectionStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelConnectionStatus.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelConnectionStatus.Location = new System.Drawing.Point(274, 21);
            this.labelConnectionStatus.Name = "labelConnectionStatus";
            this.labelConnectionStatus.Size = new System.Drawing.Size(147, 18);
            this.labelConnectionStatus.TabIndex = 14;
            this.labelConnectionStatus.Tag = "Big";
            this.labelConnectionStatus.Text = "Connection Status";
            // 
            // textBoxPS4IP
            // 
            this.textBoxPS4IP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPS4IP.Location = new System.Drawing.Point(132, 56);
            this.textBoxPS4IP.Name = "textBoxPS4IP";
            this.textBoxPS4IP.Size = new System.Drawing.Size(121, 22);
            this.textBoxPS4IP.TabIndex = 5;
            this.textBoxPS4IP.TextChanged += new System.EventHandler(this.textBoxPS4IP_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 4;
            this.label2.Tag = "Big";
            this.label2.Text = "PS4 IP:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 20);
            this.label1.TabIndex = 3;
            this.label1.Tag = "Big";
            this.label1.Text = "Server IP:";
            // 
            // comboBoxServerIP
            // 
            this.comboBoxServerIP.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.comboBoxServerIP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxServerIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxServerIP.FormattingEnabled = true;
            this.comboBoxServerIP.Location = new System.Drawing.Point(132, 19);
            this.comboBoxServerIP.Name = "comboBoxServerIP";
            this.comboBoxServerIP.Size = new System.Drawing.Size(121, 26);
            this.comboBoxServerIP.TabIndex = 2;
            // 
            // buttonProcessQueue
            // 
            this.buttonProcessQueue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(116)))), ((int)(((byte)(12)))));
            this.buttonProcessQueue.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonProcessQueue.FlatAppearance.BorderSize = 0;
            this.buttonProcessQueue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonProcessQueue.ForeColor = System.Drawing.Color.White;
            this.buttonProcessQueue.Location = new System.Drawing.Point(649, 8);
            this.buttonProcessQueue.Name = "buttonProcessQueue";
            this.buttonProcessQueue.Size = new System.Drawing.Size(139, 28);
            this.buttonProcessQueue.TabIndex = 1;
            this.buttonProcessQueue.Text = "Process Queue";
            this.buttonProcessQueue.UseVisualStyleBackColor = false;
            this.buttonProcessQueue.Click += new System.EventHandler(this.buttonProcessQueue_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 700;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // contextMenuStripFocused
            // 
            this.contextMenuStripFocused.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.requeueItemToolStripMenuItem,
            this.markAsToolStripMenuItem,
            this.markForUninstallToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.clearAllToolStripMenuItem,
            this.exportToolStripMenuItem});
            this.contextMenuStripFocused.Name = "contextMenuStrip1";
            this.contextMenuStripFocused.Size = new System.Drawing.Size(171, 136);
            // 
            // requeueItemToolStripMenuItem
            // 
            this.requeueItemToolStripMenuItem.Name = "requeueItemToolStripMenuItem";
            this.requeueItemToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.requeueItemToolStripMenuItem.Text = "Requeue Item";
            this.requeueItemToolStripMenuItem.Click += new System.EventHandler(this.requeueItemToolStripMenuItem_Click);
            // 
            // markAsToolStripMenuItem
            // 
            this.markAsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.themeToolStripMenuItem,
            this.gameToolStripMenuItem,
            this.dLCToolStripMenuItem,
            this.patchToolStripMenuItem});
            this.markAsToolStripMenuItem.Name = "markAsToolStripMenuItem";
            this.markAsToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.markAsToolStripMenuItem.Text = "Mark As";
            // 
            // themeToolStripMenuItem
            // 
            this.themeToolStripMenuItem.Name = "themeToolStripMenuItem";
            this.themeToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.themeToolStripMenuItem.Text = "Theme";
            this.themeToolStripMenuItem.Click += new System.EventHandler(this.themeToolStripMenuItem_Click);
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.gameToolStripMenuItem.Text = "Game";
            this.gameToolStripMenuItem.Click += new System.EventHandler(this.gameToolStripMenuItem_Click);
            // 
            // dLCToolStripMenuItem
            // 
            this.dLCToolStripMenuItem.Name = "dLCToolStripMenuItem";
            this.dLCToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.dLCToolStripMenuItem.Text = "DLC";
            this.dLCToolStripMenuItem.Click += new System.EventHandler(this.dLCToolStripMenuItem_Click);
            // 
            // patchToolStripMenuItem
            // 
            this.patchToolStripMenuItem.Name = "patchToolStripMenuItem";
            this.patchToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.patchToolStripMenuItem.Text = "Patch";
            this.patchToolStripMenuItem.Click += new System.EventHandler(this.patchToolStripMenuItem_Click);
            // 
            // markForUninstallToolStripMenuItem
            // 
            this.markForUninstallToolStripMenuItem.Name = "markForUninstallToolStripMenuItem";
            this.markForUninstallToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.markForUninstallToolStripMenuItem.Text = "Mark For Uninstall";
            this.markForUninstallToolStripMenuItem.Click += new System.EventHandler(this.markForUninstallToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // clearAllToolStripMenuItem
            // 
            this.clearAllToolStripMenuItem.Name = "clearAllToolStripMenuItem";
            this.clearAllToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.clearAllToolStripMenuItem.Text = "Clear All";
            this.clearAllToolStripMenuItem.Click += new System.EventHandler(this.clearAllToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.exportToolStripMenuItem.Text = "Export";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // contextMenuStripNoFocus
            // 
            this.contextMenuStripNoFocus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem4,
            this.importToolStripMenuItem});
            this.contextMenuStripNoFocus.Name = "contextMenuStrip1";
            this.contextMenuStripNoFocus.Size = new System.Drawing.Size(157, 48);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(156, 22);
            this.toolStripMenuItem4.Text = "Add Package(s)";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.importToolStripMenuItem.Text = "Import";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // listViewItemsQueue
            // 
            this.listViewItemsQueue.AllowDrop = true;
            this.listViewItemsQueue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.listViewItemsQueue.ColumnBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.listViewItemsQueue.ColumnFontColor = System.Drawing.Color.White;
            this.listViewItemsQueue.ColumnLinesColor = System.Drawing.Color.Gray;
            this.listViewItemsQueue.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listViewItemsQueue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewItemsQueue.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewItemsQueue.ForeColor = System.Drawing.Color.White;
            this.listViewItemsQueue.FullRowSelect = true;
            this.listViewItemsQueue.HideSelection = false;
            this.listViewItemsQueue.Location = new System.Drawing.Point(0, 0);
            this.listViewItemsQueue.Name = "listViewItemsQueue";
            this.listViewItemsQueue.OwnerDraw = true;
            this.listViewItemsQueue.Size = new System.Drawing.Size(800, 333);
            this.listViewItemsQueue.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listViewItemsQueue.TabIndex = 0;
            this.listViewItemsQueue.UseCompatibleStateImageBehavior = false;
            this.listViewItemsQueue.View = System.Windows.Forms.View.Details;
            this.listViewItemsQueue.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewItemsQueue_ColumnClick);
            this.listViewItemsQueue.DragDrop += new System.Windows.Forms.DragEventHandler(this.listViewItemsQueue_DragDrop);
            this.listViewItemsQueue.DragEnter += new System.Windows.Forms.DragEventHandler(this.listViewItemsQueue_DragEnter);
            this.listViewItemsQueue.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listViewItemsQueue_MouseUp);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Title";
            this.columnHeader1.Width = 266;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "File Name";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 179;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Type";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 97;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Status";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 135;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listViewItemsQueue);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = " ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.contextMenuStripFocused.ResumeLayout(false);
            this.contextMenuStripNoFocus.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.CustomListView listViewItemsQueue;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxPS4IP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxServerIP;
        private System.Windows.Forms.Button buttonProcessQueue;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private Controls.CustomContextMenu contextMenuStripFocused;
        private System.Windows.Forms.CheckBox checkBoxRecursive;
        private System.Windows.Forms.Label labelConnectionDisplay;
        private System.Windows.Forms.Label labelConnectionStatus;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripMenuItem clearAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem markForUninstallToolStripMenuItem;
        private Controls.CustomProgressBar progressBar1;
        private System.Windows.Forms.Label labelProgressNotify;
        private System.Windows.Forms.ToolStripMenuItem requeueItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem themeToolStripMenuItem;
        private System.Windows.Forms.Label labelCheckDelay;
        private System.Windows.Forms.ToolTip toolTipInfo;
        private Controls.CustomContextMenu contextMenuStripNoFocus;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem markAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dLCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem patchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.LinkLabel linkLabelAddServerIp;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.LinkLabel labelSettings;
        private System.Windows.Forms.CheckBox checkBoxSkipInstallCheck;
    }
}

