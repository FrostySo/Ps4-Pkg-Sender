using Newtonsoft.Json;

namespace Ps4_Pkg_Sender.Json {
    public class Ps4Progress {

        [JsonProperty("status")]
        public string Status;

        [JsonProperty("bits")]
        public int Bits;

        [JsonProperty("error")]
        public int Error;

        [JsonProperty("length")]
        public long Length;

        [JsonProperty("transferred")]
        public long Transferred;

        [JsonProperty("length_total")]
        public long LengthTotal;

        [JsonProperty("transferred_total")]
        public long TransferredTotal;

        [JsonProperty("num_index")]
        public int NumIndex;

        [JsonProperty("num_total")]
        public int NumTotal;

        [JsonProperty("rest_sec")]
        public long RestSec;

        [JsonProperty("rest_sec_total")]
        public long RestSecTotal;

        [JsonProperty("preparing_percent")]
        public int PreparingPercent;

        [JsonProperty("local_copy_percent")]
        public int LocalCopyPercent;
    }
}
