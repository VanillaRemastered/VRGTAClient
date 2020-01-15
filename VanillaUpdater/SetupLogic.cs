using MaterialSkin.Controls;
using System.IO;
using System.Windows.Forms;

namespace VanillaUpdater
{
    class SetupLogic
    {
        public static void Run()
        {
            if (VRegistry.IsFirstRun())
            {
                OpenFileDialog folderBrowser = new OpenFileDialog
                {
                    ValidateNames = false,
                    CheckFileExists = false,
                    CheckPathExists = true,

                    FileName = "Select game root path"
                };


                if (folderBrowser.ShowDialog() == DialogResult.OK)
                {
                    string folderPath = Path.GetDirectoryName(folderBrowser.FileName);
                    if (GameCheck.IsWorkspaceValid(folderPath))
                    {
                        VRegistry.CreateSubKey("Path", folderPath);

                    }
                    else
                    {
                        MaterialMessageBox.Show(null, "The selected folder does not look valid. This might happen if you've selected wrong folder.\n\n" +
                            "Start the app once again and select proper folder. If this error still presists, contact developers.", "Important message!", MessageBoxButtons.OK);

                        Application.Restart();
                    }
                }
            }
        }
    }
}
