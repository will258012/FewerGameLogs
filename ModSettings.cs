using ColossalFramework.IO;
using System.IO;
using System.Xml.Serialization;
using WillCommons;

namespace FewerGameLogs
{
    [XmlRoot("FewerGameLogs")]
    public sealed class ModSettings : XMLFileBase
    {
        [XmlIgnore]
        private static readonly string SettingsFileName = Path.Combine(DataLocation.localApplicationData, "FewerGameLogs.xml");

        internal static void Load() => Load<ModSettings>(SettingsFileName);

        internal static void Save() => Save<ModSettings>(SettingsFileName);
        [XmlElement("LogError")]
        public bool XMLLogError { get => LogError; set => LogError = value; }
        [XmlIgnore]
        internal static bool LogError = false;
        [XmlElement("BlackList")]
        public string XMLBlackList { get => BlackList; set => BlackList = value; }
        [XmlIgnore]
        internal static string BlackList = "\"UPDATE LOOP\"";

        [XmlElement("WhiteList")]
        public string XMLWhiteList { get => WhiteList; set => WhiteList = value; }
        [XmlIgnore]
        internal static string WhiteList = "";
    }
}
