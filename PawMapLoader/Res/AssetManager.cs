using System;
using System.Linq;
using Il2CppGame;
using MelonLoader;
using PawMapLoader.Res.Json;

namespace PawMapLoader.Res
{
    public class AssetManager
    {
        public static void LoadMapData()
        {
            var levels = LevelDataProvider.Instance._levels.ToList();
            
            foreach (PawMap pawMap in Store.Maps.PawMaps)
            {
                try
                {
                    MelonLogger.Msg("Adding " + pawMap.AssetFile + " data.");
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
                    
                    MelonLogger.Msg("Adding " + pawMap.AssetFile + " level data to list.");
                    levels.Add(sceneConfig);
                }
                catch (Exception e)
                {
                    MelonLogger.Error("Could not load PawBox:\n"+e);
                }
            }
            LevelDataProvider.Instance._levels =  levels.ToArray();
        }
    }
}