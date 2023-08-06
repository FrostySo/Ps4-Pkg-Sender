namespace Ps4_Pkg_Sender {
    partial class AppearanceOptionsForm {
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
            this.comboBoxFonts = new System.Windows.Forms.ComboBox();
            this.labelFont = new System.Windows.Forms.Label();
            this.labelSize = new System.Windows.Forms.Label();
            this.listBoxOptions = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonResetThemeToDefaults = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.panelSamplePanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonColor = new System.Windows.Forms.Button();
            this.labelSelectableValue = new System.Windows.Forms.Label();
            this.comboBoxPropertySelection = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.flatNumericUpDownSizes = new Ps4_Pkg_Sender.Controls.FlatNumericUpDown();
            this.buttonColorInherit = new System.Windows.Forms.Button();
            this.checkBoxBold = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flatNumericUpDownSizes)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxFonts
            // 
            this.comboBoxFonts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.comboBoxFonts.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxFonts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFonts.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxFonts.ForeColor = System.Drawing.Color.White;
            this.comboBoxFonts.FormattingEnabled = true;
            this.comboBoxFonts.Location = new System.Drawing.Point(422, 52);
            this.comboBoxFonts.Name = "comboBoxFonts";
            this.comboBoxFonts.Size = new System.Drawing.Size(187, 25);
            this.comboBoxFonts.TabIndex = 3;
            this.comboBoxFonts.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.comboBoxFonts_DrawItem);
            // 
            // labelFont
            // 
            this.labelFont.AutoSize = true;
            this.labelFont.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFont.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelFont.Location = new System.Drawing.Point(419, 28);
            this.labelFont.Name = "labelFont";
            this.labelFont.Size = new System.Drawing.Size(39, 15);
            this.labelFont.TabIndex = 19;
            this.labelFont.Text = "Font:";
            // 
            // labelSize
            // 
            this.labelSize.AutoSize = true;
            this.labelSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSize.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelSize.Location = new System.Drawing.Point(630, 30);
            this.labelSize.Name = "labelSize";
            this.labelSize.Size = new System.Drawing.Size(39, 15);
            this.labelSize.TabIndex = 21;
            this.labelSize.Text = "Size:";
            // 
            // listBoxOptions
            // 
            this.listBoxOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.listBoxOptions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxOptions.ForeColor = System.Drawing.Color.White;
            this.listBoxOptions.FormattingEnabled = true;
            this.listBoxOptions.ItemHeight = 18;
            this.listBoxOptions.Location = new System.Drawing.Point(8, 15);
            this.listBoxOptions.Name = "listBoxOptions";
            this.listBoxOptions.Size = new System.Drawing.Size(395, 344);
            this.listBoxOptions.TabIndex = 22;
            this.listBoxOptions.SelectedIndexChanged += new System.EventHandler(this.listBoxOptions_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonResetThemeToDefaults);
            this.panel1.Controls.Add(this.buttonCancel);
            this.panel1.Controls.Add(this.buttonOk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 376);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(721, 58);
            this.panel1.TabIndex = 23;
            // 
            // buttonResetThemeToDefaults
            // 
            this.buttonResetThemeToDefaults.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.buttonResetThemeToDefaults.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonResetThemeToDefaults.FlatAppearance.BorderSize = 0;
            this.buttonResetThemeToDefaults.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonResetThemeToDefaults.ForeColor = System.Drawing.Color.White;
            this.buttonResetThemeToDefaults.Location = new System.Drawing.Point(12, 16);
            this.buttonResetThemeToDefaults.Name = "buttonResetThemeToDefaults";
            this.buttonResetThemeToDefaults.Size = new System.Drawing.Size(119, 28);
            this.buttonResetThemeToDefaults.TabIndex = 4;
            this.buttonResetThemeToDefaults.Text = "Reset To Defaults";
            this.buttonResetThemeToDefaults.UseVisualStyleBackColor = false;
            this.buttonResetThemeToDefaults.Click += new System.EventHandler(this.buttonResetThemeToDefaults_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.buttonCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonCancel.FlatAppearance.BorderSize = 0;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.ForeColor = System.Drawing.Color.White;
            this.buttonCancel.Location = new System.Drawing.Point(616, 16);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(94, 28);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.buttonOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonOk.FlatAppearance.BorderSize = 0;
            this.buttonOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOk.ForeColor = System.Drawing.Color.White;
            this.buttonOk.Location = new System.Drawing.Point(502, 16);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(95, 28);
            this.buttonOk.TabIndex = 2;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = false;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // panelSamplePanel
            // 
            this.panelSamplePanel.Location = new System.Drawing.Point(417, 246);
            this.panelSamplePanel.Name = "panelSamplePanel";
            this.panelSamplePanel.Size = new System.Drawing.Size(292, 113);
            this.panelSamplePanel.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(414, 227);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 15);
            this.label2.TabIndex = 25;
            this.label2.Text = "Sample:";
            // 
            // buttonColor
            // 
            this.buttonColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.buttonColor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonColor.ForeColor = System.Drawing.Color.White;
            this.buttonColor.Location = new System.Drawing.Point(491, 164);
            this.buttonColor.Name = "buttonColor";
            this.buttonColor.Size = new System.Drawing.Size(55, 28);
            this.buttonColor.TabIndex = 31;
            this.buttonColor.UseVisualStyleBackColor = false;
            this.buttonColor.Click += new System.EventHandler(this.buttonColor_Click);
            // 
            // labelSelectableValue
            // 
            this.labelSelectableValue.AutoSize = true;
            this.labelSelectableValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelectableValue.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelSelectableValue.Location = new System.Drawing.Point(419, 170);
            this.labelSelectableValue.Name = "labelSelectableValue";
            this.labelSelectableValue.Size = new System.Drawing.Size(66, 15);
            this.labelSelectableValue.TabIndex = 29;
            this.labelSelectableValue.Text = "Item Color:";
            // 
            // comboBoxPropertySelection
            // 
            this.comboBoxPropertySelection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.comboBoxPropertySelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPropertySelection.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBoxPropertySelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxPropertySelection.ForeColor = System.Drawing.Color.White;
            this.comboBoxPropertySelection.FormattingEnabled = true;
            this.comboBoxPropertySelection.Location = new System.Drawing.Point(422, 132);
            this.comboBoxPropertySelection.Name = "comboBoxPropertySelection";
            this.comboBoxPropertySelection.Size = new System.Drawing.Size(126, 23);
            this.comboBoxPropertySelection.TabIndex = 32;
            this.comboBoxPropertySelection.SelectedIndexChanged += new System.EventHandler(this.comboBoxPropertySelection_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(419, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 15);
            this.label3.TabIndex = 33;
            this.label3.Text = "Property: ";
            // 
            // flatNumericUpDownSizes
            // 
            this.flatNumericUpDownSizes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.flatNumericUpDownSizes.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.flatNumericUpDownSizes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flatNumericUpDownSizes.ButtonArrowColor = System.Drawing.Color.LightGray;
            this.flatNumericUpDownSizes.ButtonHighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.flatNumericUpDownSizes.DecimalPlaces = 2;
            this.flatNumericUpDownSizes.ForeColor = System.Drawing.Color.White;
            this.flatNumericUpDownSizes.Location = new System.Drawing.Point(630, 54);
            this.flatNumericUpDownSizes.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.flatNumericUpDownSizes.Minimum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.flatNumericUpDownSizes.Name = "flatNumericUpDownSizes";
            this.flatNumericUpDownSizes.Size = new System.Drawing.Size(76, 20);
            this.flatNumericUpDownSizes.TabIndex = 34;
            this.flatNumericUpDownSizes.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // buttonColorInherit
            // 
            this.buttonColorInherit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.buttonColorInherit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonColorInherit.FlatAppearance.BorderSize = 0;
            this.buttonColorInherit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonColorInherit.ForeColor = System.Drawing.Color.White;
            this.buttonColorInherit.Location = new System.Drawing.Point(561, 164);
            this.buttonColorInherit.Name = "buttonColorInherit";
            this.buttonColorInherit.Size = new System.Drawing.Size(95, 28);
            this.buttonColorInherit.TabIndex = 35;
            this.buttonColorInherit.Text = "No Color (inherit)";
            this.buttonColorInherit.UseVisualStyleBackColor = false;
            this.buttonColorInherit.Click += new System.EventHandler(this.buttonColorInherit_Click);
            // 
            // checkBoxBold
            // 
            this.checkBoxBold.AutoSize = true;
            this.checkBoxBold.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxBold.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxBold.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.checkBoxBold.Location = new System.Drawing.Point(630, 90);
            this.checkBoxBold.Name = "checkBoxBold";
            this.checkBoxBold.Size = new System.Drawing.Size(52, 20);
            this.checkBoxBold.TabIndex = 36;
            this.checkBoxBold.Text = "Bold";
            this.checkBoxBold.UseVisualStyleBackColor = true;
            // 
            // AppearanceOptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(721, 434);
            this.Controls.Add(this.checkBoxBold);
            this.Controls.Add(this.buttonColorInherit);
            this.Controls.Add(this.flatNumericUpDownSizes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxPropertySelection);
            this.Controls.Add(this.buttonColor);
            this.Controls.Add(this.labelSelectableValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panelSamplePanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listBoxOptions);
            this.Controls.Add(this.labelSize);
            this.Controls.Add(this.labelFont);
            this.Controls.Add(this.comboBoxFonts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AppearanceOptionsForm";
            this.Text = "Appearance Options";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.flatNumericUpDownSizes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxFonts;
        private System.Windows.Forms.Label labelFont;
        private System.Windows.Forms.Label labelSize;
        private System.Windows.Forms.ListBox listBoxOptions;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Panel panelSamplePanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonColor;
        private System.Windows.Forms.Label labelSelectableValue;
        private System.Windows.Forms.ComboBox comboBoxPropertySelection;
        private System.Windows.Forms.Label label3;
        private Controls.FlatNumericUpDown flatNumericUpDownSizes;
        private System.Windows.Forms.Button buttonResetThemeToDefaults;
        private System.Windows.Forms.Button buttonColorInherit;
        private System.Windows.Forms.CheckBox checkBoxBold;
    }
}