using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ps4_Pkg_Sender.WinApi {
    public static class Win32Api {
        // offset of window style value
        public static int GWL_STYLE = -16;

        // window style constants for scrollbars
        public static int WS_VSCROLL = 0x00200000;
        public static int WS_HSCROLL = 0x00100000;

        [DllImport("user32.dll", SetLastError = true)]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);
    }
}
