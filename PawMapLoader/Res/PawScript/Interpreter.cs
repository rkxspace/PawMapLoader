namespace PawMapLoader.Res.PawScript
{
    using System;
    using System.Collections.Generic;
    using EnvyRunner;
    using Json;
    using MelonLoader;
    using UserConf;

    public class Interpreter
    {
        public List<PawScriptInstruction> InstructionDumpReserve;
        public RuntimeMemory RtMemory;
        public bool scriptDebug => UConf.Properties.PawScriptDebug;

        // leaving for debugging
        public void Reset()
        {
            RtMemory.Memory.Clear();
            RtMemory.NamedPtr.Clear();
            RtMemory.NextMemory = 0;
            RtMemory.Executions = 0;
        }

        public void WriteMemory(object obj, int address = -1)
        {
            if (scriptDebug) MelonLogger.Msg($"WriteMemory {address}");
            if (obj == null) throw new NullReferenceException();
            if (address >= 0)
            {
                RtMemory.Memory[address] = obj;
                return;
            }

            while (RtMemory.Memory.ContainsKey(RtMemory.NextMemory))
            {
                RtMemory.NextMemory++;
            }

            RtMemory.Memory.Add(RtMemory.NextMemory, obj);
        }

        public void Interpret(PawScriptInstruction instruction, ref int instructionSetter)
        {
            RtMemory.Executions++;
            try
            {
                if (scriptDebug)
                {
                    MelonLogger.Msg(
                        $"Instruction {instructionSetter}: {instruction.Claw} => {instruction.Instruction} - Args: [{string.Join(", ", instruction.Arguments)}]");
                }

                if (ClawRegister.rClaws.TryGetValue(instruction.Claw,
                        out IReadOnlyDictionary<string, InstructionDelegate> Claw))
                {
                    if (Claw.TryGetValue(instruction.Instruction, out InstructionDelegate fnc))
                        fnc(instruction, ref instructionSetter, this);
                    else
                    {
                        throw new MissingMethodException(
                            $"FUNC {instruction.Claw} => {instruction.Instruction} does not exist.");
                    }
                }
                else throw new MissingMethodException($"Claw {instruction.Claw} does not exist.");
            }
            catch (Exception e)
            {
                MelonLogger.Error($"Instruction {instructionSetter}: {e.Message}");
                throw;
            }
        }
    }
}