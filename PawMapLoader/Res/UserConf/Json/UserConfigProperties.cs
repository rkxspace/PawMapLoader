using Newtonsoft.Json;

namespace PawMapLoader.Res.UserConf.Json
{
    public class UserConfigProperties
    {
        [JsonProperty("ErrorReportingEnabled")] public bool ErrorReportingEnabled = true;
        [JsonProperty("PawScriptEnabled")] public bool PawScriptEnabled = true;
        [JsonProperty("PawScriptDebug")] public bool PawScriptDebug = false;
    }
}