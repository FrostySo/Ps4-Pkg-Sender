namespace Ps4_Pkg_Sender {
    partial class SettingsForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxSoundSettings = new System.Windows.Forms.GroupBox();
            this.checkBoxPlayOnError = new System.Windows.Forms.CheckBox();
            this.checkBoxFinishedQueueSound = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.linkLabelThemeOptions = new System.Windows.Forms.LinkLabel();
            this.flatNumericUpDownCheckDelay = new Ps4_Pkg_Sender.Controls.FlatNumericUpDown();
            this.groupBoxSoundSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flatNumericUpDownCheckDelay)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Tag = "Small";
            this.label1.Text = "Check Delay (s)";
            // 
            // groupBoxSoundSettings
            // 
            this.groupBoxSoundSettings.Controls.Add(this.checkBoxPlayOnError);
            this.groupBoxSoundSettings.Controls.Add(this.checkBoxFinishedQueueSound);
            this.groupBoxSoundSettings.ForeColor = System.Drawing.Color.White;
            this.groupBoxSoundSettings.Location = new System.Drawing.Point(15, 69);
            this.groupBoxSoundSettings.Name = "groupBoxSoundSettings";
            this.groupBoxSoundSettings.Size = new System.Drawing.Size(210, 70);
            this.groupBoxSoundSettings.TabIndex = 3;
            this.groupBoxSoundSettings.TabStop = false;
            this.groupBoxSoundSettings.Text = "Sound Settings";
            // 
            // checkBoxPlayOnError
            // 
            this.checkBoxPlayOnError.AutoSize = true;
            this.checkBoxPlayOnError.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxPlayOnError.Location = new System.Drawing.Point(10, 44);
            this.checkBoxPlayOnError.Name = "checkBoxPlayOnError";
            this.checkBoxPlayOnError.Size = new System.Drawing.Size(131, 17);
            this.checkBoxPlayOnError.TabIndex = 4;
            this.checkBoxPlayOnError.Text = "Sound On Queue Error";
            this.checkBoxPlayOnError.UseVisualStyleBackColor = true;
            // 
            // checkBoxFinishedQueueSound
            // 
            this.checkBoxFinishedQueueSound.AutoSize = true;
            this.checkBoxFinishedQueueSound.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxFinishedQueueSound.Location = new System.Drawing.Point(10, 21);
            this.checkBoxFinishedQueueSound.Name = "checkBoxFinishedQueueSound";
            this.checkBoxFinishedQueueSound.Size = new System.Drawing.Size(131, 17);
            this.checkBoxFinishedQueueSound.TabIndex = 3;
            this.checkBoxFinishedQueueSound.Text = "Finished Queue Sound";
            this.checkBoxFinishedQueueSound.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(156, 188);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 42);
            this.button1.TabIndex = 19;
            this.button1.Tag = "Ignore";
            this.button1.Text = "FrostySo";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // linkLabelThemeOptions
            // 
            this.linkLabelThemeOptions.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(116)))), ((int)(((byte)(12)))));
            this.linkLabelThemeOptions.AutoSize = true;
            this.linkLabelThemeOptions.LinkColor = System.Drawing.Color.White;
            this.linkLabelThemeOptions.Location = new System.Drawing.Point(55, 163);
            this.linkLabelThemeOptions.Name = "linkLabelThemeOptions";
            this.linkLabelThemeOptions.Size = new System.Drawing.Size(113, 13);
            this.linkLabelThemeOptions.TabIndex = 20;
            this.linkLabelThemeOptions.TabStop = true;
            this.linkLabelThemeOptions.Text = "Configure Appearance";
            this.linkLabelThemeOptions.VisitedLinkColor = System.Drawing.SystemColors.ButtonHighlight;
            this.linkLabelThemeOptions.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelThemeOptions_LinkClicked);
            // 
            // flatNumericUpDownCheckDelay
            // 
            this.flatNumericUpDownCheckDelay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.flatNumericUpDownCheckDelay.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.flatNumericUpDownCheckDelay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flatNumericUpDownCheckDelay.ButtonArrowColor = System.Drawing.Color.LightGray;
            this.flatNumericUpDownCheckDelay.ForeColor = System.Drawing.Color.White;
            this.flatNumericUpDownCheckDelay.Location = new System.Drawing.Point(129, 30);
            this.flatNumericUpDownCheckDelay.Name = "flatNumericUpDownCheckDelay";
            this.flatNumericUpDownCheckDelay.Size = new System.Drawing.Size(70, 20);
            this.flatNumericUpDownCheckDelay.TabIndex = 21;
            this.flatNumericUpDownCheckDelay.ValueChanged += new System.EventHandler(this.flatNumericUpDownCheckDelay_ValueChanged);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(235, 225);
            this.Controls.Add(this.flatNumericUpDownCheckDelay);
            this.Controls.Add(this.linkLabelThemeOptions);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBoxSoundSettings);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsForm_FormClosing);
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.groupBoxSoundSettings.ResumeLayout(false);
            this.groupBoxSoundSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flatNumericUpDownCheckDelay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxSoundSettings;
        private System.Windows.Forms.CheckBox checkBoxPlayOnError;
        private System.Windows.Forms.CheckBox checkBoxFinishedQueueSound;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.LinkLabel linkLabelThemeOptions;
        private Controls.FlatNumericUpDown flatNumericUpDownCheckDelay;
    }
}