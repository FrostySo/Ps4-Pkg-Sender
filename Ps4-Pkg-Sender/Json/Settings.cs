﻿using Newtonsoft.Json;

namespace Ps4_Pkg_Sender.Json {
    public class Settings {
        [JsonProperty("ServerIP")]
        public string ServerIP { get; set; } 
        [JsonProperty("Ps4IP")]
        public string Ps4IP { get; set; }
        [JsonProperty("RecursiveSearch")]
        public bool RecursiveSearch { get; set; }

        [JsonProperty("ProgressCheckDelay")]
        public int ProgressCheckDelay { get; set; } = 10;
    }
}
