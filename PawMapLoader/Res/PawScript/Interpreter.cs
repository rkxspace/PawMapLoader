using System;
using System.Collections.Generic;
using MelonLoader;
using PawMapLoader.Res.PawScript.Json;

namespace PawMapLoader.Res.PawScript
{
    public class Interpreter
    {
        public int Executions;
        public List<PawScriptInstruction> InstructionDumpReserve;
        public Dictionary<int, object> Memory = new Dictionary<int, object>();
        public Dictionary<string, int> NamedPtr = new Dictionary<string, int>();
        public int NextMemory;

        public void Reset()
        {
            Memory.Clear();
            NamedPtr.Clear();
            NextMemory = 0;
            Executions = 0;
        }

        public void WriteMemory(object obj, int address = -1)
        {
            if (obj == null) throw new NullReferenceException();
            if (address >= 0) {Memory[address] = obj; return;}
            for (int i = 0; i < 1; i++)
            {
                if (Memory.ContainsKey(NextMemory)) {
                    NextMemory++;
                    i--;
                }
                else
                {
                    Memory.Add(NextMemory, obj);
                    NextMemory++;
                }
            }
        }

        public void Interpret(PawScriptInstruction instruction, ref int instructionSetter)
        {
            Executions++;
            try
            {
                var args = new object[] { instruction, instructionSetter, this};
                var methodText = instruction.Claw + "." + instruction.Instruction;
                if (ClawRegister.rClaws.ContainsKey(methodText))
                {
                    ClawRegister.rClaws[methodText].Invoke(null, args);
                    instructionSetter = (int)args[1];
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