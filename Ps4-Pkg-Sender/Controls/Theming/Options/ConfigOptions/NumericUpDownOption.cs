using Ps4_Pkg_Sender.Controls.Theming.Options.ControlSamples;

namespace Ps4_Pkg_Sender.Controls.Theming.Options.ConfigOptions {
    public class NumericUpDownOption : FontedOption {
        public NumericUpDownOption() : base("NumericUpDowns", new NumericUpDownSample()) {
            InsertSelectableItemBeforeEnd(new SelectableOption("BorderColor", "Border Color", SelectableOption.OptionType.Color));
            InsertSelectableItemBeforeEnd(new SelectableOption("ButtonArrowColor", "Button Arrow Color", SelectableOption.OptionType.Color));
            InsertSelectableItemBeforeEnd(new SelectableOption("ButtonHighlightColor", "Button Highlight Color", SelectableOption.OptionType.Color));
        }
    }
}
