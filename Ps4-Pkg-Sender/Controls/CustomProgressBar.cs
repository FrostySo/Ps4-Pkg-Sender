using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ps4_Pkg_Sender.Controls {
    public class CustomProgressBar : ProgressBar{

        [Description("The Font of the text")]
        public Font Font {
            get { return font; }
            set {
                font = value;
                Invalidate();
            }
        }

        [Category("ProgressBar")]
        [Description("The Font Color of the progress bar text")]
        public Color FontColor {
            get { return _fontColor; }
            set {
                _fontColor = value;
                Invalidate();
            }
        }

        private Color _fontColor  = Color.White;

        private Font font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

        public long SecondsRemaining { get; set; } = 0;

        public string ExtraText { get; set; } = null;

        public CustomProgressBar() {
            this.BackColor = Color.Gray;
            this.ForeColor = Color.FromArgb(223, 116, 12);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        public void ResetProgressBar() {
            this.Value = 0;
            this.SecondsRemaining = 0;
        }

        protected override void OnPaint(PaintEventArgs e) {
            Rectangle rec = e.ClipRectangle;

            rec.Width = (int)(rec.Width * ((double)Value / Maximum)) - 4;
            if (ProgressBarRenderer.IsSupported)
                ProgressBarRenderer.DrawHorizontalBar(e.Graphics, e.ClipRectangle);
            Rectangle rect = new Rectangle(new Point(0, 0), new Size(Maximum, rec.Height));

            using (var backColorBrush = new SolidBrush(BackColor)) {
                e.Graphics.FillRectangle(backColorBrush, 0, 0, Width, rect.Height);
            }

            using (var foreColoreBrush = new SolidBrush(ForeColor)) {
                e.Graphics.FillRectangle(foreColoreBrush, 0, 0, rec.Width, rec.Height);
            }

            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            String estimatedTime = SecondsRemaining > 0 ? $"- Time left: {Utilities.TimeFormatUtil.GetCountdownFormat(SecondsRemaining,false)}" : "";
            if (ExtraText != null) {
                estimatedTime += ExtraText;
            }

            using (var fontColorBrush = new SolidBrush(_fontColor)) {
                e.Graphics.DrawString($"{this.Value}% {estimatedTime}", this.font, fontColorBrush, this.Width / 2, this.Height / 2, sf);
            }
        }
    }
}
