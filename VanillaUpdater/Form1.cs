using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            MaterialSkinManager = MaterialSkinManager.Instance;
            MaterialSkinManager.AddFormToManage(this);

            SetUITheme(MaterialSkinManager.Themes.LIGHT);

            if (Properties.Resources.Theme == "LIGHT") SetUITheme(MaterialSkinManager.Themes.LIGHT);

            MaterialSkinManager.ColorScheme = new ColorScheme(Primary.Green800, Primary.Grey900, Primary.Green700, Accent.Green700, TextShade.WHITE);

            updaterVerLbl.Text += Assembly.GetExecutingAssembly().GetName().Version.ToString();

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
                updaterVerLbl.Text = "Current version: " + Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
            else MaterialMessageBox.Show("No update available at this time!");
        }

        private void CreateUpdateUI()
        {
            Size = new Size(Size.Width, 516); // extends the bottom part

            versionAvailableLbl.Text = UpdateData.Version + " is now available for installation!";

            changesBox.BackColor = Color.DarkGray;

            foreach(var cleanerobj in UpdateData.Changes) changesBox.Items.Remove(cleanerobj);

            foreach (var item in UpdateData.Changes)
            {
                changesBox.Items.Add(item);
            }
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            checkUpdatesBtn.Enabled = false;
            updateBtn.Enabled = false;

            Updater.DownloadUpdate();
        }

        private void updateSwitch_CheckedChanged(object sender, EventArgs e)
        {
        }
    }
}
