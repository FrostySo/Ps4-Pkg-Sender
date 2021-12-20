using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace Ps4_Pkg_Sender.Utilities {
    public static class NodeJSUtil {

        public static Process[] GetNodeProcesses() {
            return Process.GetProcesses()
                .Where(n => n.ProcessName.ToLower().Equals("node"))
                .ToArray();
        }

        public static bool IsNodeJsInstalled() {
            return ExecuteCMD("npm", "npm <command>");
        }

        public static bool IsHttpServerInstalled() {
            return ExecuteCMD("http-server -v", @"^v\d+.\d+.\d+");
        }

        public static bool InstallHttpServer() {
            return ExecuteCMD("npm install http-server -g", @"added \d+ packages|\+ http-server");
        }

        public static void KillAllNodeJSInstances() {
            GetNodeProcesses().ToList().ForEach(p => {
                p.Kill();
                Logger.WriteLine($"Killed node process {p.Id}",Logger.Type.DebugOutput);
            });
        }

        private static bool ExecuteCMD(string argument,string expectedOutputRegexPattern, bool strict = false) {
            var cmdProcess = new Process();
            cmdProcess.StartInfo.FileName = "cmd.exe";
            cmdProcess.StartInfo.Arguments = $"/C {argument}";
            cmdProcess.StartInfo.UseShellExecute = false;
            cmdProcess.StartInfo.CreateNoWindow = true;
            cmdProcess.StartInfo.RedirectStandardOutput = true;
            cmdProcess.Start();
            cmdProcess.WaitForExit();
            var item = cmdProcess.StandardOutput.ReadToEnd();
            if (item == null) return false;
            var regexOptions = RegexOptions.Multiline | RegexOptions.CultureInvariant;
            if (!strict) {
                regexOptions |= RegexOptions.IgnoreCase;
            }
            return Regex.IsMatch(item, expectedOutputRegexPattern, regexOptions);
        }
    }
}
