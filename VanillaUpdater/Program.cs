using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace VanillaUpdater
{
    static class Program
    {
        private static void SetCountryCode()
        {
            // This fallback country code does not reflect the physical device location, but rather the
            // country that corresponds to the culture it uses.
            var countryCode = RegionInfo.CurrentRegion.TwoLetterISORegionName;
            AppCenter.SetCountryCode(countryCode);
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            SetCountryCode();
            AppCenter.LogLevel = LogLevel.Verbose;
            AppCenter.Start("ceef21cd-5ffe-4266-b0e8-9a0769c3854d",
                   typeof(Analytics), typeof(Crashes));


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());

        }
    }
}
