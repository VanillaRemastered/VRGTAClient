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
            this.themeSwitch = new MaterialSkin.Controls.MaterialSwitch();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.changePathBtn = new MaterialSkin.Controls.MaterialButton();
            this.materialCard1 = new MaterialSkin.Controls.MaterialCard();
            this.backgroundChecker = new System.ComponentModel.BackgroundWorker();
            this.materialSwitch1 = new MaterialSkin.Controls.MaterialSwitch();
            this.materialCard1.SuspendLayout();
            this.SuspendLayout();
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Depth = 0;
            this.versionLabel.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.versionLabel.Location = new System.Drawing.Point(12, 74);
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
            this.checkUpdatesBtn.Location = new System.Drawing.Point(204, 196);
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
            this.versionAvailableLbl.Location = new System.Drawing.Point(12, 278);
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
            this.updateBtn.Location = new System.Drawing.Point(258, 463);
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
            this.updaterVerLbl.Location = new System.Drawing.Point(12, 102);
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
            this.updateSwitch.Location = new System.Drawing.Point(219, 153);
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
            this.changesBox.FormattingEnabled = true;
            this.changesBox.HorizontalScrollbar = true;
            this.changesBox.ItemHeight = 16;
            this.changesBox.Location = new System.Drawing.Point(10, 0);
            this.changesBox.Name = "changesBox";
            this.changesBox.Size = new System.Drawing.Size(353, 112);
            this.changesBox.TabIndex = 9;
            // 
            // themeSwitch
            // 
            this.themeSwitch.AutoSize = true;
            this.themeSwitch.Checked = true;
            this.themeSwitch.CheckState = System.Windows.Forms.CheckState.Checked;
            this.themeSwitch.Depth = 0;
            this.themeSwitch.Location = new System.Drawing.Point(278, 116);
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
            this.changePathBtn.Location = new System.Drawing.Point(9, 196);
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
            // materialCard1
            // 
            this.materialCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard1.Controls.Add(this.changesBox);
            this.materialCard1.Depth = 0;
            this.materialCard1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard1.Location = new System.Drawing.Point(9, 311);
            this.materialCard1.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard1.Name = "materialCard1";
            this.materialCard1.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard1.Size = new System.Drawing.Size(363, 104);
            this.materialCard1.TabIndex = 12;
            // 
            // backgroundChecker
            // 
            this.backgroundChecker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            // 
            // materialSwitch1
            // 
            this.materialSwitch1.AutoSize = true;
            this.materialSwitch1.Depth = 0;
            this.materialSwitch1.Location = new System.Drawing.Point(0, 153);
            this.materialSwitch1.Margin = new System.Windows.Forms.Padding(0);
            this.materialSwitch1.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialSwitch1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialSwitch1.Name = "materialSwitch1";
            this.materialSwitch1.Ripple = true;
            this.materialSwitch1.Size = new System.Drawing.Size(131, 37);
            this.materialSwitch1.TabIndex = 13;
            this.materialSwitch1.Text = "Show FPS";
            this.materialSwitch1.UseVisualStyleBackColor = true;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 243);
            this.Controls.Add(this.materialSwitch1);
            this.Controls.Add(this.materialCard1);
            this.Controls.Add(this.changePathBtn);
            this.Controls.Add(this.themeSwitch);
            this.Controls.Add(this.updateSwitch);
            this.Controls.Add(this.updaterVerLbl);
            this.Controls.Add(this.updateBtn);
            this.Controls.Add(this.versionAvailableLbl);
            this.Controls.Add(this.checkUpdatesBtn);
            this.Controls.Add(this.versionLabel);
            this.DrawerWidth = 100;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "GTA SA Vanilla Updater";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.materialCard1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel versionLabel;
        private MaterialSkin.Controls.MaterialButton checkUpdatesBtn;
        private MaterialSkin.Controls.MaterialLabel versionAvailableLbl;
        private MaterialSkin.Controls.MaterialButton updateBtn;
        private MaterialSkin.Controls.MaterialLabel updaterVerLbl;
        private MaterialSkin.Controls.MaterialSwitch updateSwitch;
        private System.Windows.Forms.ListBox changesBox;
        private MaterialSkin.Controls.MaterialSwitch themeSwitch;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private MaterialSkin.Controls.MaterialButton changePathBtn;
        private MaterialSkin.Controls.MaterialCard materialCard1;
        private System.ComponentModel.BackgroundWorker backgroundChecker;
        private MaterialSkin.Controls.MaterialSwitch materialSwitch1;
    }
}

