using ICities;
using System;
using System.Linq;
using WillCommons;

namespace FewerGameLogs
{
    public class Mod : PatcherModBase
    {
        public override string BaseName => "Fewer Game Logs";
        public override string Description => "Fewer outputting logs of the game itself";
        public override string HarmonyID => "Will258012.FewerGameLogs";
        public void OnSettingsUI(UIHelperBase helper)
        {
            ModSettings.Load();
            helper.AddCheckbox("Still Log game errors", ModSettings.LogError, isChecked =>
            {
                ModSettings.LogError = isChecked;
                ModSettings.Save();
            });
            helper.AddTextfield("Black List", ModSettings.BlackList, value =>
            {
                ModSettings.BlackList = value;
                ModSettings.Save();
            });
            helper.AddTextfield("White List", ModSettings.WhiteList, value =>
            {
                ModSettings.WhiteList = value;
                ModSettings.Save();
            });
        }
        public static string[] BlackList => ModSettings.BlackList
           .Split(new[] { "\",\"" }, StringSplitOptions.None)
           .Select(suffix => suffix.Trim('"'))
           .ToArray();
        public static string[] WhiteList => ModSettings.WhiteList
            .Split(new[] { "\",\"" }, StringSplitOptions.None)
            .Select(suffix => suffix.Trim('"'))
            .ToArray();
    }
}

