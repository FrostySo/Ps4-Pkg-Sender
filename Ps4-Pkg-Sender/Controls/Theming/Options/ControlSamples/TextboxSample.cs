using Ps4_Pkg_Sender.Controls.Theming.Options.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ps4_Pkg_Sender.Controls.Theming.Options.ControlSamples {
    public class TextboxSample : IControlSample, IDisposable {
        public Color ForeColor { get { return _foreColor; } set { _foreColor = value; _textbox.ForeColor = value; } }
        public Color BackColor { get { return _backColor; } set { _backColor = value; _textbox.BackColor = value; } }
        public Font Font { get { return _font; } set { _font = value; _textbox.Font = _font; } }
        public string Text { get { return _text; } set { _text = value; _textbox.Text = _text; } }

        private string _text;
        private Color _foreColor;
        private Color _backColor;
        private Font _font;
        private TextBox _textbox;

        public TextboxSample() {
            this._textbox = new TextBox() {
                Text = "127.0.0.1",
                TextAlign = HorizontalAlignment.Left,
                BackColor = Color.White,
                ForeColor = Color.Black,
            };
        }

        public Control GetSampleControl() {
            return _textbox;
        }

        public void Dispose() {
            _font?.Dispose();
            _textbox?.Dispose();
        }
    }
}
