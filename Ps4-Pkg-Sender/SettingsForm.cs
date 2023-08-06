using Ps4_Pkg_Sender.UI;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ps4_Pkg_Sender {
    public partial class SettingsForm : Form {
        MainForm _mainForm;
        public SettingsForm(MainForm mainForm) {
            this._mainForm = mainForm;
            InitializeComponent();
            this.flatNumericUpDownCheckDelay.Value = MainForm.Settings.ProgressCheckDelay;
            this.checkBoxFinishedQueueSound.Checked= MainForm.Settings.SoundSettings.PlayQueueFinishSound;
            this.checkBoxPlayOnError.Checked= MainForm.Settings.SoundSettings.PlaySoundOnError;
        }

        private void SettingsForm_Load(object sender, EventArgs e) {
            Themer.ApplyTheme(this);
        }

        private void linkLabelThemeOptions_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            var appearanceOptionsForm = new AppearanceOptionsForm();
            if(appearanceOptionsForm.ShowDialog() == DialogResult.OK) {
                Themer.ApplyTheme(appearanceOptionsForm.ThemeSettings,_mainForm);
                Themer.ApplyTheme(appearanceOptionsForm.ThemeSettings,this);
                Themer.SaveTheme();
            }
        }

        private void flatNumericUpDownCheckDelay_ValueChanged(object sender, EventArgs e) {
            MainForm.Settings.ProgressCheckDelay = (int)flatNumericUpDownCheckDelay.Value;
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e) {
            MainForm.Settings.SoundSettings.PlaySoundOnError = checkBoxPlayOnError.Checked;
            MainForm.Settings.SoundSettings.PlayQueueFinishSound = checkBoxFinishedQueueSound.Checked;
            _mainForm.SaveSettings();
        }
    }
}
