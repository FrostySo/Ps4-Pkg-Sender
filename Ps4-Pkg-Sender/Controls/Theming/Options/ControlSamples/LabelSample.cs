using Ps4_Pkg_Sender.Controls.Theming.Options.Interfaces;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ps4_Pkg_Sender.Controls.Theming.Options.ControlSamples {
    public class LabelSample : IControlSample, IDisposable{
        public Color ForeColor { get { return _foreColor; } set { _foreColor = value; _label.ForeColor = value; } }
        public Color BackColor { get { return _backColor; } set { _backColor = value; _label.BackColor = value; } }
        public Font Font { get { return _font; } set { _font = value; _label.Font = _font; } }
        public string Text { get { return _text; } set { _text = value;_label.Text = _text; } }

        private string _text;
        private Color _foreColor;
        private Color _backColor;
        private Font _font;
        private Label _label;
        public LabelSample() {
            this._label = new Label() {
                Text = "Sample Message",
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.White,
                AutoSize = true
            };
        }

        public Control GetSampleControl() {
            return _label;
        }

        public void Dispose() {
            _font?.Dispose();
            _label?.Dispose();
        }
    }
}
