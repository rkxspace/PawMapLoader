namespace PawMapLoader.Res
{
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Rendering.Universal;

    public enum QualitySettings
    {
        Potato,
        VeryLow,
        Low,
        Medium,
        High,
        VeryHigh
    }

    public class GameGraphicsSettings
    {
        public static Dictionary<QualitySettings, UniversalRenderPipelineAsset> qualitySettings;

        public class URPAssetCreator
        {
            public static void Entry() { }

            public static UniversalRenderPipelineAsset CreatePotato()
            {
                UniversalRenderPipelineAsset pipelineAsset =
                    ScriptableObject.CreateInstance<UniversalRenderPipelineAsset>();
                pipelineAsset.additionalLightsRenderingMode = LightRenderingMode.Disabled;
                // pipelineAsset.additionalLightsShadowmapResolution = 
            }
        }
    }
}