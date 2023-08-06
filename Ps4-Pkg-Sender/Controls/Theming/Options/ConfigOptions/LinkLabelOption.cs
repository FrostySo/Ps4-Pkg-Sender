using Ps4_Pkg_Sender.Controls.Theming.Options.ControlSamples;

namespace Ps4_Pkg_Sender.Controls.Theming.Options.ConfigOptions {
    public class LinkLabelOption : FontedOption {
        public LinkLabelOption() : base("Link Labels", new LinkLabelSample()) {
            InsertSelectableItemBeforeEnd(new SelectableOption("LinkColor", "Link Color", SelectableOption.OptionType.Color));
            InsertSelectableItemBeforeEnd(new SelectableOption("VisitedLinkColor", "Visited Link Color", SelectableOption.OptionType.Color));
            InsertSelectableItemBeforeEnd(new SelectableOption("ActiveLinkColor", "Active Link Color", SelectableOption.OptionType.Color));
        }
    }
}
