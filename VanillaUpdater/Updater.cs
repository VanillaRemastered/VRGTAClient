using MaterialSkin.Controls;
using Microsoft.AppCenter.Analytics;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

            if (VRegistry.GetSubKeyValue("Version") == null) VRegistry.CreateSubKey("Version", "0.0.0");
            if (VRegistry.GetSubKeyValue("Version").ToString() != UpdateData.Version)
                return true;
            return false;
        }

        public static void DownloadUpdate()
        {
            string url = UpdateData.DownloadURL;

            using (WebClient wc = new WebClient())
            {
                wc.DownloadProgressChanged += Wc_DownloadProgressChanged;
                wc.DownloadFileCompleted += Wc_DownloadFileCompleted;

                wc.DownloadFileAsync(new Uri(url), "data_" + UpdateData.Version + ".rar");
            }
        }

        private static void Wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                Analytics.TrackEvent("Update has been cancelled", new Dictionary<string, string> {
                { "Version", UpdateData.Version },
                {"Error", e.Error.Message}
            });


            }

            if (e.Error != null) // We have an error! Retry a few times, then abort.
            {
                Analytics.TrackEvent("Update has failed to download", new Dictionary<string, string> {
                { "Version", UpdateData.Version },
                {"Error", e.Error.Message}
            });

                MaterialMessageBox.Show(null, "An error has occured while trying to download the update.\n" +
                                    "The logs have been automatically sent to us and we're taking a look. Try to restart the updater and download the update again!\n\n" +
                                    "If you need help, reach us via: www.support.vanilla-remastered.com (ERR_CODE: " + e.Error.Message, "FATAL ERROR", MessageBoxButtons.OK);
                return;
            }


            Analytics.TrackEvent("Update has been downloaded", new Dictionary<string, string> {
                { "Version", UpdateData.Version },
            });


            InstallUpdate();
        }

        private static void InstallUpdate()
        {
            if(Directory.Exists("update")) Directory.Delete("update", true);
            ZipFile.ExtractToDirectory("data_" + UpdateData.Version + ".rar", "update");
            File.Delete("data_" + UpdateData.Version + ".rar");

            Analytics.TrackEvent("Update has been installed!", new Dictionary<string, string> {
                { "Version", UpdateData.Version },
                { "Time", DateTime.Now.ToString()}
            });

            VRegistry.CreateSubKey("Version", UpdateData.Version);
            Notifications.PlayNotificationSound();
        }

        private static void Wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Console.WriteLine(e.ProgressPercentage + "% | " + e.BytesReceived + " bytes out of " + e.TotalBytesToReceive + " bytes retrieven.");
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
