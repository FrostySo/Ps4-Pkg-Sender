using Ps4_Pkg_Sender.Controls.Theming.Options.Interfaces;
using Ps4_Pkg_Sender.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Ps4_Pkg_Sender.Controls.Theming.Options {
    public class EditableOption : IDisposable {

        //Had a change of mind so this was the easier way :(
        public bool HasFont { get; protected set; }
        public SelectableOption FontOption { get; protected set; }

        public string DisplayText { get; protected set; }
        public IControlSample ControlSample { get; private set; }
        public IReadOnlyList<SelectableOption> AllSelectableOptions => SelectableOptions;

        protected List<SelectableOption> SelectableOptions = new List<SelectableOption>();

        public ThemeItem ThemeItem { get; set; }

        public EditableOption(string displayText, IControlSample controlSample){
            this.DisplayText = displayText;
            this.ControlSample = controlSample;
            SelectableOptions.AddRange(new SelectableOption[] {
                new SelectableOption("ForeColor","Fore Color",SelectableOption.OptionType.Color),
                new SelectableOption("BackColor","Back Color", SelectableOption.OptionType.Color),
            });
        }

        public EditableOption(string displayText, IControlSample controlSample, params SelectableOption[] selectableOptions) {
            this.DisplayText = displayText;
            this.ControlSample = controlSample;
            this.SelectableOptions.AddRange(selectableOptions);
        }

        protected void InsertSelectableItemBeforeEnd(SelectableOption selectableOption) {
            this.SelectableOptions.Insert(SelectableOptions.Count - 1, selectableOption);
        }

        public void UpdateControlSample(Size panelSize) {
            var control = ControlSample.GetSampleControl();
            if(control != null) {
                foreach(var option in SelectableOptions) {
                    if (option.Value == null) continue;
                    Utilities.ReflectionUtil.ChangeVaue(control, option.PropertyName, option.Value);
                }
            }
            CenterControl(control,panelSize);
        }


        private void CenterControl(Control control,Size panelSize) {
            control.Location = new Point(
              panelSize.Width / 2 - control.Width / 2,
              panelSize.Height / 2 - control.Height / 2
          );
        }

        public void LoadSetting() {
            if (ThemeItem == null) return;
            foreach (var selectableOption in SelectableOptions) {
                if (ThemeItem.Values.ContainsKey(selectableOption.PropertyName)) {
                    selectableOption.Value = ThemeItem.Values[selectableOption.PropertyName];
                }
            }
        }

        public void SaveSetting() {
            if (ThemeItem == null) return;
            foreach (var selectableOption in SelectableOptions) {
                if (ThemeItem.Values.ContainsKey(selectableOption.PropertyName)) {
                    ThemeItem.Values[selectableOption.PropertyName] = selectableOption.Value;
                }
            }
        }



        public void Dispose() {
            ControlSample.Dispose();
        }
    }
}
