using System;
using System.Windows.Forms;

namespace Ps4_Pkg_Sender.Extensions {
    public static class ControlExtensions {
        public static void InvokeIfRequired(this Control control, Action action) {
            if (control.InvokeRequired) {
                control.Invoke(action);
            } else {
                action?.Invoke();
            }
        }
    }
}
