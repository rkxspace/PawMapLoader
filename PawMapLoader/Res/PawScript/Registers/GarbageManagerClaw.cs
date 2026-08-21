using System.Collections.Generic;
using PawMapLoader.Res.PawScript.Claws;

namespace PawMapLoader.Res.PawScript.Registers
{
    public class GarbageManagerClaw
    {
        public static readonly IReadOnlyDictionary<string, InstructionDelegate> cGarbageManager =
            new Dictionary<string, InstructionDelegate>
            {
                { "Collect", GarbageManager.Collect }
            };
    }
}