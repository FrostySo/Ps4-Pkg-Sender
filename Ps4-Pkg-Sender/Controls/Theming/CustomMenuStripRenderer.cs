using System.Windows.Forms;

namespace Ps4_Pkg_Sender.Controls.Theming {
    public class CustomMenuStripRenderer : ToolStripProfessionalRenderer{
        CustomContextMenu customContextMenu;

        public CustomMenuStripRenderer(CustomContextMenu customContextMenu, ProfessionalColorTable colorTable) : base(colorTable) {
            this.customContextMenu = customContextMenu;
        }

        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e) {
            if (e.Item.Selected) {
                e.ArrowColor = customContextMenu.ArrowFocusColor;
            } else {
                e.ArrowColor = customContextMenu.ArrowColor;
            }
            base.OnRenderArrow(e);
        }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e) {
            base.OnRenderToolStripBorder(e);
        }

    }
}
