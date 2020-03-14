namespace VanillaUpdater
{
    partial class SelectVRVersionForm
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
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.optionEnbBtn = new MaterialSkin.Controls.MaterialButton();
            this.optionnoEnb = new MaterialSkin.Controls.MaterialButton();
            this.idkBtn = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(12, 77);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(422, 19);
            this.materialLabel1.TabIndex = 0;
            this.materialLabel1.Text = "Which version of Vanilla Remastered do you have installed?";
            // 
            // optionEnbBtn
            // 
            this.optionEnbBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.optionEnbBtn.Depth = 0;
            this.optionEnbBtn.DrawShadows = true;
            this.optionEnbBtn.HighEmphasis = true;
            this.optionEnbBtn.Icon = null;
            this.optionEnbBtn.Location = new System.Drawing.Point(15, 138);
            this.optionEnbBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.optionEnbBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.optionEnbBtn.Name = "optionEnbBtn";
            this.optionEnbBtn.Size = new System.Drawing.Size(97, 36);
            this.optionEnbBtn.TabIndex = 1;
            this.optionEnbBtn.Text = "1.2.0 (enb)";
            this.optionEnbBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.optionEnbBtn.UseAccentColor = false;
            this.optionEnbBtn.UseVisualStyleBackColor = true;
            this.optionEnbBtn.Click += new System.EventHandler(this.optionEnbBtn_Click);
            // 
            // optionnoEnb
            // 
            this.optionnoEnb.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.optionnoEnb.Depth = 0;
            this.optionnoEnb.DrawShadows = true;
            this.optionnoEnb.HighEmphasis = true;
            this.optionnoEnb.Icon = null;
            this.optionnoEnb.Location = new System.Drawing.Point(120, 138);
            this.optionnoEnb.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.optionnoEnb.MouseState = MaterialSkin.MouseState.HOVER;
            this.optionnoEnb.Name = "optionnoEnb";
            this.optionnoEnb.Size = new System.Drawing.Size(121, 36);
            this.optionnoEnb.TabIndex = 2;
            this.optionnoEnb.Text = "1.3.0 (no enb)";
            this.optionnoEnb.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.optionnoEnb.UseAccentColor = false;
            this.optionnoEnb.UseVisualStyleBackColor = true;
            this.optionnoEnb.Click += new System.EventHandler(this.optionnoEnb_Click);
            // 
            // idkBtn
            // 
            this.idkBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.idkBtn.Depth = 0;
            this.idkBtn.DrawShadows = true;
            this.idkBtn.HighEmphasis = true;
            this.idkBtn.Icon = null;
            this.idkBtn.Location = new System.Drawing.Point(312, 138);
            this.idkBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.idkBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.idkBtn.Name = "idkBtn";
            this.idkBtn.Size = new System.Drawing.Size(115, 36);
            this.idkBtn.TabIndex = 3;
            this.idkBtn.Text = "I dont know ";
            this.idkBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.idkBtn.UseAccentColor = false;
            this.idkBtn.UseVisualStyleBackColor = true;
            this.idkBtn.Click += new System.EventHandler(this.idkBtn_Click);
            // 
            // SelectVRVersionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 189);
            this.Controls.Add(this.idkBtn);
            this.Controls.Add(this.optionnoEnb);
            this.Controls.Add(this.optionEnbBtn);
            this.Controls.Add(this.materialLabel1);
            this.MaximizeBox = false;
            this.Name = "SelectVRVersionForm";
            this.ShowInTaskbar = false;
            this.Text = "Important question";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SelectVRVersionForm_FormClosing);
            this.Load += new System.EventHandler(this.SelectVRVersionForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialButton optionEnbBtn;
        private MaterialSkin.Controls.MaterialButton optionnoEnb;
        private MaterialSkin.Controls.MaterialButton idkBtn;
    }
}