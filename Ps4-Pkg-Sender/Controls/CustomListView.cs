using System.Drawing;
using System.Windows.Forms;

namespace Ps4_Pkg_Sender.Controls {
    public class CustomListView : ListView{

        public CustomListView() {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.OwnerDraw = true;
        }

        public Color ColumnLinesColor { get { return _columnLinesColor; } set { _columnLinesColor = value; Invalidate(); Refresh(); } }
        public Color ColumnBackColor { get { return _columnBackColor; } set { _columnBackColor = value; Invalidate(); Refresh(); } }
        public Color ColumnFontColor { get { return _columnsFontColor; } set { _columnsFontColor = value; Invalidate(); Refresh(); } }

        Color _columnsFontColor= Color.White;
        Color _columnLinesColor = Color.Gray;
        Color _columnBackColor = Color.FromArgb(30, 30, 30, 30);

        protected override void OnDrawColumnHeader(DrawListViewColumnHeaderEventArgs e) {
            Color columnColor = _columnBackColor;

            using (System.Drawing.Drawing2D.LinearGradientBrush GradientBrush = new System.Drawing.Drawing2D.LinearGradientBrush(e.Bounds, columnColor, columnColor, 270)) {
                e.Graphics.FillRectangle(GradientBrush, e.Bounds);
            }

            Color linesColor = _columnLinesColor;
            using (var brush = new SolidBrush(linesColor)) {
                using (var pen = new Pen(brush)) {
                    var offset = -1;
                    var bounds = e.Bounds;
                    e.Graphics.DrawLine(pen, bounds.X, bounds.Y + bounds.Height + offset, bounds.X + bounds.Width, bounds.Y + bounds.Height + offset);
                    e.Graphics.DrawLine(pen, bounds.X, bounds.Y, bounds.X + bounds.Width, bounds.Y);
                    e.Graphics.DrawLine(pen, bounds.X, bounds.Y, bounds.X, bounds.Y + bounds.Height);
                }
            }
            TextRenderer.DrawText(e.Graphics, e.Header.Text, this.Font, e.Bounds, _columnsFontColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
        }

        protected override void OnDrawSubItem(DrawListViewSubItemEventArgs e) {
            e.DrawDefault = true;
            base.OnDrawSubItem(e);
        }

        protected override void OnDrawItem(DrawListViewItemEventArgs e) {
            e.DrawDefault = true;
            base.OnDrawItem(e);
        }
    }
}
