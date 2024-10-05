using FewerGameLogs.Utils;
using ICities;
using System.Reflection;

namespace FewerGameLogs
{
    public class Mod : IUserMod, ILoadingExtension
    {
        public string Name => "Fewer Game Logs v" + ModVersion;
        public string Description => "Fewer outputting logs of the game itself";
        private const string HarmonyId = "Will258012.FewerGameLogs";

        private string ModVersion
        {
            get
            {
                var assemblyVersion = ModAssembly.GetName().Version;
                return $"{assemblyVersion.Major}.{assemblyVersion.Minor}.{assemblyVersion.Build}";
            }
        }
        public void OnEnabled() => HarmonyPatcher.PatchOnReady(ModAssembly, HarmonyId);

        public void OnCreated(ILoading loading)
        {

        }
        public void OnLevelLoaded(LoadMode mode)
        {

        }

        public void OnLevelUnloading()
        {

        }
        public void OnReleased()
        {
        }

        public void OnDisabled() => HarmonyPatcher.TryUnpatch(HarmonyId);
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
        private Assembly ModAssembly => Assembly.GetExecutingAssembly();

    }
}
