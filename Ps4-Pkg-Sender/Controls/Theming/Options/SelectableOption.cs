namespace Ps4_Pkg_Sender.Controls.Theming.Options {
    public class SelectableOption {
        public enum OptionType {
            Color,
            Font
        }

        public OptionType Type { get; private set; }
        public string DisplayText { get; set; }
        public string PropertyName { get; private set; }
        public object Value { get;  set; }

        public SelectableOption(string propertyName, string displayText, OptionType optionType) {
            this.DisplayText = displayText;
            this.PropertyName = propertyName;
            this.Type = optionType;
        }

        public SelectableOption(string propertyName, OptionType optionType) {
            this.DisplayText = propertyName;
            this.PropertyName = propertyName;
            this.Type = optionType;
        }

     
    }
}
