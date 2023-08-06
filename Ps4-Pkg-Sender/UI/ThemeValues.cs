using System.Drawing;

namespace Ps4_Pkg_Sender.UI {
    public class ThemeValues {

        public ThemeItem BigLabels = new ThemeItem("BigLabels");
        public ThemeItem SmallLabels = new ThemeItem("SmallLabels");
        public ThemeItem Checkboxes = new ThemeItem("Checkboxs");
        public ThemeItem ConnectedLabel = new ThemeItem("ConnectedLabel");
        public ThemeItem DisconnectedLabel = new ThemeItem("DisconnectedLabel");

        public ThemeItem ProgressBar = new ThemeItem("Progressbars",
            new System.Collections.Generic.KeyValuePair<string, object>("BackColor",Color.Empty),
            new System.Collections.Generic.KeyValuePair<string, object>("ForeColor",Color.Empty),
            new System.Collections.Generic.KeyValuePair<string, object>("SecondsLeftColor",Color.Empty)
        );

        public ThemeItem LinkLabels = new ThemeItem("LinkLabels",
            new System.Collections.Generic.KeyValuePair<string, object>("BackColor", Color.Transparent),
            new System.Collections.Generic.KeyValuePair<string, object>("ForeColor", SystemColors.ButtonHighlight),
            new System.Collections.Generic.KeyValuePair<string, object>("LinkColor", Color.White),
            new System.Collections.Generic.KeyValuePair<string, object>("VisitedLinkColor", SystemColors.ButtonHighlight),
            new System.Collections.Generic.KeyValuePair<string, object>("Font", new Font("Microsoft Sans Serif",9f,FontStyle.Bold))
        );
    }
}
