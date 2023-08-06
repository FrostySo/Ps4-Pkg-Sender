using Ps4_Pkg_Sender.Controls.Theming.Options.ControlSamples;

namespace Ps4_Pkg_Sender.Controls.Theming.Options.ConfigOptions {
    public class ButtonOption : FontedOption {
        public ButtonOption() : base("Buttons", new ButtonSample()) {
            InsertSelectableItemBeforeEnd(new SelectableOption("FlatAppearance.MouseOverBackColor", "Hover Color", SelectableOption.OptionType.Color));
            InsertSelectableItemBeforeEnd(new SelectableOption("FlatAppearance.MouseDownBackColor", "Click Color", SelectableOption.OptionType.Color));
        }
    }
}
