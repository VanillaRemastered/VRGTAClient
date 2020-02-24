using Microsoft.Win32;
using System;

namespace VanillaUpdater
{
    internal class VRegistry
    {
        private static RegistryKey _runKey;
        private static readonly string registryAddress = "Software\\Vanilla Remastered";

        /* BIG ASS NOTE: You don't need to create a function that creates the sub-folder 
         * creating a subkey will auto. create the sub-folder.
        */

        /// <summary>
        /// Returns registry subkey object value. 
        /// In case the key doesn't exist, it will return string '-'
        /// </summary>
        /// <param name="value">Name of the field (e.g Version)</param>
        /// <returns></returns>
        public static object GetSubKeyValue(string value)
        {
            using (_runKey = Registry.CurrentUser.OpenSubKey(registryAddress))
            {
                var returnKey = _runKey.GetValue(value);

                if (returnKey == null)
                    return "";

                return _runKey.GetValue(value);
            }
        }

        // TODO: Check if the key was submitted.
        public static void CreateSubKey(string subkey, string value)
        {
            _runKey = Registry.CurrentUser.CreateSubKey(registryAddress, true);

            _runKey.SetValue(subkey, value);
            _runKey.Close();
        }

        /// <summary>
        /// Checks if objects version & path are valid.
        /// </summary>
        /// <returns>true if they're both valid, false if they're not.</returns>
        public static bool IsFirstRun()
        {
            try
            {
                var pathKey = GetSubKeyValue("Path");
                var versionKey = GetSubKeyValue("Version");

                if (pathKey.Equals(string.Empty) || versionKey.Equals(string.Empty)) return true;

            }
            catch (Exception e)
            {
                return true;
            }

            return false;
        }
    }
}