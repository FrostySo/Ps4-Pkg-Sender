using Ps4_Pkg_Sender.Controls.Theming.Options;
using Ps4_Pkg_Sender.Controls.Theming.Options.ConfigOptions;
using Ps4_Pkg_Sender.Controls.Theming.Options.ControlSamples;
using Ps4_Pkg_Sender.Json;
using Ps4_Pkg_Sender.UI;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Ps4_Pkg_Sender {
    public partial class AppearanceOptionsForm : Form {

        public ThemeSettings ThemeSettings { get; private set; } = new ThemeSettings();

        EditableOption _selectedOption;

        SelectableOption _selectedSelectableOption;

        readonly EditableOption[] Options = {
            new ListViewOption(),
            new BigLabelOption(),
            new SmallLabelOption(),
            new CheckboxOption(),
            new LabelOption("Connected Label","Connected"),
            new LabelOption("Disconnected Label","Not Connected"),
            new ProgressbarOption(),
            new ButtonOption(),
            new NumericUpDownOption(),
            new LinkLabelOption(),
            new TextboxOption(),
            new GroupboxOption(),
            new FormOption(),
            new ContextMenuOption()
        };

        private void LoadCurrentSettings() {
            var options = Options.ToDictionary(n => n.DisplayText, y => y);
            var themeItemsList = ThemeSettings
                .GetType()
                .GetProperties()
                .Where(p => p.PropertyType == typeof(ThemeItem) || p.PropertyType?.BaseType == typeof(ThemeItem))
                .Select(p => (ThemeItem)p.GetValue(ThemeSettings))
                .ToArray();

            foreach(var themeItem in themeItemsList) {
                if (options.TryGetValue(themeItem.Name, out var option)) {
                    option.ThemeItem = themeItem;
                    option.LoadSetting();
                }
            }
        }

        private void SaveCurrentSettings() {
            foreach(var option in Options) {
                option.SaveSetting();
            }
        }

        public AppearanceOptionsForm() {
            InitializeComponent();
            this.ThemeSettings = Themer.ThemeSettings;
            LoadCurrentSettings();
            this.FormClosing += AppearanceOptionsForm_FormClosing;
            this.panelSamplePanel.Paint += PanelSamplePanel_Paint;
            comboBoxFonts.DataSource = System.Drawing.FontFamily.Families.ToList();
            this.listBoxOptions.DataSource = Options;
            this.listBoxOptions.DisplayMember = nameof(EditableOption.DisplayText);
            this.listBoxOptions.SelectedIndex = 0;
            this.comboBoxFonts.SelectedIndexChanged += new System.EventHandler(this.comboBoxFonts_SelectedIndexChanged);
            this.flatNumericUpDownSizes.ValueChanged += new System.EventHandler(this.flatNumericUpDown1_ValueChanged);
            this.checkBoxBold.CheckedChanged += CheckBoxBold_CheckedChanged;
        }

        private void CheckBoxBold_CheckedChanged(object sender, System.EventArgs e) {
            UpdateFontChoice();
        }

        private void AppearanceOptionsForm_FormClosing(object sender, FormClosingEventArgs e) {
            for(int i = 0; i < Options.Length; ++i) {
                Options[i].Dispose();
            }
        }

        private void UpdateFontChoice() {
            if (_selectedOption.HasFont) {
                if (_selectedOption.FontOption.Value != null) {
                    var oldFont = _selectedOption.FontOption.Value as Font;
                    //oldFont.Dispose();
                }
                FontFamily fontFamily = this.comboBoxFonts.SelectedItem as FontFamily;
                _selectedOption.FontOption.Value = new Font(fontFamily, (float)this.flatNumericUpDownSizes.Value, this.checkBoxBold.Checked ? FontStyle.Bold : FontStyle.Regular);
                _selectedOption.UpdateControlSample(panelSamplePanel.Size);
            }
        }

        private void CenterControl(Control control) {
            control.Location = new Point(
              panelSamplePanel.Width / 2 - control.Width / 2,
              panelSamplePanel.Height / 2 - control.Height / 2
          );
        }

        private void PanelSamplePanel_Paint(object sender, PaintEventArgs e) {
            var rect = new Rectangle(0, 0, panelSamplePanel.Size.Width, panelSamplePanel.Size.Height);
            using (Pen pen2 = new Pen(Color.FromArgb(122,122,122), 2)) {
                e.Graphics.DrawRectangle(pen2, rect);
            }
            panelSamplePanel.BackColor = BackColor;
        }

        private void comboBoxFonts_DrawItem(object sender, DrawItemEventArgs e) {
            var comboBox = (ComboBox)sender;
            if (e.Index == -1) return;
            var fontFamily = (FontFamily)comboBox.Items[e.Index];
            using (var font = new Font(fontFamily, comboBox.Font.SizeInPoints)) {
                e.DrawBackground();
                e.Graphics.DrawString(font.Name, font, Brushes.White, e.Bounds.X, e.Bounds.Y);
            }
        }

        private void HideAllSelectableOptions() {
            this.buttonColor.Visible = false;
        }

        private void comboBoxPropertySelection_SelectedIndexChanged(object sender, System.EventArgs e) {
            if (comboBoxPropertySelection.SelectedIndex == -1) return;
            var selectedModifiableOption = _selectedOption.AllSelectableOptions[comboBoxPropertySelection.SelectedIndex] as SelectableOption;
            if (selectedModifiableOption != null) {
                _selectedSelectableOption = selectedModifiableOption;
                var displayFontSettings = _selectedOption.HasFont;
                labelFont.Visible = displayFontSettings;
                comboBoxFonts.Visible = displayFontSettings;
                flatNumericUpDownSizes.Visible = displayFontSettings;
                labelSize.Visible = displayFontSettings;

                HideAllSelectableOptions();
                switch (selectedModifiableOption.Type) {
                    case SelectableOption.OptionType.Color:
                        this.buttonColor.Visible = true;
                        this.labelSelectableValue.Text = "Item Color:";
                        this.buttonColor.BackColor = (Color)selectedModifiableOption.Value;
                        break;

                    case SelectableOption.OptionType.Font:
                        SelectFont(selectedModifiableOption.Value as Font);
                        break;

                }
                _selectedOption.UpdateControlSample(panelSamplePanel.Size);
            }
        }

        private void NewOptionSelected() {
            panelSamplePanel.Controls.Clear();
            var control = _selectedOption.ControlSample.GetSampleControl();
            panelSamplePanel.Controls.Add(control);
           
            CenterControl(control);
            if (control is Controls.CustomContextMenu contextMenuSample) {
                contextMenuSample.BringToFront();
                contextMenuSample.Show(control.Location);
            }
            SelectFont(_selectedOption.FontOption?.Value as Font);
            if (_selectedOption.AllSelectableOptions.Count > 0) {
                comboBoxPropertySelection.Items.Clear();
                for(int i = 0; i < _selectedOption.AllSelectableOptions.Count; ++i) {
                    var option = _selectedOption.AllSelectableOptions[i];
                    if (option.Type == SelectableOption.OptionType.Font) continue;
                    comboBoxPropertySelection.Items.Add(option.DisplayText);
                }
                comboBoxPropertySelection.SelectedIndex = 0;
            }
        }

        private void SelectFont(Font font) {
            if (font == null) return;
            var index = this.comboBoxFonts.FindStringExact(font.FontFamily.ToString());
            if(index != -1) {
                this.comboBoxFonts.SelectedIndex = index;
                flatNumericUpDownSizes.Value = (decimal)font.Size;
                this.checkBoxBold.Checked = font.Bold;
            }
        }

        private void listBoxOptions_SelectedIndexChanged(object sender, System.EventArgs e) {
            if (listBoxOptions.SelectedIndex == -1) return;
            _selectedOption = listBoxOptions.SelectedItem as EditableOption;
            if(_selectedOption != null) {
                NewOptionSelected();
            }
        }

        private void buttonOk_Click(object sender, System.EventArgs e) {
            SaveCurrentSettings();
            Themer.ThemeSettings = ThemeSettings;
            this.DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, System.EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
        }

        private void flatNumericUpDown1_ValueChanged(object sender, System.EventArgs e) {
            UpdateFontChoice();
        }

        private void comboBoxFonts_SelectedIndexChanged(object sender, System.EventArgs e) {
            UpdateFontChoice();
        }

        private void buttonColor_Click(object sender, System.EventArgs e) {
            if(_selectedSelectableOption != null) {
                var colorDialog = new ColorDialog();
                if(colorDialog.ShowDialog() == DialogResult.OK) {
                    buttonColor.BackColor = colorDialog.Color;
                    _selectedSelectableOption.Value = colorDialog.Color;
                    _selectedOption.UpdateControlSample(panelSamplePanel.Size);
                }
            }
        }


        private void buttonResetThemeToDefaults_Click(object sender, System.EventArgs e) {
            if(MessageBox.Show("This will reset all your themes to default. Press Ok to Continue", "Are you sure?", MessageBoxButtons.OKCancel) == DialogResult.OK) {
                ThemeSettings = new ThemeSettings();
                LoadCurrentSettings();
                if(_selectedSelectableOption != null) {
                    _selectedSelectableOption.Value = _selectedOption.ThemeItem.Values[_selectedSelectableOption.PropertyName];
                    _selectedOption.UpdateControlSample(panelSamplePanel.Size);
                    if(_selectedSelectableOption.Value is Color c) {
                        buttonColor.BackColor = c;
                    }
                }
            
            }
        }


        private void buttonColorInherit_Click(object sender, System.EventArgs e) {
            if (!buttonColorInherit.Visible) return;
            if (_selectedSelectableOption == null) return;
            if (_selectedOption == null) return;
            buttonColor.BackColor = Color.Empty;
            _selectedSelectableOption.Value = Color.Empty;
            _selectedOption.UpdateControlSample(panelSamplePanel.Size);
        }
    }
}
