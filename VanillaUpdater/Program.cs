using System;
using System.Windows.Forms;

using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

namespace VanillaUpdater
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppCenter.Start("ceef21cd-5ffe-4266-b0e8-9a0769c3854d",
                   typeof(Analytics), typeof(Crashes));

            AppCenter.LogLevel = LogLevel.Verbose;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());

        }
    }
}
