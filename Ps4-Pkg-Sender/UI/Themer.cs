using Newtonsoft.Json;
using Ps4_Pkg_Sender.Controls;
using Ps4_Pkg_Sender.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Ps4_Pkg_Sender.UI {
    public class Themer {

        const string ThemeFile = "themesettings.json";
        public static ThemeSettings ThemeSettings = new ThemeSettings();

        public static void LoadTheme() {
            if (File.Exists(ThemeFile)) {
                try {
                    ThemeSettings = JsonConvert.DeserializeObject<ThemeSettings>(File.ReadAllText(ThemeFile));
                } catch {

                }
            }
        }

        public static bool SaveTheme() {
            try {
                File.WriteAllText(ThemeFile,JsonConvert.SerializeObject(ThemeSettings, Formatting.Indented));
                return true;
            } catch {

            }
            return false;
        }


        public static void ApplyTheme(ThemeSettings themeSettings,Form form) {
            form.SuspendLayout();
            ApplyThemeToLabel(form,themeSettings.BigLabels,"Big");
            ApplyThemeToLabel(form, themeSettings.SmallLabels, "Small");
            ApplyThemeToLabel(form, themeSettings.ConnectedLabel, "cLabel");
            ApplyThemeTo<CheckBox>(form, themeSettings.Checkboxes);
            ApplyThemeTo<ProgressBar>(form, themeSettings.ProgressBar);
            ApplyThemeTo<Button>(form, themeSettings.Buttons);
            ApplyThemeTo<LinkLabel>(form, themeSettings.LinkLabels);
            ApplyThemeTo<TextBox>(form, themeSettings.Textboxes);
            ApplyThemeTo<GroupBox>(form, themeSettings.Groupboxes);
            ApplyThemeTo<FlatNumericUpDown>(form, themeSettings.NumericUpDowns);
            ApplyThemeTo<Form>(form, themeSettings.Forms);
            ApplyThemeTo<CustomListView>(form, themeSettings.ListViews);
            form.ResumeLayout();
        }

        public static void ApplyTheme(Form form) {
            form.SuspendLayout();
            ApplyTheme(ThemeSettings, form);
            form.ResumeLayout();
        }

        private static Control[] GetAllControls(Form form) {
            List<Control> controls = new List<Control>();
            GetAllControls(form, controls,false);
            return controls.ToArray();
        }

        private static void GetAllControls(Control container, List<Control> controlList, bool recursive) {
            BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
            FieldInfo[] fields = container.GetType().GetFields(flags);
            controlList.Add(container);
            foreach (FieldInfo field in fields) {
                if (typeof(Control).IsAssignableFrom(field.FieldType)) {
                    Control control = field.GetValue(container) as Control;
                    if (control != null) {
                        controlList.Add(control);

                        if (recursive && control.HasChildren)
                            GetAllControls(control, controlList,recursive);
                    }
                }
            }
        }

        private static void ApplyThemeTo<T> (Form form,ThemeItem themeItem) where T : Control{
            Control[] controls = GetAllControls(form)
             .OfType<T>()
             .ToArray();
            foreach (var control in controls) {
                if (control.Tag != null && control.Tag.ToString().Equals("ignore",StringComparison.OrdinalIgnoreCase)) continue;
                foreach (var kvp in themeItem.Values) {
                    Utilities.ReflectionUtil.ChangeVaue(control, kvp.Key, kvp.Value);
                }
            }
        }

        private static void ApplyThemeToLabel(Form form, ThemeItem themeItem,string labelSize) {
            Label[] labels = GetAllControls(form)
                .OfType<Label>()
                .Where(n => n.Tag?.ToString() == labelSize)
                .ToArray();
            foreach(var label in labels) {
                foreach(var kvp in themeItem.Values) {
                    var property = label.GetType().GetProperty(kvp.Key);
                    property.SetValue(label, kvp.Value);
                }
            }
        }
    }
}
