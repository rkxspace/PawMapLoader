using System;
using System.Collections.Generic;
using MelonLoader;
using PawMapLoader.Res.PawScript.Json;
using PawMapLoader.Res.UserConf;

namespace PawMapLoader.Res.PawScript
{
    public class Interpreter
    {
        public int Executions;
        public List<PawScriptInstruction> InstructionDumpReserve;
        public Dictionary<int, object> Memory = new Dictionary<int, object>();
        public Dictionary<string, int> NamedPtr = new Dictionary<string, int>();
        public int NextMemory;
        public bool scriptDebug => UConf.Properties.PawScriptDebug;

        // leaving for debugging
        public void Reset()
        {
            Memory.Clear();
            NamedPtr.Clear();
            NextMemory = 0;
            Executions = 0;
        }

        public void WriteMemory(object obj, int address = -1)
        {
            if (scriptDebug) MelonLogger.Msg($"WriteMemory {address}");
            if (obj == null) throw new NullReferenceException();
            if (address >= 0) {Memory[address] = obj; return;}
            while (Memory.ContainsKey(NextMemory))
                NextMemory++;
            Memory.Add(NextMemory, obj);
        }

        public void Interpret(PawScriptInstruction instruction, ref int instructionSetter)
        {
            Executions++;
            try
            {
                var methodText = instruction.Claw + "." + instruction.Instruction;
                if (scriptDebug) MelonLogger.Msg($"Instruction {instructionSetter}: {methodText} - Args: [{string.Join(", ", instruction.Arguments)}]");
                if (ClawRegister.rClaws.ContainsKey(methodText))
                {
                    ClawRegister.rClaws[methodText](instruction, ref instructionSetter, this);
                }
                else throw new MissingMethodException($"{methodText} does not exist.");
            }
            catch (Exception e)
            {
                MelonLogger.Error($"Instruction {instructionSetter}: {e.Message}");
                throw;
            }
        }
    }
}