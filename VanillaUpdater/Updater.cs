using Microsoft.AppCenter.Analytics;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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

            if (VRegistry.GetSubKeyValue("Version") == null) VRegistry.CreateSubKey("Version", "0.0.0");
            if (VRegistry.GetSubKeyValue("Version").ToString() != UpdateData.Version)
                return true;
            return false;
        }

        public static void InstallUpdate()
        {
            if (Directory.Exists("update")) Directory.Delete("update", true);

            try
            {
                System.IO.Compression.ZipFile.ExtractToDirectory("data_" + UpdateData.Version + ".rar", "update");
                File.Delete("data_" + UpdateData.Version + ".rar");
            }
            catch (Exception e)
            {
                MessageBox.Show("Failed to install the update due to an exception that.\n" +
                    "ERR_CODE: " + e.Message, "An error occured");
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
