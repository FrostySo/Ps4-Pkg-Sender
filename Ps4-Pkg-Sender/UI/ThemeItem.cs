using Newtonsoft.Json;
using Ps4_Pkg_Sender.Json.Converters;
using System.Collections.Generic;
using System.Drawing;

namespace Ps4_Pkg_Sender.UI {
    public class ThemeItem {
        public string Name { get; private set; }

        public class ThemeItempropertyInfo {

            public string DisplayText { get; set; }
            public string PropertyName { get; set; }
            public Controls.Theming.Options.SelectableOption.OptionType OptionType { get; set; }

            public ThemeItempropertyInfo(string displayText, string propertyName, Controls.Theming.Options.SelectableOption.OptionType optionType) {
                this.PropertyName = propertyName;
                this.DisplayText = displayText;
                this.OptionType = optionType;
            }

            public ThemeItempropertyInfo(string propertyName, Controls.Theming.Options.SelectableOption.OptionType optionType) {
                this.PropertyName = propertyName;
                this.DisplayText = propertyName;
                this.OptionType = optionType;
            }
        }

        [JsonIgnore]
        public Color ForeColor => (Color)Values["ForeColor"];

        [JsonIgnore]
        public Color BackColor => (Color)Values["BackColor"];

        [JsonProperty("Values")]
        [JsonConverter(typeof(DictionaryConverter))]
        public readonly Dictionary<string, object> Values = new Dictionary<string, object>();
        public ThemeItem(string name) {
            this.Name = name;
            Values.Add($"BackColor",Color.Transparent);
            Values.Add($"ForeColor",Color.Empty);
            Values.Add($"Font", new Font("Microsoft Sans Serif", 9f, FontStyle.Regular));
        }

        public ThemeItem(string name, params KeyValuePair<string,object>[] keyValuePairs) {
            this.Name = name;
            foreach(var kvp in keyValuePairs) {
                Values.Add(kvp.Key, kvp.Value);
            }
        }
    }
}
