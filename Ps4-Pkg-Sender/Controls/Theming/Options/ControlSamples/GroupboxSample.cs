using Ps4_Pkg_Sender.Controls.Theming.Options.Interfaces;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ps4_Pkg_Sender.Controls.Theming.Options.ControlSamples {
    public class GroupboxSample : IControlSample, IDisposable {
        public Color ForeColor { get { return _foreColor; } set { _foreColor = value; _groupbox.ForeColor = value; } }
        public Color BackColor { get { return _backColor; } set { _backColor = value; _groupbox.BackColor = value; } }
        public Font Font { get { return _font; } set { _font = value; _groupbox.Font = _font; } }
        public string Text { get { return _text; } set { _text = value; _groupbox.Text = _text; } }

        private string _text;
        private Color _foreColor;
        private Color _backColor;
        private Font _font;
        private GroupBox _groupbox;

        public GroupboxSample() {
            this._groupbox = new GroupBox() {
                Text = "GroupBox",
                BackColor = Color.White,
                ForeColor = Color.Black,
            };
        }

        public Control GetSampleControl() {
            return _groupbox;
        }

        public void Dispose() {
            _font?.Dispose();
            _groupbox?.Dispose();
        }
    }
}
