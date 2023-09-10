using Ps4_Pkg_Sender.UI;
using System.Collections.Generic;
using System.Drawing;

namespace Ps4_Pkg_Sender.Json {
    public class ThemeSettings {

        public ThemeItem BigLabels { get; set; } = new ThemeItem("Big Labels",
            new KeyValuePair<string, object>("BackColor", Color.FromArgb(30,30,30)),
            new KeyValuePair<string, object>("ForeColor", SystemColors.ButtonHighlight),
            new KeyValuePair<string, object>("Font", new Font("Microsoft Sans Serif",11.25f, FontStyle.Bold))
        );

        public ThemeItem SmallLabels { get; set; } = new ThemeItem("Small Labels",
            new KeyValuePair<string, object>("BackColor", Color.FromArgb(30, 30, 30)),
            new KeyValuePair<string, object>("ForeColor", SystemColors.ButtonHighlight),
            new KeyValuePair<string, object>("Font", new Font("Microsoft Sans Serif", 9f, FontStyle.Bold))
        );

        public ThemeItem Checkboxes { get; set; } = new ThemeItem("Checkboxes",
            new KeyValuePair<string, object>("BackColor", Color.FromArgb(30, 30, 30)),
            new KeyValuePair<string, object>("ForeColor", Color.White),
            new KeyValuePair<string, object>("Font", new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular)
         ));

        public ThemeItem ConnectedLabel { get; set; } = new ThemeItem("Connected Label",
            new KeyValuePair<string, object>("BackColor", Color.FromArgb(30, 30, 30)),
            new KeyValuePair<string, object>("ForeColor", Color.Green),
            new KeyValuePair<string, object>("Font", new Font("Microsoft Sans Serif", 11.25f, FontStyle.Regular))
        );

        public ThemeItem DisconnectedLabel { get; set; }  = new ThemeItem("Disconnected Label",
              new KeyValuePair<string, object>("BackColor", Color.FromArgb(30, 30, 30)),
              new KeyValuePair<string, object>("ForeColor", Color.Red),
              new KeyValuePair<string, object>("Font", new Font("Microsoft Sans Serif", 11.25f, FontStyle.Regular)));

        public ThemeItem ProgressBar { get; set; } = new ThemeItem("Progressbars",
            new KeyValuePair<string, object>("BackColor", Color.Gray),
            new KeyValuePair<string, object>("ForeColor", Color.FromArgb(223, 116, 12)),
            new KeyValuePair<string, object>("FontColor", Color.White),
            new KeyValuePair<string, object>("Font", new Font("Microsoft Sans Serif", 11.25f, FontStyle.Bold))
        );

        public ThemeItem Buttons { get; set; } = new ThemeItem("Buttons",
            new KeyValuePair<string, object>("BackColor", Color.FromArgb(223, 116, 12)),
            new KeyValuePair<string, object>("ForeColor", Color.White),
            new KeyValuePair<string, object>("FlatAppearance.MouseOverBackColor", Color.Empty),
            new KeyValuePair<string, object>("FlatAppearance.MouseDownBackColor", Color.Empty),
            new KeyValuePair<string, object>("Font", new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular))
        );

        public ThemeItem Textboxes { get; set; } = new ThemeItem("Textboxes",
            new KeyValuePair<string, object>("BackColor", SystemColors.Window),
            new KeyValuePair<string, object>("ForeColor", SystemColors.WindowText),
            new KeyValuePair<string, object>("Font", new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular))
        );

       public ThemeItem Groupboxes { get; set; } = new ThemeItem("Groupboxes",
            new KeyValuePair<string, object>("BackColor", Color.Empty),
            new KeyValuePair<string, object>("ForeColor", Color.White),
            new KeyValuePair<string, object>("Font", new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular))
       );

        public ThemeItem LinkLabels { get; set; } = new ThemeItem("Link Labels",
            new KeyValuePair<string, object>("BackColor", Color.Empty),
            new KeyValuePair<string, object>("ForeColor", SystemColors.ButtonHighlight),
            new KeyValuePair<string, object>("LinkColor", Color.White),
            new KeyValuePair<string, object>("VisitedLinkColor", SystemColors.ButtonHighlight),
            new KeyValuePair<string, object>("ActiveLinkColor", Color.FromArgb(223, 116, 12)),
            new KeyValuePair<string, object>("Font", new Font("Microsoft Sans Serif", 9f, FontStyle.Bold))
        );

        public ThemeItem Forms { get; set; } = new ThemeItem("Forms", 
            new KeyValuePair<string, object>("BackColor", Color.FromArgb(30,30,30))
        );

        public ListViewThemeItem ListViews { get; set; } = new ListViewThemeItem();

        public ThemeItem NumericUpDowns { get; set; } = new ThemeItem("NumericUpDowns",
              new KeyValuePair<string, object>("BackColor", Color.FromArgb(40,40,40)),
              new KeyValuePair<string, object>("ForeColor", Color.White),
              new KeyValuePair<string, object>("BorderColor", Color.FromArgb(122,122,122)),
              new KeyValuePair<string, object>("ButtonArrowColor", Color.LightGray),
              new KeyValuePair<string, object>("ButtonHighlightColor", Color.FromArgb(122,122,122)),
              new KeyValuePair<string, object>("Font", new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular))
        );

        public ThemeItem ContextMenu { get; set; } = new ThemeItem("ContextMenu",
              new KeyValuePair<string, object>("BackColor", Color.FromArgb(27,27,28)),
              new KeyValuePair<string, object>("ForeColor", Color.FromArgb(241,241,241)),
              new KeyValuePair<string, object>("FocusColor", Color.FromArgb(51, 51, 52)),
              new KeyValuePair<string, object>("BorderColor", Color.FromArgb(51, 51, 52)),
              new KeyValuePair<string, object>("LeftSideBackColor", Color.FromArgb(27,27,28)),
              new KeyValuePair<string, object>("ArrowColor", Color.White),
              new KeyValuePair<string, object>("ArrowFocusColor", SystemColors.MenuHighlight)
        );
    }
}
