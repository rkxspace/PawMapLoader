using System;
using System.Collections.Generic;
using System.Text;
using MelonLoader;
using PawMapLoader.Res.PawScript.Json;
using PawMapLoader.Res.PawScript.Resolvers;

namespace PawMapLoader.Res.PawScript.Claws
{
    public class Script
    {
        public static void Dump(PawScriptInstruction instruction, ref int instructionSetter,
            Interpreter interpreter)
        {
            MelonLogger.Msg("Creating dump...");
            StringBuilder sb = new StringBuilder();
            sb.Append("\nInstructions");
            int instructionCounter = 0;
            foreach (PawScriptInstruction ins in interpreter.InstructionDumpReserve)
            {
                string args = string.Empty;
                foreach (string argument in ins.Arguments)
                {
                    args += argument + " ";
                }

                sb.Append($"\n| {instructionCounter}: {ins.Claw}.{ins.Instruction}( {args} )");
                instructionCounter++;
            }

            sb.Append("\nInterpreter Data ===================");
            sb.Append($"\nExecutions: {interpreter.Executions}");
            sb.Append($"\nNext Auto-Write MemPos: {interpreter.NextMemory}");
            sb.Append("\nMemory:");
            foreach (KeyValuePair<int, object> obj in interpreter.Memory)
            {
                sb.Append($"| {obj.Key}: {Convert.ChangeType(obj.Value, obj.Value.GetType())}");
            }

            sb.Append("\nPointers:");
            foreach (KeyValuePair<string, int> ptr in interpreter.NamedPtr)
            {
                sb.Append($"\n| {ptr.Key}: {ptr.Value}");
            }

            MelonLogger.Msg(sb.ToString());
        }

        public static void Log(PawScriptInstruction instruction, ref int instructionSetter, Interpreter interpreter)
        {
            MelonLogger.Msg($"[Pawscript] {instruction.Arguments[0] ?? string.Empty}");
        }

        public static void Jump(PawScriptInstruction instruction, ref int instructionSetter, Interpreter interpreter)
        {
            instructionSetter = int.Parse(instruction.Arguments[0]) - 1;
        }

        public static void ConditionalJump(PawScriptInstruction instruction, ref int instructionSetter,
            Interpreter interpreter)
        {
            string mode = instruction.Arguments[0] ?? string.Empty;
            string input1 = instruction.Arguments[1] ?? null;
            string input2 = instruction.Arguments[2] ?? null;
            int jumpTo = int.TryParse(instruction.Arguments[3], out _)
                ? int.Parse(instruction.Arguments[3])
                : throw new ArgumentNullException();

            object resolved1 = PointerResolver.ResolvePointer(input1, interpreter);
            object resolved2 = PointerResolver.ResolvePointer(input2, interpreter);

            bool result = false;
            switch (mode)
            {
                case "Equals":
                    result = Equals(resolved1, resolved2); break;
                case "NotEqual":
                    result = !Equals(resolved1, resolved2);
                    break;
                case "Greater":
                    result = Convert.ToDouble(resolved1) > Convert.ToDouble(resolved2);
                    break;
                case "Less": result = Convert.ToDouble(resolved1) < Convert.ToDouble(resolved2); break;
                case "EqualGreater": result = Convert.ToDouble(resolved1) >= Convert.ToDouble(resolved2); break;
                case "EqualLess": result = Convert.ToDouble(resolved1) <= Convert.ToDouble(resolved2); break;
                default: throw new InvalidOperationException($"Comparison type of \"{mode}\" not found.");
            }

            instructionSetter = result ? jumpTo - 1 : instructionSetter;
        }
    }
}