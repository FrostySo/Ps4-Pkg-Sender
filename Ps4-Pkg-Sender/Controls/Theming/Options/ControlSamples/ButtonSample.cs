using Ps4_Pkg_Sender.Controls.Theming.Options.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ps4_Pkg_Sender.Controls.Theming.Options.ControlSamples {
    public class ButtonSample : IControlSample, IDisposable {
        public Color ForeColor { get { return _foreColor; } set { _foreColor = value; _button.ForeColor = value; } }
        public Color BackColor { get { return _backColor; } set { _backColor = value; _button.BackColor = value; } }
        public Color HoverColor { get { return _hovercolor; } set { _hovercolor = value; _button.FlatAppearance.MouseOverBackColor = value; } }
        public Color ClickColor { get { return _clickColor; } set { _clickColor = value; _button.FlatAppearance.MouseDownBackColor = value; } }
        public Font Font { get { return _font; } set { _font = value; _button.Font = _font; } }

        Button _button;
        private Color _foreColor;
        private Color _backColor;
        private Color _clickColor;
        private Color _hovercolor;
        private Font _font;
        public ButtonSample() {
            _button = new Button() {
                Text = "Sample button",
                FlatStyle = FlatStyle.Flat,
                UseVisualStyleBackColor = true,
                TextAlign = ContentAlignment.MiddleCenter,
                Size = new Size(139, 28)
            };
            _button.FlatAppearance.BorderSize = 0;
        }

        public void Dispose() {
            _font?.Dispose();
            _button?.Dispose();
        }

        public Control GetSampleControl() {
            return _button;
        }
    }
}
