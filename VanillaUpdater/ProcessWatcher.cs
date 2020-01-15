using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanillaUpdater
{
    class ProcessWatcher
    {
        /// <summary>
        /// Checks if the game is running or not
        /// </summary>
        public static bool IsGameRunning()
        {
            Process[] pname = Process.GetProcessesByName("gta_sa");
            if (pname.Length == 0) return false;
            return true;
        }
    }
}
