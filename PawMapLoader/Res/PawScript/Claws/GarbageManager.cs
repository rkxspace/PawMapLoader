namespace PawMapLoader.Res.PawScript.Claws
{
    using System.Collections.Generic;
    using Json;

    public class GarbageManager
    {
        public static void Collect(PawScriptInstruction instruction, ref int instructionSetter, Interpreter interpreter)
        {
            List<int> discardable = new List<int>();
            foreach (KeyValuePair<int, object> valPair in interpreter.RtMemory.Memory)
            {
                if (!interpreter.RtMemory.NamedPtr.ContainsValue(valPair.Key)) discardable.Add(valPair.Key);
            }

            foreach (int mem in discardable)
            {
                interpreter.RtMemory.Memory.Remove(mem);
            }
        }
    }
}