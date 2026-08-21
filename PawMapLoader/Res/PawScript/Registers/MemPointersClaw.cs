using System.Collections.Generic;
using PawMapLoader.Res.PawScript.Claws;

namespace PawMapLoader.Res.PawScript.Registers
{
    public class MemPointersClaw
    {
        public static readonly IReadOnlyDictionary<string, InstructionDelegate> cMemPointers =
            new Dictionary<string, InstructionDelegate>
            {
                { "MkPointer", MemPointers.MkPointer },
                { "DelPointer", MemPointers.DelPointer }
            };
    }
}