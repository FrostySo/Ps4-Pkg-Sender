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


        [Category("ProgressBar")]
        [Description("The color of the progress bar")]
        public Color Color {
            get { return progressColor; }
            set {
                progressColor = value;
                if(_brush != null) {
                    _brush.Dispose();
                }
                _brush = new SolidBrush(progressColor);
                Invalidate();
            }
        }

        [Description("The Font of the text")]
        public Font Font {
            get { return font; }
            set {
                if(font != null) {
                    font.Dispose();
                }
                font = value;
                Invalidate();
            }
        }

        private Color progressColor = Color.Green;

        private Font font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        private Brush _brush = Brushes.Green;

        public long SecondsRemaining { get; set; } = 0;

        public string ExtraText { get; set; } = null;

        public CustomProgressBar() {
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
            e.Graphics.FillRectangle(Brushes.Gray, 0, 0, Width, rect.Height);
            e.Graphics.FillRectangle(_brush, 0, 0, rec.Width, rec.Height);
            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            String estimatedTime = SecondsRemaining > 0 ? $"- Time left: {Utilities.TimeFormatUtil.GetCountdownFormat(SecondsRemaining,false)}" : "";
            if (ExtraText != null) {
                estimatedTime += ExtraText;
            }
            e.Graphics.DrawString($"{this.Value}% {estimatedTime}", this.font, Brushes.White,this.Width / 2, this.Height / 2,sf);
        }
    }
}
