using System;
using System.Collections.Generic;
using HarmonyLib;
using Il2CppGame;
using Il2CppSystem.IO;
using MelonLoader;
using UnityEngine;

namespace PawMapLoader.Res
{
    public class AssetManager
    {
        public static void LoadAssetBundles()
        {
            var levels = new List<SceneConfig>();
            
            foreach (var lvl in LevelDataProvider.Instance._levels)
            {
                levels.Add(lvl);
            }
            
            foreach (PawMap pawMap in MapJson.Maps.PawMaps)
            {
                MelonLogger.Msg("Loading " + pawMap.AssetFile);
                var stream = FileManagement.OpenMapFile(pawMap.AssetFile);
                try
                {
                    var bundle = AssetBundle.LoadFromStream(stream);
                    
                    MelonLogger.Msg("Loaded " + pawMap.AssetFile + "\nContents of bundle: " + bundle.GetAllScenePaths()[0].ToString());
                    
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