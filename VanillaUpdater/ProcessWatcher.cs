using System.Diagnostics;

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
