using System;
using HarmonyLib;
using Il2CppConfig;
using Il2CppEffects;
using Il2CppGame;
using Il2CppLoadingScreen;
using MelonLoader;
using PawMapLoader.Res.Enum;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PawMapLoader.Res
{
    [HarmonyPatch(typeof(GameManager), nameof(GameManager.StartGame))]
    public static class GameManager_StartGame_Patch
    {
        [HarmonyPrefix]
        public static bool Prefix(GameManager __instance)
        {
            string scenename = ConfigManager.Instance.Level.Scene.SceneName;
            if (scenename == "AtroCity" || scenename == "DownTown") {Store.IsMapCustom = false; return true;}
            if (Store.FirePrevention.IsGameStarted) return true;
            if (Store.MapLoadLocked) return false;
            if (Store.LoadedAssetBundle != null)
            {
                MelonLogger.Msg("|| Done.");
                MelonLogger.Msg("Loaded " + ConfigManager.Instance.Level.Scene.SceneName);
                MelonLogger.Msg("| Disposing stream...");
                Store.BundleStream?.Close();

                MelonLogger.Msg("|| Closed.");
                Store.BundleStream?.Dispose();

                MelonLogger.Msg("|| Disposed.");
                
                Store.FirePrevention.IsGameStarted = true;
                return true;
            }
            MelonLogger.Msg(scenename + " is custom.");
            Store.BundleStream = null;
            try
            {
                Store.IsMapCustom = true;
            
                MelonLogger.Msg("Loading " + scenename);
                MelonLogger.Msg("| Opening stream...");
                Store.BundleStream = FileManagement.OpenMapFile(scenename);
                
                MelonLogger.Msg("|| Done.");
                MelonLogger.Msg("| Loading From Stream...");
                
                AsyncBundleLoader.LoadBundleAndStart(Store.BundleStream);
            }
            catch (Exception e)
            {
                MelonLogger.Error(e.StackTrace);
            }

            return false;
        }
    }

    [HarmonyPatch(typeof(GameManager), nameof(GameManager.OnLobbySceneLoaded))]
    public static class GameManager_OnLobbySceneLoaded_Patch
    {
        [HarmonyPrefix]
        public static bool Prefix(GameManager __instance)
        {
            if (!Store.FirePrevention.IsGameStarted) return true;
            Store.FirePrevention.IsGameStarted = false;
            Store.FirePrevention.HasBlockConfig = false;
            
            MelonLogger.Msg("Unloading Scene Assetbundle");
            if (!Store.IsMapCustom) return true;
            Store.LoadedAssetBundle?.Unload(true);
            Store.LoadedAssetBundle = null;
            MelonLogger.Msg("Done.");
            return true;
        }
    }

    [HarmonyPatch(typeof(LoadingScreenController), nameof(LoadingScreenController.Show))]
    public static class LoadingScreenController_Show_Patch
    {
        [HarmonyPostfix]
        public static void Postfix(LoadingScreenController __instance)
        {
            __instance.Hide();
        }
    }

    [HarmonyPatch(typeof(BuildingsManager), nameof(BuildingsManager.Init))]
    public static class BuildingsManager_Init_Patch
    {
        [HarmonyPrefix]
        public static void Prefix(BuildingsManager __instance)
        {
            if (Store.FirePrevention.HasBlockConfig) return;
            if (Store.IsMapCustom)
            {
                MelonLogger.Msg("Finding SceneConfig");
                foreach (var go in SceneManager
                             .GetSceneByName(ConfigManager.Instance.Level.Scene.SceneName).GetRootGameObjects())
                {
                    if (go.name == "SceneConfig")
                    {
                        MelonLogger.Msg("| \"" + go.name + "\" is SceneConfig.");
                        var cblock = new GameObject("CityBlock");
                        cblock.transform.SetParent(go.transform);
                        cblock.AddComponent<CityBlockGrid>();
                        Store.FirePrevention.HasBlockConfig = true;
                        break;
                    }
                    MelonLogger.Msg("| \"" + go.name + "\" is not SceneConfig");
                }
            }
        }
    }

    [HarmonyPatch(typeof(GroundDecalController), nameof(GroundDecalController.IsGroundConcrete))]
    public static class GroundDecalController_IsGroundConcrete_Patch
    {
        [HarmonyFinalizer]
        public static Exception Finalizer(Exception __exception, ref bool __result)
        {
            
            if (__exception is IndexOutOfRangeException)
            {
                __result = false;
                return null;
            }
            return __exception;
        }
    }
}