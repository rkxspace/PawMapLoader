using PawMapLoader.Res.PawScript.Json;
using PawMapLoader.Res.PawScript.Resolvers;

namespace PawMapLoader.Res.PawScript.Claws
{
    public class Script
    {
        public static void Jump(PawScriptInstruction instruction, ref int instructionSetter, Interpreter interpreter)
        {
            instructionSetter = int.Parse(instruction.Arguments[0]);
        }

        public static void ConditionalJump(PawScriptInstruction instruction, ref int instructionSetter,
            Interpreter interpreter)
        {
            var mode = instruction.Arguments[0]??"S";
            var input1 = instruction.Arguments[1]??null;
            var input2 = instruction.Arguments[2]??null;
            var jumpTo = int.TryParse(instruction.Arguments[3], out _) ? int.Parse(instruction.Arguments[3]) : instructionSetter;

            if (mode == "S")
            {
                if (input1 == input2)
                {
                    instructionSetter = jumpTo;
                }
            }
            else if (mode == "D") 
                if (PointerResolver.ResolvePointer(input1, interpreter) == PointerResolver.ResolvePointer(input2, interpreter))
                    instructionSetter = jumpTo;
        }
    }
}