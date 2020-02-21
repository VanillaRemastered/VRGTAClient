﻿using MaterialSkin;
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
        private readonly Properties.Settings _userSettings = new Properties.Settings();

        private bool isVanillaInstalled;

        public MainWindow()
        {
            InitializeComponent();
        }

        public void SetUiTheme(MaterialSkinManager.Themes theme)
        {
            MaterialSkinManager.Theme = theme;
        }

        public void BringToTop()
        {
            //Checks if the method is called from UI thread or not
            if (InvokeRequired)
            {
                Invoke(new Action(BringToTop));
            }
            else
            {
                if (WindowState == FormWindowState.Minimized) WindowState = FormWindowState.Normal;
                //Keeps the current topmost status of form
                var top = TopMost;
                //Brings the form to top
                TopMost = true;
                //Set form's topmost status back to whatever it was
                TopMost = top;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            VRegistry.CreateSubKey("Launch", ""); // create a key in case it doesn't exist.

            if (VRegistry.IsFirstRun())
            {
                SetupLogic.Run();
            }

            BringToTop();
            Focus();

            MaterialSkinManager = MaterialSkinManager.Instance;
            MaterialSkinManager.AddFormToManage(this);

            SetUiTheme(MaterialSkinManager.Themes.LIGHT);

            if (_userSettings.Theme == "Dark")
            {
                SetUiTheme(MaterialSkinManager.Themes.DARK);
                themeSwitch.Checked = false;
            }

            MaterialSkinManager.ColorScheme = new ColorScheme(Primary.Green800, Primary.Grey900, Primary.Green700,
                Accent.Green700, TextShade.WHITE);

            updaterVerLbl.Text += Assembly.GetExecutingAssembly().GetName().Version.ToString();

            if (VRegistry.GetSubKeyValue("Version") != null)
                versionLabel.Text += VRegistry.GetSubKeyValue("Version").ToString();

            if (_userSettings.AutoUpdate) updateSwitch.Checked = true;
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
                updaterVerLbl.Text = "Updater version: " + Assembly.GetExecutingAssembly().GetName().Version;
            }
            else
            {
               // Notifications.PlayNotificationSound();
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

            foreach (var item in UpdateData.Changes) changesBox.Items.Add(item);
            System.Diagnostics.Process.Start(UpdateData.SupportURL);

            ///Notifications.PlayNotificationSound();

            notifyIcon.ShowBalloonTip(1000, "Vanilla Update " + UpdateData.Version + " is now available",
                "Vanilla Remastered update is now available." +
                " Head over to the application to install it.", ToolTipIcon.None);
        }

        private async void updateBtn_Click(object sender, EventArgs e)
        {
            if (ProcessWatcher.IsGameRunning())
            {
                MaterialMessageBox.Show(null,
                    "The game is active and running! Please close it if you wish to begin updating.", "CLOSE THE GAME",
                    MessageBoxButtons.OK);
                return;
            }

            if(UpdateData.Version.Equals("1.3.0") && VRegistry.GetSubKeyValue("Version").Equals("1.2.0"))
            {
                MaterialMessageBox.Show(null,
                    "Update 1.3.0 has a different file system organization and therefore direct update from 1.2.0 to 1.3.0 is not possible.\n" +
                    "We highly recommend to remove old version of Vanilla and run the updater again.", "Important notice!", MessageBoxButtons.OK);
                //CleanUpdateUi();
                Updater.RemoveOlderUpdate("1.2.0");
                return;
            }

            checkUpdatesBtn.Enabled = false;
            updateBtn.Enabled = false;
            changePathBtn.Enabled = false;

            if (File.Exists("data_" + UpdateData.Version + ".rar"))
            {
                var dialogResult = MaterialMessageBox.Show(null, "We've found already downloaded update package.\n\n" +
                                                                 "The package might be corrupted / invalid." +
                                                                 "Do you wish to install this package?",
                    "Package found", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    versionAvailableLbl.Text = "installing the cached update ...";

                    var installCached = Task.Run(() => Updater.InstallUpdate());
                    await Task.WhenAll(installCached);

                    DisplayFinishedInstallUi();

                    Analytics.TrackEvent("Cached update has been installed", new Dictionary<string, string>
                    {
                        {"Version", UpdateData.Version}
                    });
                }
                else
                {
                    DownloadUpdate();
                }
            }

            else
            {
                DownloadUpdate();
            }
        }

        public void DownloadVR(string codeName)
        {
            var url = UpdateData.DownloadURL; // TODO: edit.

            using (var wc = new WebClient())
            {
                wc.DownloadProgressChanged += Wc_DownloadProgressChanged;
                wc.DownloadFileCompleted += Wc_DownloadVRCompleted;

                wc.DownloadFileAsync(new Uri(url), "datavr_" + UpdateData.Version + ".rar");
            }
        }

        private void Wc_DownloadVRCompleted(object sender, AsyncCompletedEventArgs e)
        {
            
        }

        public void DownloadUpdate()
        {
            var url = UpdateData.DownloadURL;

            using (var wc = new WebClient())
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

            versionAvailableLbl.Text = e.ProgressPercentage + "% | " +
                                       Updater.ConvertBytesToMegabytes(e.BytesReceived) + " MB out of " +
                                       Updater.ConvertBytesToMegabytes(e.TotalBytesToReceive) + " MB retrieven.";
        }

        public void CleanUpdateUi()
        {
            Size = new Size(Size.Width, 246);

            checkUpdatesBtn.Enabled = true;
            updateBtn.Enabled = true;
            changePathBtn.Enabled = true;
        }
        public void DisplayFinishedInstallUi()
        {
            Size = new Size(Size.Width, 246);

            versionLabel.Text = "Newly installed " + UpdateData.Version;
            versionLabel.ForeColor = Color.DarkGreen;

            notifyIcon.ShowBalloonTip(1000, "Vanilla Update " + UpdateData.Version + " has been installed",
                "If you encounter any issues please reach to us via www.support.vanilla-remastered.com",
                ToolTipIcon.None);

            MaterialMessageBox.Show(null, "You've successfully installed Vanilla version " + UpdateData.Version +
                                          ".\n\n" +
                                          "If you encounter any issues please reach to us via www.support.vanilla-remastered.com",
                "Update installed!", MessageBoxButtons.OK);

            checkUpdatesBtn.Enabled = true;
            updateBtn.Enabled = true;
            changePathBtn.Enabled = true;
        }

        private async void Wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                Analytics.TrackEvent("Update has been cancelled", new Dictionary<string, string>
                {
                    {"Version", UpdateData.Version},
                    {"Error", e.Error.Message}
                });

                File.Delete("data_" + UpdateData.Version + ".rar");
                return;
            }

            if (e.Error != null) // We have an error! Retry a few times, then abort.
            {
                Analytics.TrackEvent("Update has failed to download", new Dictionary<string, string>
                {
                    {"Version", UpdateData.Version},
                    {"Error", e.Error.Message}
                });

                MaterialMessageBox.Show(null, "An error has occured while trying to download the update.\n" +
                                              "The logs have been automatically sent to us and we're taking a look. Try to restart the updater and download the update again!\n\n" +
                                              "If you need help, reach us via: www.support.vanilla-remastered.com (ERR_CODE: " +
                                              e.Error.Message, "FATAL ERROR", MessageBoxButtons.OK);
                // Cleanup
                File.Delete("data_" + UpdateData.Version + ".rar");
                return;
            }


            Analytics.TrackEvent("Update has been downloaded", new Dictionary<string, string>
            {
                {"Version", UpdateData.Version},
            });

            notifyIcon.ShowBalloonTip(1000, "Vanilla Updater",
                "The update has been downloaded and is being installed. Please wait." +
                " If you've encountered any issues while using Vanilla' please let me us know via www.support.vanilla-remastered.com",
                ToolTipIcon.None);

            versionAvailableLbl.Text = "Extracting the files ... holdon!";


            var installer = Task.Run(() => Updater.InstallUpdate());

            await Task.WhenAll(installer);

            DisplayFinishedInstallUi();
        }


        private void updateSwitch_CheckedChanged(object sender, EventArgs e)
        {
            _userSettings.AutoUpdate = updateSwitch.Checked;
            _userSettings.Save();
        }

        private void themeSwitch_CheckedChanged(object sender, EventArgs e)
        {
            if (!themeSwitch.Checked)
            {
                SetUiTheme(MaterialSkinManager.Themes.DARK);
                _userSettings.Theme = "Dark";
            }
            else
            {
                SetUiTheme(MaterialSkinManager.Themes.LIGHT);
                _userSettings.Theme = "Light";
            }

            _userSettings.Save();
        }

        private void changePathBtn_Click(object sender, EventArgs e)
        {
            VRegistry.CreateSubKey("Path", "");
            Application.Restart();
        }
    }
}