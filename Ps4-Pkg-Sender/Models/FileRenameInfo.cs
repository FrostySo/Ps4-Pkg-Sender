using Newtonsoft.Json;

namespace Ps4_Pkg_Sender.Models {
    public class FileRenameInfo {
        [JsonProperty("CurrentName")]
        public string CurrentName { get; set; }

        [JsonProperty("WantedName")]
        public string WantedName { get; set; }

        [JsonProperty("CurrentPath")]
        public string CurrentPath { get; set; }
    }
}
