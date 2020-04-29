using System.Diagnostics;

namespace VanillaUpdater
{
    internal class ProcessWatcher
    {
        public enum GameType
        {
            SA = 0,
            VC = 1
        }

        public static bool IsGameRunning(GameType game)
        {
            var pname = Process.GetProcessesByName("gta_" + game.ToString().ToLower());
            if (pname.Length == 0) return false;
            return true;
        }
        /// <summary>
        /// Checks if the game is running or not
        /// </summary>
        public static bool IsSARunning()
        {
            var pname = Process.GetProcessesByName("gta_sa");
            if (pname.Length == 0) return false;
            return true;
        }
    }
}