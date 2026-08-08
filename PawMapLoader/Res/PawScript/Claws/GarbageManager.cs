using System.Collections.Generic;
using PawMapLoader.Res.PawScript.Json;

namespace PawMapLoader.Res.PawScript.Claws
{
    public class GarbageManager
    {
        public static void Collect(PawScriptInstruction instruction, ref int instructionSetter, Interpreter interpreter)
        {
            List<int> discardable = new List<int>();
            foreach (KeyValuePair<int, object> valPair in interpreter.Memory)
            {
                if (!interpreter.NamedPtr.ContainsValue(valPair.Key)) discardable.Add(valPair.Key);
            }

            foreach (int mem in discardable)
            {
                interpreter.Memory.Remove(mem);
            }
        }
    }
}