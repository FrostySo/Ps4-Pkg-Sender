using Newtonsoft.Json;
using System.Collections.Generic;

namespace Ps4_Pkg_Sender.Json {
    public class Ps4DataPayload {
        [JsonProperty("type")]
        public string Type;

        [JsonProperty("packages")]
        public string[] Packages;
    }
}
