using Ps4_Pkg_Sender.Controls.Theming.Options.Interfaces;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ps4_Pkg_Sender.Controls.Theming.Options.ControlSamples {
    public class LinkLabelSample : IControlSample, IDisposable  {
        public Color ForeColor { get { return _foreColor; } set { _foreColor = value; _linkLabel.ForeColor = value; } }
        public Color BackColor { get { return _backColor; } set { _backColor = value; _linkLabel.BackColor = value; } }
        public Color HoverColor { get { return _linkColor; } set { _linkColor = value; _linkLabel.LinkColor = value; } }
        public Color VisitedLinkcolor { get { return _visitedLinkColor; } set { _visitedLinkColor = value; _linkLabel.VisitedLinkColor= value; } }
        public Font Font { get { return _font; } set { _font = value; _linkLabel.Font = _font; } }

        LinkLabel _linkLabel;
        private Color _foreColor;
        private Color _backColor;
        private Color _visitedLinkColor;
        private Color _linkColor;
        private Font _font;

        public LinkLabelSample() {
            _linkLabel = new LinkLabel() {
                Text = "Sample Label",
                FlatStyle = FlatStyle.Flat,
                TextAlign = ContentAlignment.MiddleCenter,
                Size = new Size(139, 28)
            };
        }

        public void Dispose() {
            _font?.Dispose();
            _linkLabel?.Dispose();
        }

        public Control GetSampleControl() {
            return _linkLabel;
        }
    }
}
