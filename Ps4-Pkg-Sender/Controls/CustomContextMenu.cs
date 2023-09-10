using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Ps4_Pkg_Sender.Controls {
    public class CustomContextMenu : ContextMenuStrip{

        public Color FocusColor { get { return _focusColor; } set {
                _focusColor = value;
                this.Invalidate();
            }
        }

        public Color BorderColor {
            get { return _borderColor; }
            set {
                _borderColor = value;
                this.Invalidate();
            }
        }

        public Color ArrowColor {
            get { return _arrowColor; }
            set {
                _arrowColor = value;
                this.Invalidate();
            }
        }

        public Color ArrowFocusColor {
            get { return _arrowColorSelected; }
            set {
                _arrowColorSelected = value;
                this.Invalidate();
            }
        }

        public Color LeftSideBackColor {
            get { return _leftSideBackColor; }
            set {
                _leftSideBackColor = value;
                this.Invalidate();
                this.ApplyMenuStripTheme();
            }
        }


        ColorTable colorTable;

        Color _leftSideBackColor;
        Color _arrowColor;
        Color _arrowColorSelected;
        Color _focusColor;
        Color _borderColor;
        public CustomContextMenu() {
            InitializeColors();
        }

        private void InitializeColors() {
            colorTable = new ColorTable(this);
            this.BackColor = Color.FromArgb(27, 27, 28);
            this.ForeColor = Color.FromArgb(241, 241, 241);
            this._focusColor = Color.FromArgb(51, 51, 52);
            this._borderColor = Color.FromArgb(51, 51, 52);
            this._leftSideBackColor = _borderColor;
            this._arrowColor = Color.White;
            this._arrowColorSelected = SystemColors.MenuHighlight;
            this.Renderer = new Theming.CustomMenuStripRenderer(this, colorTable);
            this.ItemAdded += CustomContextMenu_ItemAdded;
        }

        public CustomContextMenu(IContainer container) : base(container) {
            InitializeColors();
        }


        private void CustomContextMenu_ItemAdded(object sender, ToolStripItemEventArgs e) {
            ApplyMenuStripTheme();
        }

        public class ColorTable : ProfessionalColorTable {
         

            CustomContextMenu contextMenuStrip;
            public ColorTable(CustomContextMenu contextMenuStrip) {
                this.contextMenuStrip = contextMenuStrip;
                this.UseSystemColors = false;
            }

            private Color _menuBorderColor => contextMenuStrip.BorderColor;
            private Color _menuFocusBackcolor => contextMenuStrip.FocusColor;
            private Color _menuColorBackcolor => contextMenuStrip.BackColor;

            private Color _imageColor => contextMenuStrip.LeftSideBackColor;

            public override Color MenuBorder => _menuBorderColor;
            public override Color MenuItemBorder => _menuBorderColor;
            public override Color MenuItemSelected => _menuFocusBackcolor;

            public override Color ToolStripDropDownBackground => _menuColorBackcolor;

            public override Color ToolStripContentPanelGradientBegin => _menuColorBackcolor;
            public override Color ToolStripContentPanelGradientEnd => _menuColorBackcolor;

            public override Color ToolStripGradientMiddle => _menuColorBackcolor;

            public override Color ToolStripGradientBegin => _menuColorBackcolor;
            public override Color ToolStripGradientEnd => _menuColorBackcolor;
            public override Color ToolStripPanelGradientBegin => _menuColorBackcolor;
            public override Color ToolStripPanelGradientEnd => _menuColorBackcolor;
            public override Color ToolStripBorder => _menuBorderColor;
            public override Color ImageMarginGradientBegin => _imageColor;
            public override Color ImageMarginGradientMiddle => _imageColor;
            public override Color ImageMarginGradientEnd => _imageColor;
        }

        public void ApplyMenuStripTheme() {
            SetContextMenuStripColors(this, BackColor, ForeColor);
            Invalidate();
        }

        public void SetContextMenuStripColors(ToolStripDropDown menu, Color backColor, Color foreColor) {
            foreach (ToolStripItem item in menu.Items) {
                item.BackColor = backColor;
                item.ForeColor = foreColor;
                if (item is ToolStripMenuItem && ((ToolStripMenuItem)item).DropDownItems.Count > 0) {
                    SetContextMenuStripColors(((ToolStripMenuItem)item).DropDown, backColor, foreColor);
                }
            }
        }


    }
}
