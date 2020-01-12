using Newtonsoft.Json;
using System;
using System.ComponentModel;
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
                MessageBox.Show("The download has been cancelled");
                return;
            }

            if (e.Error != null) // We have an error! Retry a few times, then abort.
            {
                MessageBox.Show("An error ocurred while trying to download file");

                return;
            }

            MessageBox.Show("File succesfully downloaded");
            InstallUpdate();

        }

        private static void InstallUpdate()
        {

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
        }
    }
