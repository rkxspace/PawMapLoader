using System;
using System.Collections.Generic;
using System.Reflection;
using MelonLoader;
using PawMapLoader.Res.PawScript.Json;

namespace PawMapLoader.Res.PawScript
{
    public class Interpreter
    {
        public Dictionary<string, MethodInfo> CachedMethods = new Dictionary<string, MethodInfo>();
        public int Executions = 0;
        public List<PawScriptInstruction> InstructionDumpReserve;
        public Dictionary<int, object> Memory = new Dictionary<int, object>();
        public Dictionary<string, int> NamedPtr = new Dictionary<string, int>();
        public int NextMemory = 0;

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
                if (CachedMethods.ContainsKey(methodText))
                {
                    CachedMethods[methodText].Invoke(null, args);
                    instructionSetter = (int)args[1];
                    return;
                }
                
                var type = Assembly.GetExecutingAssembly().GetType("PawMapLoader.Res.PawScript.Claws." + instruction.Claw);
                var method = type?.GetMethod(instruction.Instruction);
                
                if (method == null) throw new MissingMethodException(instruction.Claw + "." + instruction.Instruction + " does not exist.");
                
                CachedMethods.Add(methodText, method);
                
                method.Invoke(null, args);
                instructionSetter = (int)args[1];
            }
            catch (Exception e)
            {
                MelonLogger.Error($"Instruction {instructionSetter}: {e.Message}");
                throw;
            }
        }
    }
}