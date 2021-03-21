using Ps4_Pkg_Sender.Json;
using System.Net;

namespace Ps4_Pkg_Sender.Utilities {
    public class HttpUtil {

        public static string Get(string url) {
            using (WebClient client = new WebClient()) {
                client.Encoding = System.Text.Encoding.UTF8;
                return client.DownloadString(url);
            }
        }

        public static string Post(string url, string data) {
            using (WebClient client = new WebClient()) {
                client.Encoding = System.Text.Encoding.UTF8;
                return client.UploadString(url, data);
            }
        }

        public static string GetInstallJson(string[] pkgs, string ip,int port) {
            var json = new Ps4DataPayload();
            var temp = pkgs.Clone() as string[];    
            for(int i = 0; i < temp.Length; ++i) {
                temp[i] = $"http://{ip}:{port}/{temp[i]}";
            }
            json.Packages = temp;
            json.Type = "direct";
            return Newtonsoft.Json.JsonConvert.SerializeObject(json);
        }
    }
}
