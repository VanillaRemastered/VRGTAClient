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

        }

        private void optionEnbBtn_Click(object sender, EventArgs e)
        {
            VRegistry.CreateSubKey("Version", "1.2.0");

            this.Hide();
        }

        private void optionnoEnb_Click(object sender, EventArgs e)
        {
            VRegistry.CreateSubKey("Version", "1.3.0");

            this.Hide();
        }

        private void idkBtn_Click(object sender, EventArgs e)
        {
            VRegistry.CreateSubKey("Version", "Unknown");

            this.Hide();
        }
    }
}
