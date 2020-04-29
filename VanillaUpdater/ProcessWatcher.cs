using System.Diagnostics;

namespace VanillaUpdater
{
    internal class ProcessWatcher
    {
        /// <summary>
        /// Checks if the game is running or not
        /// </summary>
        public static bool IsGameRunning()
        {
            var pname = Process.GetProcessesByName("gta_sa");
            if (pname.Length == 0) return false;
            return true;
        }
    }
}