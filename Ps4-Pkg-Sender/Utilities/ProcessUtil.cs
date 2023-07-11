using System;
using System.Diagnostics;
using System.Management;

namespace Ps4_Pkg_Sender.Utilities {
    public class ProcessUtil {
        public static void KillProcessAndChildren(int pid) {
            // Cannot close 'system idle process'.
            if (pid == 0) {
                return;
            }

            ManagementObjectSearcher searcher = new ManagementObjectSearcher
                    ("Select * From Win32_Process Where ParentProcessID=" + pid);
            ManagementObjectCollection moc = searcher.Get();
            foreach (ManagementObject mo in moc) {
                KillProcessAndChildren(Convert.ToInt32(mo["ProcessID"]));
            }
            try {
                Process proc = Process.GetProcessById(pid);
                if (!proc.HasExited) {
                    Console.WriteLine("Trying to kill process: " + proc.Id + ":" + proc.ProcessName);
                    proc.Kill();
                }

            } catch (ArgumentException) {    // Process already exited.
            } catch (Exception e) { //Incase anything else happens
            }
        }
    }
}
