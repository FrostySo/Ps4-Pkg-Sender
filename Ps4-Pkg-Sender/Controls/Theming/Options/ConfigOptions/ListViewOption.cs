using Ps4_Pkg_Sender.Controls.Theming.Options.ControlSamples;
using Ps4_Pkg_Sender.Controls.Theming.Options.Interfaces;
using Ps4_Pkg_Sender.UI;

namespace Ps4_Pkg_Sender.Controls.Theming.Options.ConfigOptions {
    public class ListViewOption : FontedOption {
        public ListViewOption() : base("ListViews", new ListViewSample()) {
            this.SelectableOptions[0].DisplayText = "Font Color";
            InsertSelectableItemBeforeEnd(new SelectableOption(ListViewThemeItem.ColBackColorStr, "Column Back Color", SelectableOption.OptionType.Color));
            InsertSelectableItemBeforeEnd(new SelectableOption(ListViewThemeItem.ColLinesColorStr, "Column Lines Color", SelectableOption.OptionType.Color));
            InsertSelectableItemBeforeEnd(new SelectableOption(ListViewThemeItem.ColFontColorStr, "Column Font Color", SelectableOption.OptionType.Color));
        }
    }
}
