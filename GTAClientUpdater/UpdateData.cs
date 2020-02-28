using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GTAClientUpdater
{
    [DataContract]
    internal class UpdateData
    {
        [DataMember] public static string Version { get; set; }

        [DataMember] public static string[] Changes { get; set; }

        [DataMember] public static bool IsLocked { get; set; }

        [DataMember] public static string DownloadURL { get; set; }

        [DataMember] public static string SupportURL { get; set; }
    }
}
