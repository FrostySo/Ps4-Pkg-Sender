using Newtonsoft.Json;
using System.IO;

namespace Ps4_Pkg_Sender.Json {
    public class SoundSettings {

        [JsonProperty("PlayQueueFinishSound")]
        public bool PlayQueueFinishSound { get; set; }

        [JsonProperty("PlayErrorSound")]
        public bool PlaySoundOnError{ get; set; }

        public static void PlayCompleteSound() {
            PlaySound(Properties.Resources.Complete);
        }

        public static void PlayErrorSound() {
            PlaySound(Properties.Resources.Error);
        }

        private static void PlaySound(Stream stream) {
            using (System.Media.SoundPlayer snd = new System.Media.SoundPlayer(stream)) {
                snd.Play();
            }
        }
    }
}
