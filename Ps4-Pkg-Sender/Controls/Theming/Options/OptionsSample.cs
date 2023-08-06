using Ps4_Pkg_Sender.Controls.Theming.Options.Interfaces;
using Ps4_Pkg_Sender.Controls.Theming.Options.Setting;
using System.Drawing;

namespace Ps4_Pkg_Sender.Controls.Theming.Options {
    public class OptionsSample {
        protected RenderOption RenderOption { get; set; }

        private IControlSample _controlSample;

        public OptionsSample(IControlSample controlSample) {
            this._controlSample = controlSample;
        }

    }
}
