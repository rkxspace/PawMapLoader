using System;
using System.Collections.Generic;
using System.Linq;
using Il2CppGame;
using MelonLoader;
using PawMapLoader.Res.Json;

namespace PawMapLoader.Res
{
    public static class AssetManager
    {
        public static void LoadMapData()
        {
            List<SceneConfig> levels = LevelDataProvider.Instance._levels.ToList();
            Dictionary<string, SceneConfig> mapLkUpData = new Dictionary<string, SceneConfig>();
            foreach (PawMap pawMap in Store.Maps.PawMaps)
            {
                try
                {
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
                    // TODO: ADD LINKING
                    sceneConfig.UnlockedBy = null;
                    sceneConfig.UnlockTargetScore = 0;
                    levels.Add(sceneConfig);
                    mapLkUpData.Add(sceneConfig.LeaderboardName, sceneConfig);
                }
                catch (Exception e)
                {
                    MelonLogger.Error($"{Strings.GetString("LevelDataAddFail")}\n{e}");
                }
            }
            LevelDataProvider.Instance._levels = levels.ToArray();
        }
    }
}