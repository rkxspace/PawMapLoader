using System.Collections.Generic;
using Il2CppSystem.IO;
using PawMapLoader.Res.Json;
using PawMapLoader.Res.PawScript.Json;
using UnityEngine;

namespace PawMapLoader.Res
{
    public class Store
    {
        public static MapList Maps;
        public static bool MapLoadLocked = false;
        public static bool IsMapCustom = false;

        public static AssetBundle LoadedAssetBundle;
        public static AssetBundle ExtraAssetBundle;

        public static Stream BundleStream;

        public static Dictionary<string, PawScriptInstructions> ScriptCache =
            new Dictionary<string, PawScriptInstructions>();

        public class FirePrevention
        {
            public static bool IsGameStarted = false;
            public static bool HasBlockConfig = false;
        }
    }
}