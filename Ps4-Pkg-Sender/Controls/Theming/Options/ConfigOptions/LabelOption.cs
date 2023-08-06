using Ps4_Pkg_Sender.Controls.Theming.Options.ControlSamples;

namespace Ps4_Pkg_Sender.Controls.Theming.Options.ConfigOptions {
    public class LabelOption : FontedOption {
        protected LabelOption() : base("Labels", new LabelSample()) {

        }

        public LabelOption(string name) : base(name,new LabelSample()){

        }

        public LabelOption(string name, string sampleText) : base (name,new LabelSample() { Text = sampleText }) {

        }
    }
}
