using System.Collections.Generic;
using PawMapLoader.Res.PawScript.Claws;

namespace PawMapLoader.Res.PawScript.Registers
{
    public class MapClaw
    {
        public static readonly IReadOnlyDictionary<string, InstructionDelegate> cMap =
            new Dictionary<string, InstructionDelegate>
            {
                { "MoveObject", Map.MoveObject },
                { "RotateObject", Map.RotateObject },
                { "ScaleObject", Map.ScaleObject },
                { "DestroyObject", Map.DestroyObject }
            };
    }
}