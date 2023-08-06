using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Ps4_Pkg_Sender.Controls {
    public class FlatNumericUpDown : NumericUpDown {

        private Color borderColor = Color.FromArgb(122,122,122);

        [DefaultValue(typeof(Color), "Gray")]
        public Color BorderColor {
            get { return borderColor; }
            set {
                if (borderColor != value) {
                    borderColor = value;
                    Invalidate();
                }
            }
        }
        private Color buttonHighlightColor = Color.LightGray;

        [DefaultValue(typeof(Color), "LightGray")]
        public Color ButtonHighlightColor {
            get { return buttonHighlightColor; }
            set {
                if (buttonHighlightColor != value) {
                    buttonHighlightColor = value;
                    Invalidate();
                }
            }
        }

        private Color buttonArrowColor = Color.LightGray;

        [DefaultValue(typeof(Color), "Black")]
        public Color ButtonArrowColor {
            get { return buttonArrowColor; }
            set {
                if (buttonArrowColor != value) {
                    buttonArrowColor = value;
                    renderer.ArrowColor = buttonArrowColor;
                    Invalidate();
                    Refresh();
                }
            }
        }

        internal void ForceUpdate() {
            this.UpdateEditText();
        }

        UpDownButtonRenderer renderer;
        public FlatNumericUpDown() : base() {
            renderer = new UpDownButtonRenderer(Controls[0]);
            renderer.ArrowColor = ButtonArrowColor;
        }

        protected override CreateParams CreateParams {
            get {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED       
                return cp;
            }
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            if (BorderStyle == BorderStyle.FixedSingle) {
                using (var pen = new Pen(BorderColor, 1)) {
                    e.Graphics.DrawRectangle(pen,
                        ClientRectangle.Left, ClientRectangle.Top,
                        ClientRectangle.Width - 1, ClientRectangle.Height - 1);
                }
            }
        }
        private class UpDownButtonRenderer : NativeWindow {
            [DllImport("user32.dll", ExactSpelling = true, EntryPoint = "BeginPaint", CharSet = CharSet.Auto)]
            private static extern IntPtr IntBeginPaint(IntPtr hWnd, [In, Out] ref PAINTSTRUCT lpPaint);
            [StructLayout(LayoutKind.Sequential)]
            public struct PAINTSTRUCT {
                public IntPtr hdc;
                public bool fErase;
                public int rcPaint_left;
                public int rcPaint_top;
                public int rcPaint_right;
                public int rcPaint_bottom;
                public bool fRestore;
                public bool fIncUpdate;
                public int reserved1;
                public int reserved2;
                public int reserved3;
                public int reserved4;
                public int reserved5;
                public int reserved6;
                public int reserved7;
                public int reserved8;
            }
            [DllImport("user32.dll", ExactSpelling = true, EntryPoint = "EndPaint", CharSet = CharSet.Auto)]
            private static extern bool IntEndPaint(IntPtr hWnd, ref PAINTSTRUCT lpPaint);

            public Color ArrowColor { get; set; } = Color.Black;
            Control updown;
            public UpDownButtonRenderer(Control c) {
                this.updown = c;
                if (updown.IsHandleCreated)
                    this.AssignHandle(updown.Handle);
                else
                    updown.HandleCreated += (s, e) => this.AssignHandle(updown.Handle);
            }
            private Point[] GetDownArrow(Rectangle r) {
                var middle = new Point(r.Left + r.Width / 2, r.Top + r.Height / 2);
                return new Point[]
                {
                new Point(middle.X - 3, middle.Y - 2),
                new Point(middle.X + 4, middle.Y - 2),
                new Point(middle.X, middle.Y + 2)
                };
            }
            private Point[] GetUpArrow(Rectangle r) {
                var middle = new Point(r.Left + r.Width / 2, r.Top + r.Height / 2);
                return new Point[]
                {
                new Point(middle.X - 4, middle.Y + 2),
                new Point(middle.X + 4, middle.Y + 2),
                new Point(middle.X, middle.Y - 3)
                };
            }
            protected override void WndProc(ref Message m) {
                if (m.Msg == 0xF /*WM_PAINT*/ && ((FlatNumericUpDown)updown.Parent).BorderStyle == BorderStyle.FixedSingle) {
                    var s = new PAINTSTRUCT();
                    IntBeginPaint(updown.Handle, ref s);
                    using (var g = Graphics.FromHdc(s.hdc)) {
                        var enabled = updown.Enabled;
                        using (var backBrush = new SolidBrush(enabled ? ((FlatNumericUpDown)updown.Parent).BackColor : SystemColors.Control)) {
                            g.FillRectangle(backBrush, updown.ClientRectangle);
                        }
                        var r1 = new Rectangle(0, 0, updown.Width, updown.Height / 2);
                        var r2 = new Rectangle(0, updown.Height / 2, updown.Width, updown.Height / 2 + 1);
                        var p = updown.PointToClient(MousePosition);
                        if (enabled && updown.ClientRectangle.Contains(p)) {
                            using (var b = new SolidBrush(((FlatNumericUpDown)updown.Parent).ButtonHighlightColor)) {
                                if (r1.Contains(p))
                                    g.FillRectangle(b, r1);
                                else
                                    g.FillRectangle(b, r2);
                            }

                        }

                        using (var pen = new Pen(((FlatNumericUpDown)updown.Parent).BorderColor)) {
                            g.DrawLines(pen, new[] { new Point(0, 0), new Point(0, updown.Height),
                                    //new Point(0, updown.Height / 2), new Point(updown.Width, updown.Height / 2)
                                });
                        }
                        using (var brush = new SolidBrush(ArrowColor)) {
                            //g.FillPolygon(Brushes.Black, GetUpArrow(r1));
                            g.FillPolygon(brush, GetUpArrow(r1));
                            g.FillPolygon(brush, GetDownArrow(r2));
                        }

                    }
                    m.Result = (IntPtr)1;
                    base.WndProc(ref m);
                    IntEndPaint(updown.Handle, ref s);
                } else if (m.Msg == 0x0014/*WM_ERASEBKGND*/) {
                    using (var g = Graphics.FromHdcInternal(m.WParam))
                        g.FillRectangle(Brushes.White, updown.ClientRectangle);
                    m.Result = (IntPtr)1;
                } else
                    base.WndProc(ref m);
            }
        }
    }
}
