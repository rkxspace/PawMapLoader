using MelonLoader;
using PawMapLoader.Res;
using PawMapLoader.Res.Enum;
using PawMapLoader.Res.Json;

namespace PawMapLoader
{
    public class Init
    {
        public static void InitMelon()
        {
            MelonLogger.Msg("InitMelon Called.");
            MelonLogger.Msg("Patching stuff...");
            var harmonyInstance =  new HarmonyLib.Harmony("space.rkx.pawmaploader");
            harmonyInstance.PatchAll();
            MelonLogger.Msg("Patching complete.");
            
            LevelDataProvider.WaitForDataProvider();
        }

        public static void InitMaps()
        {
            FileManagement.EnsureCustomMapsDirectory();
            MapJson.Read();
            AssetManager.LoadMapData();
        }
    }
}