using Ps4_Pkg_Sender.Controls.Theming.Options.Interfaces;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ps4_Pkg_Sender.Controls.Theming.Options.ControlSamples {
    public class FormSample : IControlSample, IDisposable {
        public Color BackColor { get { return _backColor; } set { _backColor = value; _form.BackColor = value; } }

        private Color _backColor;
        private Form _form;

        public FormSample() {
            this._form = new Form() {
                BackColor = Color.FromArgb(30, 30, 30),
                Text = "Example Form",
                Dock = DockStyle.Fill,
                TopLevel = false,
            };
            _form.Show();
        }

        public Control GetSampleControl() {
            return _form;
        }

        public void Dispose() {
            _form?.Dispose();
        }
    }
}
