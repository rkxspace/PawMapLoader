using System.Collections.Generic;
using Newtonsoft.Json;

namespace PawMapLoader.Res.PawScript.Json
{
    public class PawScriptInstructions
    {
        [JsonProperty("EventScripts")] public List<PawScriptInstructions> EventScripts;
        [JsonProperty("Instructions")] public List<PawScriptInstruction> Instructions;
    }
}