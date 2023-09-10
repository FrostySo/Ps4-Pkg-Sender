using Ps4_Pkg_Sender.Controls.Theming.Options.ControlSamples;

namespace Ps4_Pkg_Sender.Controls.Theming.Options.ConfigOptions {
    public class ContextMenuOption : FontedOption{
        public ContextMenuOption() : base("ContextMenu",new ContextMenuSample()) {
            InsertSelectableItemBeforeEnd(new SelectableOption("FocusColor", "Focus Color", SelectableOption.OptionType.Color));
            InsertSelectableItemBeforeEnd(new SelectableOption("BorderColor", "Border Color", SelectableOption.OptionType.Color));
            InsertSelectableItemBeforeEnd(new SelectableOption("LeftSideBackColor", "Left Side Color", SelectableOption.OptionType.Color));
            InsertSelectableItemBeforeEnd(new SelectableOption("ArrowColor", "Arrow Color", SelectableOption.OptionType.Color));
            InsertSelectableItemBeforeEnd(new SelectableOption("ArrowFocusColor", "Arrow Focus Color", SelectableOption.OptionType.Color));
        }
    }
}
