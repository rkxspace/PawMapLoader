using System.Collections.Generic;
using Newtonsoft.Json;

namespace PawMapLoader.Res
{
    public class MapList
    {
        [JsonProperty("PawMapFileVersion")] public int PawMapFileVersion { get; set; }
        [JsonProperty("PawMaps")] public List<PawMap> PawMaps { get; set; }
    }
}