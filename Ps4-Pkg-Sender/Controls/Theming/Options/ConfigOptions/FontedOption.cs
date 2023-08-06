using System.Linq;
using Ps4_Pkg_Sender.Controls.Theming.Options.Interfaces;

namespace Ps4_Pkg_Sender.Controls.Theming.Options.ConfigOptions {
    public class FontedOption : EditableOption {
        public FontedOption(string displayText, IControlSample controlSample) : base(displayText, controlSample) {
            this.SelectableOptions.Add(new SelectableOption("Font", SelectableOption.OptionType.Font));
            this.FontOption = SelectableOptions.Last();
            this.HasFont = true;
        }
    }
}
