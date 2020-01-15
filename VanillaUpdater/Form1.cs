using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.AppCenter.Analytics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VanillaUpdater
{
    public partial class MainWindow : MaterialForm
    {
        public MaterialSkinManager MaterialSkinManager { get; set; }
        internal string downloadProgressPercent { get; set; }
        private readonly Properties.Settings userSettings = new Properties.Settings();

        public MainWindow()
        {
            InitializeComponent();
        }

        public void SetUITheme(MaterialSkinManager.Themes theme) => MaterialSkinManager.Theme = theme;

        public void BringToTop()
        {
            //Checks if the method is called from UI thread or not
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(BringToTop));
            }
            else
            {
                if (this.WindowState == FormWindowState.Minimized)
                {
                    this.WindowState = FormWindowState.Normal;
                }
                //Keeps the current topmost status of form
                bool top = TopMost;
                //Brings the form to top
                TopMost = true;
                //Set form's topmost status back to whatever it was
                TopMost = top;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            VRegistry.CreateSubKey("Launch", ""); // create a key in case it doesn't exist.

            if (VRegistry.IsFirstRun()) SetupLogic.Run();

            BringToTop();
            Focus();

            MaterialSkinManager = MaterialSkinManager.Instance;
            MaterialSkinManager.AddFormToManage(this);

            SetUITheme(MaterialSkinManager.Themes.LIGHT);

            if (userSettings.Theme == "Dark")
            {
                SetUITheme(MaterialSkinManager.Themes.DARK);
                themeSwitch.Checked = false;
            }

            MaterialSkinManager.ColorScheme = new ColorScheme(Primary.Green800, Primary.Grey900, Primary.Green700, Accent.Green700, TextShade.WHITE);

            updaterVerLbl.Text += Assembly.GetExecutingAssembly().GetName().Version.ToString();

            if (VRegistry.GetSubKeyValue("Version") != null)
                versionLabel.Text += VRegistry.GetSubKeyValue("Version").ToString();

            if (userSettings.AutoUpdate == true) updateSwitch.Checked = true;
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
                updaterVerLbl.Text = "Updater version: " + Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
            else
            {
                Notifications.PlayNotificationSound();
                MaterialMessageBox.Show(null, "You're using the latest version of Vanilla.", "No updates found");
            }

            checkUpdatesBtn.Enabled = true;
        }

        private void CreateUpdateUI()
        {
            Size = new Size(Size.Width, 516); // extends the bottom part

            versionAvailableLbl.Text = UpdateData.Version + " is now available for installation!";

            changesBox.BackColor = Color.DarkSeaGreen;

            foreach (var cleanerobj in UpdateData.Changes) changesBox.Items.Remove(cleanerobj);

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

        private async void updateBtn_Click(object sender, EventArgs e)
        {
            if(ProcessWatcher.IsGameRunning())
            {
                MaterialMessageBox.Show(null, "The game is active and running! Please close it if you wish to update", "CLOSE THE GAME", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            checkUpdatesBtn.Enabled = false;
            updateBtn.Enabled = false;

            if (File.Exists("data_" + UpdateData.Version + ".rar"))
            {
                DialogResult dialogResult = MaterialMessageBox.Show(null, "We've found already downloaded update package.\n\n" +
                    "The package might be corrupted / invalid." +
                    "Do you wish to install this package?", "Package found", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    versionAvailableLbl.Text = "installing the cached update ...";

                    var installCached = Task.Run(() => Updater.InstallUpdate());
                    await Task.WhenAll(installCached);
                }
                else
                {
                    DownloadUpdate();
                }
            }

            else DownloadUpdate();

        }

        public void DownloadUpdate()
        {
            string url = UpdateData.DownloadURL;

            using (WebClient wc = new WebClient())
            {
                wc.DownloadProgressChanged += Wc_DownloadProgressChanged;
                wc.DownloadFileCompleted += Wc_DownloadFileCompleted;

                wc.DownloadFileAsync(new Uri(url), "data_" + UpdateData.Version + ".rar");
            }
        }

        private void Wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 0)
                versionAvailableLbl.Text = "Connecting to the server ...";

            versionAvailableLbl.Text = (e.ProgressPercentage + "% | " + Updater.ConvertBytesToMegabytes(e.BytesReceived) + " MB out of " + Updater.ConvertBytesToMegabytes(e.TotalBytesToReceive) + " MB retrieven.");
        }

        private async void Wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                Analytics.TrackEvent("Update has been cancelled", new Dictionary<string, string> {
                { "Version", UpdateData.Version },
                {"Error", e.Error.Message}
            });

                File.Delete("data_" + UpdateData.Version + ".rar");
                return;
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
                // Cleanup
                File.Delete("data_" + UpdateData.Version + ".rar");
                return;
            }


            Analytics.TrackEvent("Update has been downloaded", new Dictionary<string, string> {
                { "Version", UpdateData.Version },
            });

            versionAvailableLbl.Text = "Extracting the files ... holdon!";

            var installer = Task.Run(() => Updater.InstallUpdate());

            await Task.WhenAll(installer);

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
            userSettings.AutoUpdate = updateSwitch.Checked;
            userSettings.Save();
        }

        private void themeSwitch_CheckedChanged(object sender, EventArgs e)
        {
            if (!themeSwitch.Checked)
            {
                SetUITheme(MaterialSkinManager.Themes.DARK);
                userSettings.Theme = "Dark";
            }
            else
            {
                SetUITheme(MaterialSkinManager.Themes.LIGHT);
                userSettings.Theme = "Light";
            }

            userSettings.Save();
        }
    }
}
