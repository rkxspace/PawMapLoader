namespace PawMapLoader.Res
{
    //TODO
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Rendering;
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
                pipelineAsset.supportsCameraDepthTexture = false;
                pipelineAsset.supportsCameraOpaqueTexture = false;
                pipelineAsset.gpuResidentDrawerMode = GPUResidentDrawerMode.Disabled;
                pipelineAsset.additionalLightsRenderingMode = LightRenderingMode.Disabled;
                pipelineAsset.additionalLightsShadowResolutionTierHigh = 0;
                pipelineAsset.additionalLightsShadowResolutionTierMedium = 0;
                pipelineAsset.additionalLightsShadowResolutionTierLow = 0;
                pipelineAsset.apvScenesData = null;
                pipelineAsset.cascade2Split = 0;
                pipelineAsset.cascade3Split = new Vector2(0, 0);
                pipelineAsset.cascade4Split = new Vector2(0, 0);
                pipelineAsset.msaaSampleCount = 0;
                return pipelineAsset;
            }
        }
    }
}