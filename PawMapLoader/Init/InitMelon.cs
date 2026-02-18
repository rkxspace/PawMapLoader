using PawMapLoader.Res.Enum;
using PawMapLoader.Res.Json;

namespace PawMapLoader
{
    public class Init
    {
        public static void InitMelon()
        {
            var harmonyInstance =  new HarmonyLib.Harmony("space.rkx.pawmaploader");
            harmonyInstance.PatchAll();
            
            LevelDataProvider.WaitForDataProvider();
        }

        public static void InitMaps()
        {
            Res.FileManagement.EnsureCustomMapsDirectory();
            MapJson.Read();
            Res.AssetManager.LoadMapData();
        }
    }
}