using Il2CppSystem.IO;
using PawMapLoader.Res.Json;
using UnityEngine;

namespace PawMapLoader.Res
{
    public class Store
    {
        public delegate void Update();

        public static MapList Maps;
        public static bool MapLoadLocked = false;
        public static bool IsMapCustom = false;

        public static AssetBundle LoadedAssetBundle;
        public static AssetBundle ExtraAssetBundle;

        public static Stream BundleStream;

        public static Update Udevnt = () => { };
        public static Update UdevntGUI = () => { };

        public class FirePrevention
        {
            public static bool IsGameStarted = false;
            public static bool HasBlockConfig = false;
        }
    }
}