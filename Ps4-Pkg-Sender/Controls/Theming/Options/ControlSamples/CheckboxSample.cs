using Ps4_Pkg_Sender.Controls.Theming.Options.Interfaces;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ps4_Pkg_Sender.Controls.Theming.Options.ControlSamples {
    public class CheckboxSample : IControlSample, IDisposable {
        public Color ForeColor { get { return _foreColor; } set { _foreColor = value; _checkBox.ForeColor = value; } }
        public Color BackColor { get { return _backColor; } set { _backColor = value; _checkBox.BackColor = value; } }
        public Font Font { get { return _font; } set { _font = value; _checkBox.Font = _font; } }

        CheckBox _checkBox;
        private Color _foreColor;
        private Color _backColor;
        private Font _font;
        public CheckboxSample() {
            _checkBox = new CheckBox() {
                Text = "Sample Checkbox",
                CheckAlign = ContentAlignment.MiddleLeft,
                Checked = true,
                FlatStyle = FlatStyle.Flat,
                UseVisualStyleBackColor = true,
                TextAlign = ContentAlignment.MiddleLeft,
            };
        }

        public void Dispose() {
            _font?.Dispose();
            _checkBox?.Dispose();
        }

        public Control GetSampleControl() {
            return _checkBox;
        }
    }
}
