using System;
using System.Collections.Generic;
using System.Reflection;
using MelonLoader;
using PawMapLoader.Res.PawScript.Json;

namespace PawMapLoader.Res.PawScript
{
    public class Interpreter
    {
        public int Executions = 0;
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

        public void Interpret(PawScriptInstruction instruction, ref int instructionSetter)
        {
            Executions++;
            try
            {
                // ReSharper disable once PossibleNullReferenceException
                Assembly.GetExecutingAssembly().GetType("PawMapLoader.Res.PawScript.Claws." + instruction.Claw)
                    .GetMethod(instruction.Instruction).Invoke(null, new object[] { instruction, ref instructionSetter, this});
            }
            catch (Exception e)
            {
                MelonLogger.Error($"Instruction {instructionSetter}: {e.Message}");
                throw;
            }
        }
    }
}