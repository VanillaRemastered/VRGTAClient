using Microsoft.AppCenter.Analytics;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace VanillaUpdater
{
    internal class Updater
    {
        public static string GetFileViaHttpString(string url)
        {
            using (var client = new WebClient())
            {
                return client.DownloadString(url);
            }
        }

        private static void FetchVersion()
        {
            var versionObjRaw = GetFileViaHttpString("http://www.vanilla-remastered.com/files/latest.json");
            var update = JsonConvert.DeserializeObject<UpdateData>(versionObjRaw);
        }

        public static bool IsNewVersionAvailable()
        {
            FetchVersion();

            if (VRegistry.GetSubKeyValue("Version").Equals(null)) VRegistry.CreateSubKey("Version", "0.0.0");
            if (!VRegistry.GetSubKeyValue("Version").ToString().Equals(UpdateData.Version))
                return true;
            return false;
        }

        public static void ExtractToDirectory(ZipArchive archive, string destinationDirectoryName, bool overwrite)
        {
            if (!overwrite)
            {
                archive.ExtractToDirectory(destinationDirectoryName);
                return;
            }

            var di = Directory.CreateDirectory(destinationDirectoryName);
            var destinationDirectoryFullPath = di.FullName;

            foreach (var file in archive.Entries)
            {
                var completeFileName = Path.GetFullPath(Path.Combine(destinationDirectoryFullPath, file.FullName));

                if (!completeFileName.StartsWith(destinationDirectoryFullPath, StringComparison.OrdinalIgnoreCase))
                    throw new IOException(
                        "Trying to extract file outside of destination directory. See this link for more info: https://snyk.io/research/zip-slip-vulnerability");

                if (file.Name.Length == 0)
                {
                    // Assuming Empty for Directory
                    Directory.CreateDirectory(Path.GetDirectoryName(completeFileName));
                    continue;
                }

                file.ExtractToFile(completeFileName, true);
            }
        }


        /// <summary>
        ///  removes the older version.
        /// </summary>
        /// <param name="codeName"></param>
        public static void RemoveOlderUpdate(string codeName)
        {
            if (codeName == "1.2.0")
            {
                string line;
                string path = VRegistry.GetSubKeyValue("Path").ToString();

                    // Read the file and display it line by line.  
                System.IO.StreamReader file =
                    new System.IO.StreamReader(@"test.txt");
                while ((line = file.ReadLine()) != null)
                {
                      string pathDel = path + "\\" + line;

                    if (File.Exists(pathDel))
                    {
                        File.SetAttributes(pathDel, FileAttributes.Normal);
                        File.Delete(pathDel);

                        ConsoleWrapper.PrintMessage("Deleting previous data chunk (" + pathDel + ")",
                            ConsoleWrapper.PrintStatus.Warning);
                    }
                    else ConsoleWrapper.PrintMessage("Skipping file " + pathDel, ConsoleWrapper.PrintStatus.Normal);
                }

                MessageBox.Show("removed, u may start :)");
            }
        }

        /// <summary>
        /// Installs Vanilla Remastered.
        /// </summary>
        /// <param name="codeName"></param>
        public static void InstallVanilla(string codeName)
        {

        }

        /// <summary>
        /// Attempts to install the actual update and returns true if no exceptions occured.
        /// </summary>
        /// <returns>bool</returns>
        public static bool InstallUpdate()
        {
            if (Directory.Exists("update")) Directory.Delete("update", true);

            try
            {
                var extractionPath = VRegistry.GetSubKeyValue("Path").ToString().Replace("/", "\\");

                var archive = ZipFile.OpenRead("data_" + UpdateData.Version + ".rar");
                ExtractToDirectory(archive, extractionPath, true);

                File.Delete("data_" + UpdateData.Version + ".rar");
            }
            catch (Exception e)
            {
                MessageBox.Show("Failed to install the update due to an exception that.\n" +
                                "ERR_CODE: " + e.Message, "An error occured");
                return false;
            }

            Analytics.TrackEvent("Update has been installed!", new Dictionary<string, string>
            {
                {"Version", UpdateData.Version}
            });

            VRegistry.CreateSubKey("Version", UpdateData.Version);
            return true;
            //Notifications.PlayNotificationSound();
        }

        public static double ConvertBytesToMegabytes(long bytes)
        {
            double result = bytes / 102f / 1024f;
            return Convert.ToInt32(result);
        }
    }

    [DataContract]
    internal class UpdateData
    {
        [DataMember] public static string Version { get; set; }

        [DataMember] public static string Author { get; set; }

        [DataMember] public static string[] Changes { get; set; }

        [DataMember] public static DateTime Date { get; set; }

        [DataMember] public static string[] AffectedFiles { get; set; }

        [DataMember] public static string DownloadURL { get; set; }

        [DataMember] public static string SupportURL { get; set; }
    }
}