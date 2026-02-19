using System.Collections.Generic;
using Newtonsoft.Json;

namespace PawMapLoader.Res.PawScript.Json
{
    public class PawScriptInstruction
    {
        [JsonProperty("Arguments")] public List<string> Arguments;
        [JsonProperty("Delay")] public float Delay;
        [JsonProperty("Instruction")] public string Instruction;
    }
}