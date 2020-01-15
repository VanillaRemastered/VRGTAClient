using Microsoft.Win32;
using System;

namespace VanillaUpdater
{
    class VRegistry
    {
        private static RegistryKey runKey = null;
        private static string registryAddress = "Software\\Vanilla Remastered";

        /* BIG ASS NOTE: You don't need to create a function that creates the sub-folder 
         * creating a subkey will auto. create the sub-folder.
        */

        /// <summary>
        /// Returns registry subkey object value.
        /// </summary>
        /// <param name="value">Name of the field (e.g Version)</param>
        /// <returns></returns>
        public static Object GetSubKeyValue(string value)
        {
            using (runKey = Registry.CurrentUser.OpenSubKey(registryAddress))
            {
                return runKey.GetValue(value);
            }
        }

        // TODO: Check if the key was submitted.
        public static void CreateSubKey(string subkey, string value)
        {
            runKey = Registry.CurrentUser.CreateSubKey(registryAddress, true);

            runKey.SetValue(subkey, value);
            runKey.Close();
        }

        /// <summary>
        /// Checks if objects version & path are valid.
        /// </summary>
        /// <returns>true if they're both valid, false if they're not.</returns>
        public static bool IsFirstRun()
        {
            if (GetSubKeyValue("Path").Equals(null))
            {
                return true;
            }

            return false;
        }
    }
}
