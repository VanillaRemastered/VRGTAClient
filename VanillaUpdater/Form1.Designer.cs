namespace VanillaUpdater
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.versionLabel = new MaterialSkin.Controls.MaterialLabel();
            this.checkUpdatesBtn = new MaterialSkin.Controls.MaterialButton();
            this.versionAvailableLbl = new MaterialSkin.Controls.MaterialLabel();
            this.updateBtn = new MaterialSkin.Controls.MaterialButton();
            this.updaterVerLbl = new MaterialSkin.Controls.MaterialLabel();
            this.updateSwitch = new MaterialSkin.Controls.MaterialSwitch();
            this.changesBox = new System.Windows.Forms.ListBox();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.changePathBtn = new MaterialSkin.Controls.MaterialButton();
            this.backgroundChecker = new System.ComponentModel.BackgroundWorker();
            this.showFpsSwitch = new MaterialSkin.Controls.MaterialSwitch();
            this.mainTabCtrl = new System.Windows.Forms.TabControl();
            this.viceCityTab = new System.Windows.Forms.TabPage();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.gtasaPage = new System.Windows.Forms.TabPage();
            this.clientBox = new System.Windows.Forms.GroupBox();
            this.interfaceBox = new System.Windows.Forms.GroupBox();
            this.themeSwitch = new MaterialSkin.Controls.MaterialSwitch();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.updaterBox = new System.Windows.Forms.GroupBox();
            this.downloadSizeLbl = new MaterialSkin.Controls.MaterialLabel();
            this.mainTabCtrl.SuspendLayout();
            this.viceCityTab.SuspendLayout();
            this.gtasaPage.SuspendLayout();
            this.clientBox.SuspendLayout();
            this.interfaceBox.SuspendLayout();
            this.updaterBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Depth = 0;
            this.versionLabel.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.versionLabel.Location = new System.Drawing.Point(152, 21);
            this.versionLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(104, 19);
            this.versionLabel.TabIndex = 0;
            this.versionLabel.Text = "Client version: ";
            // 
            // checkUpdatesBtn
            // 
            this.checkUpdatesBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.checkUpdatesBtn.Depth = 0;
            this.checkUpdatesBtn.DrawShadows = true;
            this.checkUpdatesBtn.HighEmphasis = true;
            this.checkUpdatesBtn.Icon = null;
            this.checkUpdatesBtn.Location = new System.Drawing.Point(138, 46);
            this.checkUpdatesBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.checkUpdatesBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.checkUpdatesBtn.Name = "checkUpdatesBtn";
            this.checkUpdatesBtn.Size = new System.Drawing.Size(168, 36);
            this.checkUpdatesBtn.TabIndex = 1;
            this.checkUpdatesBtn.Text = "Check for updates";
            this.checkUpdatesBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.checkUpdatesBtn.UseAccentColor = false;
            this.checkUpdatesBtn.UseVisualStyleBackColor = true;
            this.checkUpdatesBtn.Click += new System.EventHandler(this.checkUpdatesBtn_Click);
            // 
            // versionAvailableLbl
            // 
            this.versionAvailableLbl.AutoSize = true;
            this.versionAvailableLbl.Depth = 0;
            this.versionAvailableLbl.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.versionAvailableLbl.Location = new System.Drawing.Point(85, 0);
            this.versionAvailableLbl.MouseState = MaterialSkin.MouseState.HOVER;
            this.versionAvailableLbl.Name = "versionAvailableLbl";
            this.versionAvailableLbl.Size = new System.Drawing.Size(119, 19);
            this.versionAvailableLbl.TabIndex = 2;
            this.versionAvailableLbl.Text = "VersionAvailable";
            // 
            // updateBtn
            // 
            this.updateBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.updateBtn.Depth = 0;
            this.updateBtn.DrawShadows = true;
            this.updateBtn.HighEmphasis = true;
            this.updateBtn.Icon = null;
            this.updateBtn.Location = new System.Drawing.Point(189, 265);
            this.updateBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.updateBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(114, 36);
            this.updateBtn.TabIndex = 4;
            this.updateBtn.Text = "Update now";
            this.updateBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.updateBtn.UseAccentColor = false;
            this.updateBtn.UseVisualStyleBackColor = true;
            this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
            // 
            // updaterVerLbl
            // 
            this.updaterVerLbl.AutoSize = true;
            this.updaterVerLbl.Depth = 0;
            this.updaterVerLbl.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.updaterVerLbl.Location = new System.Drawing.Point(13, 21);
            this.updaterVerLbl.MouseState = MaterialSkin.MouseState.HOVER;
            this.updaterVerLbl.Name = "updaterVerLbl";
            this.updaterVerLbl.Size = new System.Drawing.Size(119, 19);
            this.updaterVerLbl.TabIndex = 5;
            this.updaterVerLbl.Text = "Updater version: ";
            // 
            // updateSwitch
            // 
            this.updateSwitch.AutoSize = true;
            this.updateSwitch.Depth = 0;
            this.updateSwitch.Location = new System.Drawing.Point(23, 66);
            this.updateSwitch.Margin = new System.Windows.Forms.Padding(0);
            this.updateSwitch.MouseLocation = new System.Drawing.Point(-1, -1);
            this.updateSwitch.MouseState = MaterialSkin.MouseState.HOVER;
            this.updateSwitch.Name = "updateSwitch";
            this.updateSwitch.Ripple = true;
            this.updateSwitch.Size = new System.Drawing.Size(153, 37);
            this.updateSwitch.TabIndex = 8;
            this.updateSwitch.Text = "Auto Updates";
            this.updateSwitch.UseVisualStyleBackColor = true;
            this.updateSwitch.CheckedChanged += new System.EventHandler(this.updateSwitch_CheckedChanged);
            // 
            // changesBox
            // 
            this.changesBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.changesBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.changesBox.ForeColor = System.Drawing.SystemColors.Highlight;
            this.changesBox.FormattingEnabled = true;
            this.changesBox.HorizontalScrollbar = true;
            this.changesBox.ItemHeight = 16;
            this.changesBox.Location = new System.Drawing.Point(16, 32);
            this.changesBox.Name = "changesBox";
            this.changesBox.Size = new System.Drawing.Size(288, 208);
            this.changesBox.TabIndex = 9;
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipText = "Notif";
            this.notifyIcon.BalloonTipTitle = "Vanilla Remastered";
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Vanilla Updater";
            this.notifyIcon.Visible = true;
            // 
            // changePathBtn
            // 
            this.changePathBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.changePathBtn.Depth = 0;
            this.changePathBtn.DrawShadows = true;
            this.changePathBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F);
            this.changePathBtn.HighEmphasis = true;
            this.changePathBtn.Icon = null;
            this.changePathBtn.Location = new System.Drawing.Point(8, 46);
            this.changePathBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.changePathBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.changePathBtn.Name = "changePathBtn";
            this.changePathBtn.Size = new System.Drawing.Size(122, 36);
            this.changePathBtn.TabIndex = 11;
            this.changePathBtn.Text = "Change Path";
            this.changePathBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.changePathBtn.UseAccentColor = false;
            this.changePathBtn.UseVisualStyleBackColor = true;
            this.changePathBtn.Click += new System.EventHandler(this.changePathBtn_Click);
            // 
            // backgroundChecker
            // 
            this.backgroundChecker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            // 
            // showFpsSwitch
            // 
            this.showFpsSwitch.AutoSize = true;
            this.showFpsSwitch.Depth = 0;
            this.showFpsSwitch.Location = new System.Drawing.Point(23, 29);
            this.showFpsSwitch.Margin = new System.Windows.Forms.Padding(0);
            this.showFpsSwitch.MouseLocation = new System.Drawing.Point(-1, -1);
            this.showFpsSwitch.MouseState = MaterialSkin.MouseState.HOVER;
            this.showFpsSwitch.Name = "showFpsSwitch";
            this.showFpsSwitch.Ripple = true;
            this.showFpsSwitch.Size = new System.Drawing.Size(131, 37);
            this.showFpsSwitch.TabIndex = 13;
            this.showFpsSwitch.Text = "Show FPS";
            this.showFpsSwitch.UseVisualStyleBackColor = true;
            this.showFpsSwitch.CheckedChanged += new System.EventHandler(this.showFpsSwitch_CheckedChanged);
            // 
            // mainTabCtrl
            // 
            this.mainTabCtrl.Controls.Add(this.viceCityTab);
            this.mainTabCtrl.Controls.Add(this.gtasaPage);
            this.mainTabCtrl.Location = new System.Drawing.Point(-4, 61);
            this.mainTabCtrl.Name = "mainTabCtrl";
            this.mainTabCtrl.SelectedIndex = 0;
            this.mainTabCtrl.Size = new System.Drawing.Size(726, 533);
            this.mainTabCtrl.TabIndex = 14;
            // 
            // viceCityTab
            // 
            this.viceCityTab.Controls.Add(this.webBrowser);
            this.viceCityTab.Location = new System.Drawing.Point(4, 22);
            this.viceCityTab.Name = "viceCityTab";
            this.viceCityTab.Padding = new System.Windows.Forms.Padding(3);
            this.viceCityTab.Size = new System.Drawing.Size(718, 507);
            this.viceCityTab.TabIndex = 1;
            this.viceCityTab.Text = "Vice City";
            this.viceCityTab.UseVisualStyleBackColor = true;
            // 
            // webBrowser
            // 
            this.webBrowser.AllowNavigation = false;
            this.webBrowser.AllowWebBrowserDrop = false;
            this.webBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser.Location = new System.Drawing.Point(-4, 0);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.ScrollBarsEnabled = false;
            this.webBrowser.Size = new System.Drawing.Size(722, 504);
            this.webBrowser.TabIndex = 0;
            this.webBrowser.Url = new System.Uri("http://www.vanilla-remastered.com/vicecity.html", System.UriKind.Absolute);
            this.webBrowser.WebBrowserShortcutsEnabled = false;
            // 
            // gtasaPage
            // 
            this.gtasaPage.Controls.Add(this.updaterBox);
            this.gtasaPage.Controls.Add(this.clientBox);
            this.gtasaPage.Controls.Add(this.interfaceBox);
            this.gtasaPage.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gtasaPage.ImageKey = "(none)";
            this.gtasaPage.Location = new System.Drawing.Point(4, 22);
            this.gtasaPage.Name = "gtasaPage";
            this.gtasaPage.Padding = new System.Windows.Forms.Padding(3);
            this.gtasaPage.Size = new System.Drawing.Size(718, 507);
            this.gtasaPage.TabIndex = 0;
            this.gtasaPage.Text = "San Andreas";
            this.gtasaPage.UseVisualStyleBackColor = true;
            this.gtasaPage.Click += new System.EventHandler(this.gtasaPage_Click);
            // 
            // clientBox
            // 
            this.clientBox.Controls.Add(this.versionLabel);
            this.clientBox.Controls.Add(this.checkUpdatesBtn);
            this.clientBox.Controls.Add(this.changePathBtn);
            this.clientBox.Controls.Add(this.updaterVerLbl);
            this.clientBox.Location = new System.Drawing.Point(361, 6);
            this.clientBox.Name = "clientBox";
            this.clientBox.Size = new System.Drawing.Size(318, 103);
            this.clientBox.TabIndex = 15;
            this.clientBox.TabStop = false;
            this.clientBox.Text = "Client options";
            // 
            // interfaceBox
            // 
            this.interfaceBox.Controls.Add(this.showFpsSwitch);
            this.interfaceBox.Controls.Add(this.updateSwitch);
            this.interfaceBox.Controls.Add(this.themeSwitch);
            this.interfaceBox.Location = new System.Drawing.Point(6, 6);
            this.interfaceBox.Name = "interfaceBox";
            this.interfaceBox.Size = new System.Drawing.Size(318, 110);
            this.interfaceBox.TabIndex = 14;
            this.interfaceBox.TabStop = false;
            this.interfaceBox.Text = "Interface";
            // 
            // themeSwitch
            // 
            this.themeSwitch.AutoSize = true;
            this.themeSwitch.Checked = true;
            this.themeSwitch.CheckState = System.Windows.Forms.CheckState.Checked;
            this.themeSwitch.Depth = 0;
            this.themeSwitch.Location = new System.Drawing.Point(209, 29);
            this.themeSwitch.Margin = new System.Windows.Forms.Padding(0);
            this.themeSwitch.MouseLocation = new System.Drawing.Point(-1, -1);
            this.themeSwitch.MouseState = MaterialSkin.MouseState.HOVER;
            this.themeSwitch.Name = "themeSwitch";
            this.themeSwitch.Ripple = true;
            this.themeSwitch.Size = new System.Drawing.Size(94, 37);
            this.themeSwitch.TabIndex = 10;
            this.themeSwitch.Text = "Light";
            this.themeSwitch.UseVisualStyleBackColor = true;
            this.themeSwitch.CheckedChanged += new System.EventHandler(this.themeSwitch_CheckedChanged);
            // 
            // updaterBox
            // 
            this.updaterBox.Controls.Add(this.downloadSizeLbl);
            this.updaterBox.Controls.Add(this.versionAvailableLbl);
            this.updaterBox.Controls.Add(this.changesBox);
            this.updaterBox.Controls.Add(this.updateBtn);
            this.updaterBox.ForeColor = System.Drawing.Color.ForestGreen;
            this.updaterBox.Location = new System.Drawing.Point(361, 133);
            this.updaterBox.Name = "updaterBox";
            this.updaterBox.Size = new System.Drawing.Size(310, 310);
            this.updaterBox.TabIndex = 18;
            this.updaterBox.TabStop = false;
            this.updaterBox.Text = "Update";
            // 
            // downloadSizeLbl
            // 
            this.downloadSizeLbl.AutoSize = true;
            this.downloadSizeLbl.Depth = 0;
            this.downloadSizeLbl.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.downloadSizeLbl.Location = new System.Drawing.Point(13, 291);
            this.downloadSizeLbl.MouseState = MaterialSkin.MouseState.HOVER;
            this.downloadSizeLbl.Name = "downloadSizeLbl";
            this.downloadSizeLbl.Size = new System.Drawing.Size(29, 19);
            this.downloadSizeLbl.TabIndex = 12;
            this.downloadSizeLbl.Text = "size";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 589);
            this.Controls.Add(this.mainTabCtrl);
            this.DrawerWidth = 100;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Sizable = false;
            this.Text = "GTA Client";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.mainTabCtrl.ResumeLayout(false);
            this.viceCityTab.ResumeLayout(false);
            this.gtasaPage.ResumeLayout(false);
            this.clientBox.ResumeLayout(false);
            this.clientBox.PerformLayout();
            this.interfaceBox.ResumeLayout(false);
            this.interfaceBox.PerformLayout();
            this.updaterBox.ResumeLayout(false);
            this.updaterBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel versionLabel;
        private MaterialSkin.Controls.MaterialButton checkUpdatesBtn;
        private MaterialSkin.Controls.MaterialLabel versionAvailableLbl;
        private MaterialSkin.Controls.MaterialButton updateBtn;
        private MaterialSkin.Controls.MaterialLabel updaterVerLbl;
        private MaterialSkin.Controls.MaterialSwitch updateSwitch;
        private System.Windows.Forms.ListBox changesBox;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private MaterialSkin.Controls.MaterialButton changePathBtn;
        private System.ComponentModel.BackgroundWorker backgroundChecker;
        private MaterialSkin.Controls.MaterialSwitch showFpsSwitch;
        private System.Windows.Forms.TabControl mainTabCtrl;
        private System.Windows.Forms.TabPage viceCityTab;
        private System.Windows.Forms.TabPage gtasaPage;
        private MaterialSkin.Controls.MaterialSwitch themeSwitch;
        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.GroupBox interfaceBox;
        private System.Windows.Forms.GroupBox clientBox;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.GroupBox updaterBox;
        private MaterialSkin.Controls.MaterialLabel downloadSizeLbl;
    }
}

