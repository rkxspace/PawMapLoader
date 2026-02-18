using Newtonsoft.Json;

namespace PawMapLoader.Res.Json
{
    public class PawMap
    {
        [JsonProperty("Name")] public string Name { get; set; }
        [JsonProperty("LeaderboardName")] public string LeaderboardName { get; set; }
        [JsonProperty("Description")] public string Description { get; set; }
        [JsonProperty("AssetFile")] public string AssetFile { get; set; }
        [JsonProperty("MapMetadata")] public MapMetadata MapMetadata { get; set; }
    }
}