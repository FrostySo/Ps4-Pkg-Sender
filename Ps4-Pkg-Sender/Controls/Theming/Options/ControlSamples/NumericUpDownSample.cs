using Ps4_Pkg_Sender.Controls.Theming.Options.Interfaces;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ps4_Pkg_Sender.Controls.Theming.Options.ControlSamples {
    public class NumericUpDownSample : IControlSample, IDisposable {
        public Color ForeColor { get { return _foreColor; } set { _foreColor = value; numericUpDown.ForeColor = value; } }
        public Color BackColor { get { return _backColor; } set { _backColor = value; numericUpDown.BackColor = value; } }
        public Font Font { get { return _font; } set { _font = value; numericUpDown.Font = _font; } }
        public string Text { get { return _text; } set { _text = value; numericUpDown.Text = _text; } }

        private string _text;
        private Color _foreColor;
        private Color _backColor;
        private Font _font;
        private FlatNumericUpDown numericUpDown;
        public NumericUpDownSample() {
            this.numericUpDown = new FlatNumericUpDown() {
                ForeColor = Color.White,
                AutoSize = true,
                BorderStyle = BorderStyle.FixedSingle
            };
        }

        public Control GetSampleControl() {
            return numericUpDown;
        }

        public void Dispose() {
            _font?.Dispose();
            numericUpDown?.Dispose();
        }
    }
}
