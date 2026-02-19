using PawMapLoader.Res.Json;
using UnityEngine;

namespace PawMapLoader.Res
{
    public class Store
    {
        public static MapList Maps;
        public static bool IsMapCustom = false;
        public static AssetBundle LoadedAssetBundle;

        // The harmony patches fire twice and I have no idea why.
        public class FirePrevention
        {
            public static bool IsGameStarted = false;
            public static bool HasBlockConfig = false;
        }
    }
}