using System;
using System.Windows.Forms;

namespace Ps4_Pkg_Sender {
    public partial class AddServerIpForm : Form {

        public string IP { get; internal set; }
        public AddServerIpForm() {
            InitializeComponent();
        }

        public static bool IsValidIP(string ip) {
            return !String.IsNullOrEmpty(ip) && System.Text.RegularExpressions.Regex.IsMatch(ip, @"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}");
        }

        private void buttonAddIp_Click(object sender, EventArgs e) {
            if (IsValidIP(textBoxIP.Text)) {
                this.IP = textBoxIP.Text;
                this.DialogResult = DialogResult.OK;
            } else {
                MessageBox.Show(this, "Please enter a valid ip!");
            }
        }
    }
}
