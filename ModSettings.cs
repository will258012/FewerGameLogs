using ColossalFramework.IO;
using FewerGameLogs.Utils;
using System.IO;
using System.Xml.Serialization;

namespace FewerGameLogs
{
    [XmlRoot("FewerGameLogs")]
    public sealed class ModSettings
    {
        [XmlIgnore]
        private static readonly string SettingsFileName = Path.Combine(DataLocation.localApplicationData, "FewerGameLogs.xml");

        internal static void Load() => XMLFileUtils.Load<ModSettings>(SettingsFileName);

        internal static void Save() => XMLFileUtils.Save<ModSettings>(SettingsFileName);
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
