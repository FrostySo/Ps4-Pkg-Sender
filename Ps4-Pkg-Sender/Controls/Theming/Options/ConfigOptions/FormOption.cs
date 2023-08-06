using Ps4_Pkg_Sender.Controls.Theming.Options.ControlSamples;

namespace Ps4_Pkg_Sender.Controls.Theming.Options.ConfigOptions {
    public class FormOption : EditableOption {
        public FormOption() : base("Forms", new FormSample(), new SelectableOption("BackColor", "Back Color", SelectableOption.OptionType.Color)) {

        }
    }
}
