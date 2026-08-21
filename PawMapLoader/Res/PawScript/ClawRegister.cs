using System.Collections.Generic;
using PawMapLoader.Res.PawScript.Json;
using PawMapLoader.Res.PawScript.Registers;

namespace PawMapLoader.Res.PawScript
{
    public delegate void InstructionDelegate(PawScriptInstruction instruction, ref int instructionSetter,
        Interpreter interpreter);

    public class ClawRegister
    {
        public static readonly IReadOnlyDictionary<string, IReadOnlyDictionary<string, InstructionDelegate>> rClaws =
            new Dictionary<string, IReadOnlyDictionary<string, InstructionDelegate>>
            {
                { "GarbageManager", GarbageManagerClaw.cGarbageManager },
                { "MemPointers", MemPointersClaw.cMemPointers },
                { "GameState", GameStateClaw.cGameState },
                { "Animator", AnimatorClaw.cAnimator },
                { "Player", PlayerClaw.cPlayer },
                { "Script", ScriptClaw.cScript },
                { "Scene", SceneClaw.cScene },
                { "Math", MathClaw.cMath },
                { "Map", MapClaw.cMap }
            };
    }
}