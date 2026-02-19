using System.Collections.Generic;
using Newtonsoft.Json;

namespace PawMapLoader.Res.PawScript.Json
{
    public class PawScriptInstructions
    {
        [JsonProperty("Instructions")] public List<PawScriptInstruction> Instructions;
    }
}