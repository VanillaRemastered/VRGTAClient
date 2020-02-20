using MaterialSkin.Controls;
using System.IO;
using System.Windows.Forms;

namespace VanillaUpdater
{
    internal class SetupLogic
    {
        public static void Run()
        {
            if (VRegistry.IsFirstRun())
            {
                var folderBrowser = new OpenFileDialog
                {
                    ValidateNames = false,
                    CheckFileExists = false,
                    CheckPathExists = true,

                    FileName = "Select game root path"
                };


                if (folderBrowser.ShowDialog() == DialogResult.OK)
                {
                    var folderPath = Path.GetDirectoryName(folderBrowser.FileName);
                    if (GameCheck.IsWorkspaceValid(folderPath))
                    {
                        VRegistry.CreateSubKey("Path", folderPath);
                    }
                    else
                    {
                        //Notifications.PlayErrorSound();
                        MaterialMessageBox.Show(null,
                            "The selected folder does not look valid. This might happen if you've selected wrong folder.\n\n" +
                            "Start the app once again and select proper folder. If this error still presists, contact developers.",
                            "Important message!", MessageBoxButtons.OK);

                        Application.Restart();
                    }
                }
                else
                {
                    Application.Exit();
                }
            }
        }
    }
}