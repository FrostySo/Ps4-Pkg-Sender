using Ps4_Pkg_Sender.Controls.Theming.Options.ControlSamples;

namespace Ps4_Pkg_Sender.Controls.Theming.Options.ConfigOptions {
    public class ProgressbarOption : FontedOption {
        public ProgressbarOption(): base("Progressbars", new ProgressbarSample()) {
            InsertSelectableItemBeforeEnd(new SelectableOption("FontColor", "Font Color", SelectableOption.OptionType.Color));
        }
    }
}
