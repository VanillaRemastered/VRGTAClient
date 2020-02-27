using System.IO;
using System.Linq;

namespace VanillaUpdater
{
    internal class GameCheck
    {
        private static readonly string[] requiredFiles = new string[]
        {
            "gta_sa.exe",
            "vorbis.dll",
            "eax.dll",
            "bass.dll"
        };

        /// <summary>
        /// returns true if the application is put into the root directory (gtasa)
        /// </summary>
        /// <returns></returns>
        public static bool IsWorkspaceValid(string path)
        {
            /*
             * I feel like i need to explain what this code does and why we do this. 
             * So, the path looks like this: C:\\Blabblah\\GTASAFOLDER right?
             * And our requiredFiles array are only the file names, without path.
             * So, we append full path to requiredFiles so they look like this: C:\\Blahlbahl\\GTASAFOLDER\\gta_sa.exe
             * 
             * TODO: Rework this out.
            */
            for (var i = 0; i < requiredFiles.Length; i++) requiredFiles.SetValue(path + "\\" + requiredFiles[i], i);

            if (Directory.GetFiles(path).Count() > 0)
            {
                var files = Directory.GetFiles(path, "*.*", SearchOption.TopDirectoryOnly);
                if (files.Any(requiredFiles.Contains)) return true;
            }

            return false;
        }

    }
}