using Newtonsoft.Json;
using Ps4_Pkg_Sender.Ps4;

namespace Ps4_Pkg_Sender.Models {
    public class QueueItemInfo {

        [JsonProperty("PkgInfo")]
        public PkgInfo PkgInfo { get; set; }

        [JsonProperty("Uninstall")]
        public bool Uninstall { get; set; }
    
    }
}
