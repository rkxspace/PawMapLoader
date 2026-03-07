using PawMapLoader.Res.PawScript.Json;

namespace PawMapLoader.Res.PawScript.Claws
{
    public class MemPointers
    {
        public static void CreatePointer(PawScriptInstruction instruction, ref int instructionSetter, Interpreter interpreter)
        {
            int addr = int.Parse(instruction.Arguments[1]);
            if (addr > -1)
            {
                interpreter.NamedPtr.Add(instruction.Arguments[0], addr);
            }
        }

        public static void DestroyPointer(PawScriptInstruction instruction, ref int instructionSetter, Interpreter interpreter)
        {
            interpreter.NamedPtr.Remove(instruction.Arguments[0]);
        }
    }
}