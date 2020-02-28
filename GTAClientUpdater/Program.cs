using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GTAClientUpdater
{
    class Program
    {
        /// <summary>
        /// Fetches a file via webclient>
        /// </summary>
        /// <param name="url">The file URL.</param>
        /// <returns>string data.</returns>
        public static string GetFileViaHttpString(string url)
        {
            using (var client = new WebClient())
            {
                return client.DownloadString(url);
            }
        }

        /// <summary>
        /// Fetches update file size.
        /// </summary>
        /// <param name="uriPath"></param>
        /// <returns></returns>
        private static string GetFileSize()
        {
            var webRequest = HttpWebRequest.Create(UpdateData.DownloadURL);
            webRequest.Method = "HEAD";

            using (var webResponse = webRequest.GetResponse())
            {
                var fileSize = webResponse.Headers.Get("Content-Length");
                var fileSizeInMegaByte = Math.Round(Convert.ToDouble(fileSize) / 1024.0 / 1024.0, 2);
                return fileSizeInMegaByte + " MB";
            }
        }

        /// <summary>
        /// Fetches the json file from the web and parses it.
        /// </summary>
        private static void FetchVersion()
        {
            ConsoleWrapper.PrintMessage("Fetching master list from: http://www.vanilla-remastered.com/files/client.json",
                ConsoleWrapper.PrintStatus.Normal);

            var versionObjRaw = GetFileViaHttpString("http://www.vanilla-remastered.com/files/client.json");
            var update = JsonConvert.DeserializeObject<UpdateData>(versionObjRaw);
        }

        public static bool IsClientRunning()
        {
            var pname = Process.GetProcessesByName("VanillaUpdater");
            if (pname.Length == 0) return false;
            return true;
        }

        /// <summary>
        /// Checks if the application exists in the first place.
        /// </summary>
        /// <returns></returns>
        public static bool isWorkSpaceValid()
        {
            if(File.Exists("VanillaUpdater.exe"))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Spits out new changes.
        /// </summary>
        public static void ListChanges()
        {
            int count = 0;

            foreach(var item in UpdateData.Changes)
            {
                count++;

                string outputStr = String.Format("[{0}] * {1}",
                    count, item);

                Console.WriteLine(outputStr);
            }
        }

        static void Main(string[] args)
        {
            ConsoleWrapper.PrintAsciiSignature();
            ConsoleWrapper.PrintMessage("Starting GTA Client updater ...", ConsoleWrapper.PrintStatus.Normal);

            if (!isWorkSpaceValid())
            {
                ConsoleWrapper.PrintMessage("Updater is not placed in the right directory. \n" +
                    "Updater can't find 'VanillaUpdater.exe' in the current directory. Stopping ...", ConsoleWrapper.PrintStatus.Error);
                return;
            }

            ConsoleWrapper.PrintMessage("Fetching application data ...", ConsoleWrapper.PrintStatus.Normal);

            var versionInfo = FileVersionInfo.GetVersionInfo("VanillaUpdater.exe");

            FetchVersion();
            string version = versionInfo.FileVersion;

            Console.WriteLine("--------------");

            if(UpdateData.Version != version)
            {
                ConsoleWrapper.PrintMessage("New version is available for installation! ", ConsoleWrapper.PrintStatus.GreenNotif);
                ListChanges();

                Console.WriteLine("Are you ready to update now? File contains " + GetFileSize());
            }
        }
    }
}
