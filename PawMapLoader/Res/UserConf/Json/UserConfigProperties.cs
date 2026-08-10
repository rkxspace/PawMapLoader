using MelonLoader.Utils;
using Newtonsoft.Json;

namespace PawMapLoader.Res.UserConf.Json
{
    public class UserConfigProperties
    {
        [JsonProperty("ErrorReportingEnabled")]
        public bool ErrorReportingEnabled = true;

        [JsonProperty("PawScriptDebug")] public bool PawScriptDebug = false;
        [JsonProperty("PawScriptEnabled")] public bool PawScriptEnabled = true;
        [JsonProperty("UserDataDirectory")] public string UserDataDirectory = MelonEnvironment.UserDataDirectory;
    }
}