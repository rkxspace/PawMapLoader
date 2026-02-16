using Newtonsoft.Json;

namespace PawMapLoader.Res
{
    public class MapMetadata
    {
        [JsonProperty("GrowthRateModifier")] public float GrowthRateModifier { get; set; }
        [JsonProperty("GrowthShapeKeyStart")] public float GrowthShapeKeyStart { get; set; }
        [JsonProperty("GrowthShapeKeyEnd")] public float GrowthShapeKeyEnd { get; set; }
        [JsonProperty("Population")] public int Population { get; set; }
        [JsonProperty("ShadowDistanceMax")] public float ShadowDistanceMax { get; set; }
        [JsonProperty("ShadowHeightMax")] public float ShadowHeightMax { get; set; }
        [JsonProperty("SquareKilometers")] public int SquareKilometers { get; set; }
        [JsonProperty("UnlockedBy")] public string UnlockedBy { get; set; }
        [JsonProperty("UnlockTargetScore")] public int UnlockTargetScore { get; set; }

    }
}