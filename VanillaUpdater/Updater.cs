﻿using Microsoft.AppCenter.Analytics;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace VanillaUpdater
{
    internal static class Updater
    {
        /// <summary>
        /// Fetches a file via webclient>
        /// </summary>
        /// <param name="url">The file URL.</param>
        /// <returns>string data.</returns>
        public static string GetFileViaHttpString(string url)
        {
            using (var client = new WebClient())
            {
                return client.DownloadString(url);
            }
        }

        /// <summary>
        /// Fetches the json file from the web and parses it.
        /// </summary>
        private static void FetchVersion()
        {
            ConsoleWrapper.PrintMessage("Fetching master list from: http://www.vanilla-remastered.com/files/latest.json",
                ConsoleWrapper.PrintStatus.Normal);

            var versionObjRaw = GetFileViaHttpString("http://www.vanilla-remastered.com/files/latest.json");
            var update = JsonConvert.DeserializeObject<UpdateData>(versionObjRaw);
        }

        /// <summary>
        /// Checks if a new version is available by first fetching the new version number from the 
        /// website and then comparing local version number with fetched one.
        /// </summary>
        /// <returns></returns>
        public static bool IsNewVersionAvailable()
        {
            FetchVersion();

            if (VRegistry.GetSubKeyValue("Version").Equals(null)) VRegistry.CreateSubKey("Version", "0.0.0");
            if (!VRegistry.GetSubKeyValue("Version").ToString().Equals(UpdateData.Version))
                return true;
            return false;
        }

        /// <summary>
        /// Tries to safely files from a rar file.
        /// </summary>
        /// <param name="archive"></param>
        /// <param name="destinationDirectoryName"></param>
        /// <param name="overwrite"></param>
        public static void ExtractToDirectory(ZipArchive archive, string destinationDirectoryName, bool overwrite)
        {
            if (!overwrite)
            {
                archive.ExtractToDirectory(destinationDirectoryName);
                return;
            }

            var di = Directory.CreateDirectory(destinationDirectoryName);
            var destinationDirectoryFullPath = di.FullName;

            foreach (var file in archive.Entries)
            {
                var completeFileName = Path.GetFullPath(Path.Combine(destinationDirectoryFullPath, file.FullName));

                if (completeFileName.Contains("WeaponsSoundPlugin"))
                    continue;

                if (!completeFileName.StartsWith(destinationDirectoryFullPath, StringComparison.OrdinalIgnoreCase))
                    throw new IOException(
                        "Trying to extract file outside of destination directory. See this link for more info: https://snyk.io/research/zip-slip-vulnerability");

                if (file.Name.Length == 0)
                {
                    // Assuming Empty for Directory
                    Directory.CreateDirectory(Path.GetDirectoryName(completeFileName));
                    continue;
                }

                file.ExtractToFile(completeFileName, true);
            }
        }


        /// <summary>
        ///  removes the older version.
        /// </summary>
        /// <param name="codeName"></param>
        public static void RemoveOlderUpdate(string codeName)
        {
            string file_120 = Properties.Resources.VR12Files;
            string file_130 = Properties.Resources.VR13Files;


            string path = VRegistry.GetSubKeyValue("Path").ToString();

            if (codeName == "1.2.0")
            {
                var lines = file_120.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                foreach (var line in lines)
                {
                    string pathDel = path + "\\" + line;

                    if (File.Exists(pathDel))
                    {
                        File.SetAttributes(pathDel, FileAttributes.Normal);
                        File.Delete(pathDel);

                        ConsoleWrapper.PrintMessage("Deleting previous data chunk (" + pathDel + ")",
                            ConsoleWrapper.PrintStatus.Warning);
                    }
                    else ConsoleWrapper.PrintMessage("Skipping file " + pathDel, ConsoleWrapper.PrintStatus.Normal);
                }

            }

            if (codeName == "1.3.0")
            {
                var lines = file_130.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                foreach (var line in lines)
                {
                    string pathDel = path + "\\" + line;

                    if (File.Exists(pathDel))
                    {
                        File.SetAttributes(pathDel, FileAttributes.Normal);
                        File.Delete(pathDel);

                        ConsoleWrapper.PrintMessage("Deleting previous 1.3.0 data chunk (" + pathDel + ")",
                            ConsoleWrapper.PrintStatus.Warning);
                    }
                    else ConsoleWrapper.PrintMessage("Skipping file " + pathDel, ConsoleWrapper.PrintStatus.Normal);

                }
            }
        }

        /// <summary>
        /// Installs Vanilla Remastered.
        /// </summary>
        /// <param name="codeName"></param>
        public static void InstallVanilla(string codeName)
        {

        }

        /// <summary>
        /// Attempts to install the actual update and returns true if no exceptions occured.
        /// </summary>
        /// <returns>bool</returns>
        public static bool InstallUpdate()
        {
            if (Directory.Exists("update")) Directory.Delete("update", true);

            try
            {
                var extractionPath = VRegistry.GetSubKeyValue("Path").ToString().Replace("/", "\\");

                var archive = ZipFile.OpenRead("data_" + UpdateData.Version + ".rar");
                ExtractToDirectory(archive, extractionPath, true);
            }
            catch (Exception e)
            {
                MessageBox.Show("Update has failed to install.\n\nError code: " + e.Message, "An error occured");
                return false;
            }

            Analytics.TrackEvent("Update has been installed!", new Dictionary<string, string>
            {
                {"Version", UpdateData.Version}
            });

            VRegistry.CreateSubKey("Version", UpdateData.Version);
            return true;
        }
    }

    [DataContract]
    internal class UpdateData
    {
        [DataMember] public static string Version { get; set; }

        [DataMember] public static string Author { get; set; }

        [DataMember] public static string[] Changes { get; set; }

        [DataMember] public static DateTime Date { get; set; }

        [DataMember] public static string[] AffectedFiles { get; set; }

        [DataMember] public static string DownloadURL { get; set; }

        [DataMember] public static string SupportURL { get; set; }
    }
}