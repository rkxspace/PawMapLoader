using System;
using PawMapLoader.Res.PawScript.Json;
using PawMapLoader.Res.PawScript.Resolvers;

namespace PawMapLoader.Res.PawScript.Claws
{
    public class Script
    {
        public static void Jump(PawScriptInstruction instruction, ref int instructionSetter, Interpreter interpreter)
        {
            instructionSetter = int.Parse(instruction.Arguments[0]);
        }

        public static void ConditionalJump(PawScriptInstruction instruction, ref int instructionSetter,
            Interpreter interpreter)
        {
            var mode = instruction.Arguments[0] ?? "";
            var input1 = instruction.Arguments[1] ?? null;
            var input2 = instruction.Arguments[2] ?? null;
            var jumpTo = int.TryParse(instruction.Arguments[3], out _)
                ? int.Parse(instruction.Arguments[3])
                : throw new ArgumentNullException();

            var resolved1 = PointerResolver.ResolvePointer(input1, interpreter);
            var resolved2 = PointerResolver.ResolvePointer(input2, interpreter);
            
            bool result = false;
            switch (mode) {
                case "Equals":
                    result = Equals(resolved1, resolved2); break;
                case "NotEqual": result = !Equals(resolved1, resolved2);
                    break;
                case "Greater": result = Convert.ToDouble(resolved1) > Convert.ToDouble(resolved2);
                    break;
                case "Less": result = Convert.ToDouble(resolved1) < Convert.ToDouble(resolved2); break;
                case "EqualGreater": result = Convert.ToDouble(resolved1) >= Convert.ToDouble(resolved2); break;
                case "EqualLess": result = Convert.ToDouble(resolved1) <= Convert.ToDouble(resolved2); break;
            }
            
            instructionSetter = result?jumpTo:instructionSetter;
        }
    }
}