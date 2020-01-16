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
    class Updater
    {
        public static string GetFileViaHttpString(string url)
        {
            using (WebClient client = new WebClient())
            {
                return client.DownloadString(url);
            }
        }

        private static void FetchVersion()
        {
            var versionObjRaw = GetFileViaHttpString("http://www.vanilla-remastered.com/files/latest.json");
            UpdateData update = JsonConvert.DeserializeObject<UpdateData>(versionObjRaw);
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

            DirectoryInfo di = Directory.CreateDirectory(destinationDirectoryName);
            string destinationDirectoryFullPath = di.FullName;

            foreach (ZipArchiveEntry file in archive.Entries)
            {
                string completeFileName = Path.GetFullPath(Path.Combine(destinationDirectoryFullPath, file.FullName));

                if (!completeFileName.StartsWith(destinationDirectoryFullPath, StringComparison.OrdinalIgnoreCase))
                {
                    throw new IOException("Trying to extract file outside of destination directory. See this link for more info: https://snyk.io/research/zip-slip-vulnerability");
                }

                if (file.Name.Length == 0)
                {// Assuming Empty for Directory
                    Directory.CreateDirectory(Path.GetDirectoryName(completeFileName));
                    continue;
                }
                file.ExtractToFile(completeFileName, true);
            }
        }

        public static void InstallUpdate()
        {
            if (Directory.Exists("update")) Directory.Delete("update", true);

            try
            {
                string extractionPath = VRegistry.GetSubKeyValue("Path").ToString().Replace("/", "\\");

                ZipArchive archive = ZipFile.OpenRead("data_" + UpdateData.Version + ".rar");
                ExtractToDirectory(archive, extractionPath, true);

                //File.Delete("data_" + UpdateData.Version + ".rar");
            }
            catch (Exception e)
            {
                MessageBox.Show("Failed to install the update due to an exception that.\n" +
                    "ERR_CODE: " + e.Message, "An error occured");
                return;
            }

            Analytics.TrackEvent("Update has been installed!", new Dictionary<string, string> {
                { "Version", UpdateData.Version }
            });

            VRegistry.CreateSubKey("Version", UpdateData.Version);
            Notifications.PlayNotificationSound();
        }

        public static double ConvertBytesToMegabytes(long bytes)
        {
            double result = (bytes / 102f) / 1024f;
            return Convert.ToInt32(result);
        }

    }
    [DataContract]
    class UpdateData
    {
        [DataMember]
        public static string Version { get; set; }

        [DataMember]
        public static string Author { get; set; }

        [DataMember]
        public static string[] Changes { get; set; }

        [DataMember]
        public static DateTime Date { get; set; }

        [DataMember]
        public static string[] AffectedFiles { get; set; }

        [DataMember]
        public static string DownloadURL { get; set; }

        [DataMember]
        public static string SupportURL { get; set; }
    }
}
