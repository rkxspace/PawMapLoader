using System;
using HarmonyLib;
using Il2CppConfig;
using Il2CppEffects;
using Il2CppGame;
using Il2CppLoadingScreen;
using MelonLoader;
using PawMapLoader.Res.Abstractions;
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
            Store.IsMapCustom = false;
            if (scenename == "AtroCity" || scenename == "DownTown") return true;
            try
            {
                Store.IsMapCustom = true;
                MelonLogger.Msg("Loading " + scenename);
                var stream = FileManagement.OpenMapFile(scenename);
                Store.LoadedAssetBundle = AssetBundle.LoadFromStream(stream);
                MelonLogger.Msg("Loaded " + scenename);
                stream.Close();
                stream.Dispose();
            }
            catch (Exception e)
            {
                MelonLogger.Error("Failed to load bundle " + e);
            }

            return true;
        }
    }

    [HarmonyPatch(typeof(GameManager), nameof(GameManager.GoToMainMenu))]
    public static class GameManager_GoToMainMenu_Patch
    {
        [HarmonyPrefix]
        public static bool Prefix(GameManager __instance)
        {
            if (!Store.IsMapCustom) return true;
            Store.LoadedAssetBundle?.Unload(true);
            Store.LoadedAssetBundle = null;
            return true;
        }
    }

    [HarmonyPatch(typeof(LoadingScreenController), nameof(LoadingScreenController.Show))]
    public static class LoadingScreenController_Show_Patch
    {
        [HarmonyPrefix]
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
            if (AbUe.GetTypeAll<CityBlockGrid>()[0] == null)
            {
                foreach (var go in SceneManager
                             .GetSceneByName(GameManager._instance.GameplaySceneName).GetRootGameObjects())
                {
                    if (go.name == "SceneConfig")
                    {
                        var cblock = new GameObject("CityBlock");
                        cblock.transform.SetParent(go.transform);
                        cblock.AddComponent<CityBlockGrid>();
                        break;
                    }
                }
                GameManager._instance.OnGameplaySceneLoaded();
            }
        }
    }

    [HarmonyPatch(typeof(GroundDecalController), nameof(GroundDecalController.IsGroundConcrete))]
    public static class GroundDecalController_IsGroundConcrete_Patch
    {
        [HarmonyPrefix]
        public static bool Prefix(GroundDecalController __instance, bool __result)
        {
            if (Store.IsMapCustom)
            {
                __result = false;
                return false;
            }
            return true;
        }

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