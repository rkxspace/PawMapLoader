using System;
using HarmonyLib;
using Il2CppConfig;
using Il2CppEffects;
using Il2CppGame;
using Il2CppUtilities;
using MelonLoader;
using PawMapLoader.Res.Components;
using PawMapLoader.Res.Enum;
using PawMapLoader.Res.PawScript;
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
            if (scenename == "AtroCity" || scenename == "DownTown")
            {
                Store.IsMapCustom = false;
                return true;
            }

            if (Store.FirePrevention.IsGameStarted) return true;
            if (Store.MapLoadLocked) return false;
            if (Store.LoadedAssetBundle != null)
            {
                Store.BundleStream?.Close();
                Store.BundleStream?.Dispose();
                Store.FirePrevention.IsGameStarted = true;
                return true;
            }

            MelonLogger.Msg($"{scenename} is custom.");
            Store.BundleStream = null;
            try
            {
                Store.IsMapCustom = true;
                Store.BundleStream = FileManagement.OpenMapFile(scenename);
                Store.AdditiveBundleStream = FileManagement.OpenMapFile($"{scenename}_ADDITIVE");
                AsyncBundleLoader.LoadBundleAndStart();
            }
            catch (Exception e)
            {
                MelonLogger.Error(e.StackTrace);
                throw;
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

            if (!Store.IsMapCustom) return true;
            MelonLogger.Msg("Killing PawScript interpreters...");
            PawScriptRegister.StopAll();

            Store.LoadedAssetBundle?.Unload(true);
            Store.LoadedAssetBundle = null;
            Store.ExtraAssetBundle?.Unload(true);
            Store.ExtraAssetBundle = null;
            MelonLogger.Msg("Done.");
            return true;
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
                foreach (GameObject go in SceneManager
                             .GetSceneByName(ConfigManager.Instance.Level.Scene.SceneName).GetRootGameObjects())
                {
                    if (go.name == "SceneObjects")
                    {
                        go.AddComponent<SceneRoot>();
                    }

                    if (go.name == "SceneConfig")
                    {
                        GameObject cblock = new GameObject("CityBlock");
                        cblock.transform.SetParent(go.transform);
                        cblock.AddComponent<CityBlockGrid>();
                        Store.FirePrevention.HasBlockConfig = true;
                    }
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

    [HarmonyPatch(typeof(MeshCombinerService), nameof(MeshCombinerService.CombineBuildingBlockMeshes))]
    public static class MeshCombinerService_CombineBuildingBlockMeshes_Patch
    {
        [HarmonyPrefix]
        public static bool Prefix(MeshCombinerService __instance) => !Store.IsMapCustom;
    }

    [HarmonyPatch(typeof(MeshCombinerService), nameof(MeshCombinerService.CombineBuildingMesh))]
    public static class MeshCombinerService_CombineBuildingMesh_Patch
    {
        [HarmonyPrefix]
        public static bool Prefix(MeshCombinerService __instance) => !Store.IsMapCustom;
    }

    [HarmonyPatch(typeof(MeshCombinerService), nameof(MeshCombinerService.CombineBuildingMeshes))]
    public static class MeshCombinerService_CombineBuildingMeshes_Patch
    {
        [HarmonyPrefix]
        public static bool Prefix(MeshCombinerService __instance) => !Store.IsMapCustom;
    }
}