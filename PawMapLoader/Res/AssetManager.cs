using HarmonyLib;
using Il2CppGame;
using Il2CppSystem.IO;
using UnityEngine;

namespace PawMapLoader.Res
{
    public class AssetManager
    {
        public static void LoadAssetBundles()
        {
            foreach (PawMap pawMap in MapJson.Maps.PawMaps)
            {
                AssetBundle.LoadFromStream(FileManagement.OpenMapFile(pawMap.AssetFile));
                
                SceneConfig sceneConfig = new SceneConfig();
                sceneConfig.LevelName = pawMap.Name;
                sceneConfig.LeaderboardName = pawMap.LeaderboardName;
                sceneConfig.SceneName = pawMap.AssetFile;
                sceneConfig.GrowthRateModifier = pawMap.MapMetadata.GrowthRateModifier;
                sceneConfig.GrowthShapeScaleMin = pawMap.MapMetadata.GrowthShapeKeyStart;
                sceneConfig.GrowthShapeScaleMax = pawMap.MapMetadata.GrowthShapeKeyEnd;
                sceneConfig.Population = pawMap.MapMetadata.Population;
                sceneConfig.ShadowDistanceMax = pawMap.MapMetadata.ShadowDistanceMax;
                sceneConfig.ShadowHeightMax = pawMap.MapMetadata.ShadowHeightMax;
                sceneConfig.SquareKilometers = pawMap.MapMetadata.SquareKilometers;
                sceneConfig.UnlockedBy = null;
                sceneConfig.UnlockTargetScore = 0;
                
                LevelDataProvider.Instance._levels.AddItem(sceneConfig);
                LevelDataProvider.Instance.Levels.AddItem(sceneConfig);
            }
        }
    }
}