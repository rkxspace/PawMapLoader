using System.Collections.Generic;
using PawMapLoader.Res.PawScript.Claws;

namespace PawMapLoader.Res.PawScript.Registers
{
    public class SceneClaw
    {
        public static readonly IReadOnlyDictionary<string, InstructionDelegate> cScene =
            new Dictionary<string, InstructionDelegate>
            {
                { "ObjectToMemory", Scene.ObjectToMemory },
                { "ImportObject", Scene.ImportObject }
            };
    }
}