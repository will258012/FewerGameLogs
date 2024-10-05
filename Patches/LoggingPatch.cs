using ColossalFramework;
using FewerGameLogs.Utils;
using HarmonyLib;
using System;
using System.Linq;
using UnityEngine;

namespace FewerGameLogs.Patches
{
    [HarmonyPatch(typeof(CODebugBase<LogChannel>), nameof(CODebugBase<LogChannel>.Log), new Type[] { typeof(LogChannel), typeof(string), typeof(UnityEngine.Object), typeof(ErrorLevel) })]
    public class LogChannelPatch
    {
        public static bool Prefix(string msg, ErrorLevel el)
        {
            if (el == ErrorLevel.Error && ModSettings.LogError) return true;
            if (ModSettings.WhiteList.IsNullOrWhiteSpace()) return false;
            return Log.WhiteList.Any(w => msg.Contains(w));
        }
    }

    [HarmonyPatch(typeof(CODebugBase<InternalLogChannel>), nameof(CODebugBase<InternalLogChannel>.Log), new Type[] { typeof(InternalLogChannel), typeof(string), typeof(UnityEngine.Object), typeof(ErrorLevel) })]
    public class InternalLogChannelPatch
    {
        public static bool Prefix(string msg, ErrorLevel el)
        {
            if (el == ErrorLevel.Error && ModSettings.LogError) return true;
            if (ModSettings.WhiteList.IsNullOrWhiteSpace()) return false;
            return Log.WhiteList.Any(w => msg.Contains(w));
        }
    }

    [HarmonyPatch(typeof(PopsManager), "LogCallback")]
    public class PopsManagerPatch
    {
        public static bool Prefix(string message)
        {
            if (ModSettings.WhiteList.IsNullOrWhiteSpace()) return false;
            return Log.WhiteList.Any(w => message.Contains(w));
        }
    }

    [HarmonyPatch(typeof(Debug), nameof(Debug.Log), new Type[] { typeof(object) })]
    public static class DebugLogPatch
    {
        public static bool Prefix(object message)
        {
            string msgStr = message?.ToString();
            if (string.IsNullOrEmpty(msgStr)) return false;
            return !(!ModSettings.BlackList.IsNullOrWhiteSpace() && Log.BlackList.Any(b => msgStr.Contains(b)));
        }
    }
}
