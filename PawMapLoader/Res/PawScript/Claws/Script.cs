using PawMapLoader.Res.PawScript.Json;

namespace PawMapLoader.Res.PawScript.Claws
{
    public class Script
    {
        public static void Jump(PawScriptInstruction instruction, ref int instructionSetter, Interpreter interpreter)
        {
            instructionSetter = int.Parse(instruction.Arguments[0]);
        }
    }
}