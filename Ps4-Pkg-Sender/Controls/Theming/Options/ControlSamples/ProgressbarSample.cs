using Ps4_Pkg_Sender.Controls.Theming.Options.Interfaces;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ps4_Pkg_Sender.Controls.Theming.Options.ControlSamples {
    public class ProgressbarSample : IControlSample, IDisposable {
        public Color ForeColor { get { return _foreColor; } set { _foreColor = value; _progrssBar.ForeColor = value; } }
        public Color BackColor { get { return _backColor; } set { _backColor = value; _progrssBar.BackColor = value; } }
        public Font Font { get { return _font; } set { _font = value; _progrssBar.Font = _font; } }

        CustomProgressBar _progrssBar;
        private Color _foreColor;
        private Color _backColor;
        private Font _font;
        public ProgressbarSample() {
            _progrssBar = new CustomProgressBar() {
                Size = new Size(260, 50),
                Value = 50,
                ExtraText = "5min 24sec"
            };
        }

        public void Dispose() {
            _font?.Dispose();
            _progrssBar?.Dispose();
        }

        public Control GetSampleControl() {
            return _progrssBar;
        }
    }
}
