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
            this.versionLabel = new MaterialSkin.Controls.MaterialLabel();
            this.checkUpdatesBtn = new MaterialSkin.Controls.MaterialButton();
            this.versionAvailableLbl = new MaterialSkin.Controls.MaterialLabel();
            this.updateBtn = new MaterialSkin.Controls.MaterialButton();
            this.updaterVerLbl = new MaterialSkin.Controls.MaterialLabel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Depth = 0;
            this.versionLabel.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.versionLabel.Location = new System.Drawing.Point(16, 90);
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
            this.checkUpdatesBtn.Location = new System.Drawing.Point(162, 165);
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
            this.versionAvailableLbl.Location = new System.Drawing.Point(101, 239);
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
            this.updateBtn.Location = new System.Drawing.Point(104, 485);
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
            this.updaterVerLbl.Location = new System.Drawing.Point(16, 118);
            this.updaterVerLbl.MouseState = MaterialSkin.MouseState.HOVER;
            this.updaterVerLbl.Name = "updaterVerLbl";
            this.updaterVerLbl.Size = new System.Drawing.Size(119, 19);
            this.updaterVerLbl.TabIndex = 5;
            this.updaterVerLbl.Text = "Updater version: ";
            // 
            // progressBar
            // 
            this.progressBar.Enabled = false;
            this.progressBar.Location = new System.Drawing.Point(79, 466);
            this.progressBar.MarqueeAnimationSpeed = 10;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(163, 10);
            this.progressBar.Step = 5;
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 7;
            this.progressBar.Visible = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 215);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.updaterVerLbl);
            this.Controls.Add(this.updateBtn);
            this.Controls.Add(this.versionAvailableLbl);
            this.Controls.Add(this.checkUpdatesBtn);
            this.Controls.Add(this.versionLabel);
            this.Name = "MainWindow";
            this.Text = "Vanilla Updater";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel versionLabel;
        private MaterialSkin.Controls.MaterialButton checkUpdatesBtn;
        private MaterialSkin.Controls.MaterialLabel versionAvailableLbl;
        private MaterialSkin.Controls.MaterialButton updateBtn;
        private MaterialSkin.Controls.MaterialLabel updaterVerLbl;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}

