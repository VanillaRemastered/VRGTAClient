using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VanillaUpdater
{
    public partial class SelectVRVersionForm : MaterialForm
    {
        public MaterialSkinManager MaterialSkinManager { get; set; }
        private bool isVersionMenuOpen = false;

        public SelectVRVersionForm()
        {
            InitializeComponent();
        }

        private void SelectVRVersionForm_Load(object sender, EventArgs e)
        {
            MaterialSkinManager = MaterialSkinManager.Instance;
            MaterialSkinManager.AddFormToManage(this);

            MaterialSkinManager.ColorScheme = new ColorScheme(Primary.Green800, Primary.Grey900, Primary.Green700,
                Accent.Green700, TextShade.WHITE);

            installComboBox.Hide();
            noteLbl.Hide();

        }

        private void optionEnbBtn_Click(object sender, EventArgs e)
        {
            VRegistry.CreateSubKey("Version", "1.2.0");

            Application.Restart();
        }

        private void optionnoEnb_Click(object sender, EventArgs e)
        {
            VRegistry.CreateSubKey("Version", "1.3.0");
            Application.Restart();
        }

        private void idkBtn_Click(object sender, EventArgs e)
        {
            VRegistry.CreateSubKey("Version", "Unknown");
            Application.Restart();
        }

        private void SelectVRVersionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void ver140Btn_Click(object sender, EventArgs e)
        {
            VRegistry.CreateSubKey("Version", "1.4.0");
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            if (!isVersionMenuOpen)
            {
                installComboBox.Show();
                noteLbl.Show();
                isVersionMenuOpen = true;
            }

            if(isVersionMenuOpen && installComboBox.SelectedIndex != -1)
            {
                ConsoleWrapper.PrintMessage("Installing " + installComboBox.SelectedItem.ToString(), ConsoleWrapper.PrintStatus.Normal);
                MessageBox.Show(installComboBox.SelectedItem.ToString());
            }
        }
    }
}
