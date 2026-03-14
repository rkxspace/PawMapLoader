using System;
using MelonLoader;
using PawMapLoader.Res;
using PawMapLoader.Res.Enum;
using PawMapLoader.Res.Json;

namespace PawMapLoader
{
    public class Init
    {
        private static bool _ready = false;
        public static void InitMelon()
        {
            MelonLogger.Msg("InitMelon Called.");
            var rnd = new Random();
            var t = rnd.NextDouble();
            var s = rnd.NextDouble();
            Res.PawScript.Validation.RestrictedValidation.GetRestrictedClassesEnabled();
            if (Store.PawScript.PawScriptRestrictedClassesEnabled)
            {
                Store.PawScript.inversions = false;
            }
            else
            {
                Store.PawScript.inversions = true;
            }
            new RestrictedWatcher(s*Math.Cos(t));
            _ready = true;
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
            if (!_ready) return;
            FileManagement.EnsureCustomMapsDirectory();
            MapJson.Read();
            AssetManager.LoadMapData();
        }
    }
}