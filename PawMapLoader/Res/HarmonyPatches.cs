using HarmonyLib;
using Il2CppEffects;
using Il2CppGame;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppLoadingScreen;
using UnityEngine;

namespace PawMapLoader.Res
{
    [HarmonyPatch(typeof(GameManager), nameof(GameManager.StartGame))]
    public static class GameManager_StartGame_Patch
    {
        [HarmonyPrefix]
        public static bool Prefix(GameManager __instance)
        {
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
            Store.IsMapCustom = false;
            if (UnityEngine.Resources.FindObjectsOfTypeAll<CityBlockGrid>()[0] == null)
            {
                Store.IsMapCustom = true;
                foreach (var go in UnityEngine.SceneManagement.SceneManager
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
    }
}