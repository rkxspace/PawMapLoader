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
            harmonyInstance.PatchAll(typeof(BuildingsManager_Init_Patch));
            harmonyInstance.PatchAll(typeof(GameManager_OnLobbySceneLoaded_Patch));
            harmonyInstance.PatchAll(typeof(GameManager_StartGame_Patch));
            harmonyInstance.PatchAll(typeof(GroundDecalController_IsGroundConcrete_Patch));
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