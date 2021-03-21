using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ps4_Pkg_Sender.Exceptions {
    public class ServerInitializationException : Exception {
        public ServerInitializationException(string message) : base(message) {
        }
    }
}
