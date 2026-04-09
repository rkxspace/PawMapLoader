using System;
using System.Windows.Forms;
using HarmonyLib;
using Il2CppConfig;
using Il2CppDestructibles;
using Il2CppEffects;
using Il2CppGame;
using Il2CppUtilities;
using MelonLoader;
using PawMapLoader.Res.Components;
using PawMapLoader.Res.Enum;
using UnityEngine;
using UnityEngine.SceneManagement;
using Math = Il2CppSystem.Math;

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
                Store.BundleStream?.Close();
                Store.BundleStream?.Dispose();
                Store.FirePrevention.IsGameStarted = true;
                return true;
            }
            MelonLogger.Msg(scenename + " is custom.");
            if (Store.PawScript.PawScriptRestrictedClassesEnabled) {
                MessageBox.Show("Warning!", "You have Restricted PawScript classes enabled!\n" +
                                    "This means maps have more control over the game, and by extension your computer.\n" +
                                    "Do NOT run maps you have not personally vetted!" + "If you have not vetted the map, do so now.");
            }
            Store.BundleStream = null;
            try
            {
                Store.IsMapCustom = true;
                Store.BundleStream = FileManagement.OpenMapFile(scenename);
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

    [HarmonyPatch(typeof(BuildingsManager), nameof(BuildingsManager.Init))]
    public static class BuildingsManager_Init_Patch
    {
        [HarmonyPrefix]
        public static void Prefix(BuildingsManager __instance)
        {
            if (Store.FirePrevention.HasBlockConfig) return;
            if (Store.IsMapCustom)
            {
                foreach (var go in SceneManager
                             .GetSceneByName(ConfigManager.Instance.Level.Scene.SceneName).GetRootGameObjects())
                {
                    if (go.name == "SceneObjects")
                    {
                        go.AddComponent<SceneRoot>();
                    }
                    if (go.name == "SceneConfig")
                    {
                        var cblock = new GameObject("CityBlock");
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

    [HarmonyPatch(typeof(Damageable), nameof(Damageable.AddDamage))]
    public static class Damageable_AddDamage_Patch
    {
        [HarmonyPrefix]
        public static bool Prefix(Damageable __instance, Damage __0)
        {
            if (Store.IsMapCustom)
            {
                __0.Player.Character.AddGrow(Math.Clamp(__0.Amount/100, 0.0f, __instance.Health));
                __instance.Health -= __0.Amount;
                return false;
            }
            return true;
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