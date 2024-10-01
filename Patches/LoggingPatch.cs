using ColossalFramework;
using FewerGameLogs;
using HarmonyLib;
using System;
using UnityEngine;

namespace FewerGameLogs.Patches
{
    [HarmonyPatch(typeof(CODebugBase<LogChannel>), nameof(CODebugBase<LogChannel>.Log), new Type[] { typeof(LogChannel), typeof(string), typeof(UnityEngine.Object), typeof(ErrorLevel) })]
    public class LogChannelPatch
    {
        public static bool Prefix(ErrorLevel el) => el == ErrorLevel.Error && ModSettings.LogError;
    }
    [HarmonyPatch(typeof(CODebugBase<InternalLogChannel>), nameof(CODebugBase<InternalLogChannel>.Log), new Type[] { typeof(InternalLogChannel), typeof(string), typeof(UnityEngine.Object), typeof(ErrorLevel) })]
    public class InternalLogChannelPatch
    {
        public static bool Prefix(ErrorLevel el) => el == ErrorLevel.Error && ModSettings.LogError;
    }
    [HarmonyPatch(typeof(PopsManager), "LogCallback")]
    public class PopsManagerPatch
    {
        public static bool Prefix() => false;
    }
    [HarmonyPatch(typeof(Debug), nameof(Debug.Log), new Type[] { typeof(object) })]
    public static class DebugLogPatch
    {
        public static bool Prefix(object message)
        {
            string msgStr = message?.ToString();
            return !msgStr.Contains("UPDATE LOOP");
        }
    }
}


