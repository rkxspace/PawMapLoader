using Il2CppSystem.IO;
using PawMapLoader.Res.Json;
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

        public class PawScript
        {
            public static bool PawScriptSetUp = false;

            // We don't want scripts using restricted classes by default, as they give more control over the game or system.
            // Turning this on will show a warning every time the menu is loaded.
            public static bool PawScriptRestrictedClassesEnabled = false;
        }

        // The harmony patches fire twice and I have no idea why.
        public class FirePrevention
        {
            public static bool IsGameStarted = false;
            public static bool HasBlockConfig = false;
        }
    }
}