using Ps4_Pkg_Sender.Controls.Theming.Options.Interfaces;
using System;
using System.Windows.Forms;

namespace Ps4_Pkg_Sender.Controls.Theming.Options.ControlSamples {
    public class ContextMenuSample : IControlSample, IDisposable {


        CustomContextMenu contextMenuStrip;
     
        public ContextMenuSample() {
            contextMenuStrip = new CustomContextMenu();
            contextMenuStrip.AutoClose = false;
            contextMenuStrip.Items.Add("Queue");
            var parentItem = new ToolStripMenuItem("Parent");
            parentItem.DropDownItems.Add("Child");
            var index = contextMenuStrip.Items.Add(parentItem);
            contextMenuStrip.TopLevel = false;
            contextMenuStrip.Closing += (s,e) => e.Cancel = true;
            contextMenuStrip.Visible = true;
            contextMenuStrip.Show();
        }


        public Control GetSampleControl() {
            return contextMenuStrip;
        }

        public void Dispose() {

        }
    }
}
