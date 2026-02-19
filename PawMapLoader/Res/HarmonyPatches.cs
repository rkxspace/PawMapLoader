using System;
using HarmonyLib;
using Il2CppConfig;
using Il2CppEffects;
using Il2CppGame;
using Il2CppLoadingScreen;
using Il2CppSystem.IO;
using MelonLoader;
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
            if (Store.FirePrevention.IsGameStarted) return true;
            
            Store.FirePrevention.IsGameStarted = true;
            
            MelonLogger.Msg("Get Selected Scene");
            string scenename = ConfigManager.Instance.Level.Scene.SceneName;
            Store.IsMapCustom = false;
            if (scenename == "AtroCity" || scenename == "DownTown") return true;
            
            MelonLogger.Msg(scenename + " is custom.");
            Stream stream = null;
            try
            {
                Store.IsMapCustom = true;
            
                MelonLogger.Msg("Loading " + scenename);
                MelonLogger.Msg("| Opening stream...");
                stream = FileManagement.OpenMapFile(scenename);
                
                MelonLogger.Msg("|| Done.");
                MelonLogger.Msg("| Loading From Stream...");
                Store.LoadedAssetBundle = AssetBundle.LoadFromStream(stream);
                
                MelonLogger.Msg("|| Done.");
                MelonLogger.Msg("Loaded " + scenename);
                MelonLogger.Msg("| Disposing stream...");
                stream?.Close();
                
                MelonLogger.Msg("|| Closed.");
                stream?.Dispose();
                
                MelonLogger.Msg("|| Disposed.");
            }
            catch (Exception e)
            {
                Store.FirePrevention.IsGameStarted = false;
                
                MelonLogger.Error("Failed to load bundle " + e);
                stream?.Close();
                stream?.Dispose();
            }

            return true;
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