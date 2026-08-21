using System.Collections.Generic;
using PawMapLoader.Res.PawScript.Claws;

namespace PawMapLoader.Res.PawScript.Registers
{
    public class ScriptClaw
    {
        public static readonly IReadOnlyDictionary<string, InstructionDelegate> cScript =
            new Dictionary<string, InstructionDelegate>
            {
                { "ConditionalJump", Script.ConditionalJump },
                { "Jump", Script.Jump },
                { "Dump", Script.Dump },
                { "Log", Script.Log }
            };
    }
}