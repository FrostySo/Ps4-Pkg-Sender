namespace Ps4_Pkg_Sender {
    partial class AddServerIpForm {
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
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAddIp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxIP
            // 
            this.textBoxIP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxIP.Location = new System.Drawing.Point(106, 24);
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new System.Drawing.Size(318, 20);
            this.textBoxIP.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 20);
            this.label1.TabIndex = 4;
            this.label1.Tag = "Big";
            this.label1.Text = "Server IP:";
            // 
            // buttonAddIp
            // 
            this.buttonAddIp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonAddIp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(116)))), ((int)(((byte)(12)))));
            this.buttonAddIp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonAddIp.FlatAppearance.BorderSize = 0;
            this.buttonAddIp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddIp.ForeColor = System.Drawing.Color.White;
            this.buttonAddIp.Location = new System.Drawing.Point(174, 51);
            this.buttonAddIp.Name = "buttonAddIp";
            this.buttonAddIp.Size = new System.Drawing.Size(95, 25);
            this.buttonAddIp.TabIndex = 5;
            this.buttonAddIp.Text = "Add";
            this.buttonAddIp.UseVisualStyleBackColor = false;
            this.buttonAddIp.Click += new System.EventHandler(this.buttonAddIp_Click);
            // 
            // AddServerIpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(436, 79);
            this.Controls.Add(this.buttonAddIp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxIP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddServerIpForm";
            this.Text = "AddServerIpForm";
            this.Load += new System.EventHandler(this.AddServerIpForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAddIp;
        private System.Windows.Forms.TextBox textBoxIP;
    }
}