using System;
using System.Linq;
using UnityEngine;

namespace FewerGameLogs.Utils
{
    public class Log
    {
        public const string TAG = "[FewerGameLogs] ";
        public static void Msg(string msg) => Debug.Log(TAG + msg);
        public static void Warn(string msg) => Debug.LogWarning(TAG + msg);
        public static void Err(string msg) => Debug.LogError(TAG + msg);
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
