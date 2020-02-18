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
    public partial class VanillaSelecter : MaterialForm
    {
        public MaterialSkinManager MaterialSkinManager { get; set; }
        public VanillaSelecter()
        {
            InitializeComponent();
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

        private void VanillaSelecter_Load(object sender, EventArgs e)
        {
            BringToFront();
        }
    }
}
