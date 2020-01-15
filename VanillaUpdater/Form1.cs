using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.AppCenter.Analytics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VanillaUpdater
{
    public partial class MainWindow : MaterialForm
    {
        public MaterialSkinManager MaterialSkinManager { get; set; }
        internal string downloadProgressPercent { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        public void SetUITheme(MaterialSkinManager.Themes theme) => MaterialSkinManager.Theme = theme;

        private void Form1_Load(object sender, EventArgs e)
        {
            VRegistry.CreateSubKey("Launch", ""); // create a key in case it doesn't exist.

            MaterialSkinManager = MaterialSkinManager.Instance;
            MaterialSkinManager.AddFormToManage(this);

            SetUITheme(MaterialSkinManager.Themes.LIGHT);

            if (Properties.Resources.Theme == "LIGHT") SetUITheme(MaterialSkinManager.Themes.LIGHT);
                
            MaterialSkinManager.ColorScheme = new ColorScheme(Primary.Green800, Primary.Grey900, Primary.Green700, Accent.Green700, TextShade.WHITE);

            updaterVerLbl.Text += Assembly.GetExecutingAssembly().GetName().Version.ToString();

            if(VRegistry.GetSubKeyValue("Version") != null)
                versionLabel.Text += VRegistry.GetSubKeyValue("Version").ToString();

            if (Properties.Resources.AutoUpdate == "True") updateSwitch.Checked = true;
        }

        private async void checkUpdatesBtn_Click(object sender, EventArgs e)
        {
            checkUpdatesBtn.Enabled = false;
            updaterVerLbl.Text = "Checking for updates ... please wait";

            var updateCheck = Task.Run(() => Updater.IsNewVersionAvailable());

            await Task.WhenAll(updateCheck);

            if (updateCheck.Result)
            {
                CreateUpdateUI();
                checkUpdatesBtn.Enabled = true;
                updaterVerLbl.Text = "Updater version: " + Assembly.GetExecutingAssembly().GetName().Version.ToString();

            }
            else MaterialMessageBox.Show("No update available at this time!");
        }

        private void CreateUpdateUI()
        {
            Size = new Size(Size.Width, 516); // extends the bottom part

            versionAvailableLbl.Text = UpdateData.Version + " is now available for installation!";

            changesBox.BackColor = Color.DarkSeaGreen;

            foreach(var cleanerobj in UpdateData.Changes) changesBox.Items.Remove(cleanerobj);

            foreach (var item in UpdateData.Changes)
            {
                changesBox.Items.Add(item);
            }
            System.Diagnostics.Process.Start(UpdateData.SupportURL);

            Notifications.PlayNotificationSound();
        }

        public void CleanUpdateUI()
        {
            
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            checkUpdatesBtn.Enabled = false;
            updateBtn.Enabled = false;

            if (File.Exists("data_" + UpdateData.Version + ".rar")) Updater.InstallUpdate();
            else DownloadUpdate();

        }

        public void DownloadUpdate()
        {
            string url = UpdateData.DownloadURL;

            using (WebClient wc = new WebClient())
            {
                wc.DownloadProgressChanged += Wc_DownloadProgressChanged;
                wc.DownloadFileCompleted += Wc_DownloadFileCompleted;

                wc.DownloadFile(new Uri(url), "data_" + UpdateData.Version + ".rar");
                wc.Dispose();
            }
        }

        private void Wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 0)
                versionAvailableLbl.Text = "Connecting to the server ...";

            if (e.ProgressPercentage == 100)
                versionAvailableLbl.Text = "Extracting the files ... holdon!";

            versionAvailableLbl.Text = (e.ProgressPercentage + "% | " + Updater.ConvertBytesToMegabytes(e.BytesReceived) + " MB out of " + Updater.ConvertBytesToMegabytes(e.TotalBytesToReceive) + " MB retrieven.");
        }

        private void Wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
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



            Updater.InstallUpdate();
            Size = new Size(Size.Width, 246);

            versionLabel.Text = "Newly installed " + UpdateData.Version;
            versionLabel.ForeColor = Color.DarkGreen;

            MaterialMessageBox.Show(null, "You've successfully installed Vanilla version " + UpdateData.Version + ".\n\n" +
                "If you encounter any issues please reach to us via www.support.vanilla-remastered.com", "Update installed!", MessageBoxButtons.OK);

            checkUpdatesBtn.Enabled = true;
            updateBtn.Enabled = true;
        }


        private void updateSwitch_CheckedChanged(object sender, EventArgs e)
        {
        }
    }
}
