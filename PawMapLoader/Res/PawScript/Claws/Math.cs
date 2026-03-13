using PawMapLoader.Res.PawScript.Json;
using PawMapLoader.Res.PawScript.Resolvers;
using UnityEngine;

namespace PawMapLoader.Res.PawScript.Claws
{
    public class Math
    {
        public static void Vector2(PawScriptInstruction instruction, ref int instructionSetter, Interpreter interpreter)
        {
            var v1 = instruction.Arguments[0];
            var v2 = instruction.Arguments[1];
            
            interpreter.WriteMemory(new Vector2(FloatResolver.ResolveFloat(v1),
                    FloatResolver.ResolveFloat(v2)),
                PointerResolver.ResolvePointerAddress(instruction.Arguments[2]??"-1", interpreter));
        }

        public static void Vector3(PawScriptInstruction instruction, ref int instructionSetter, Interpreter interpreter)
        {
            var v1 = instruction.Arguments[0];
            var v2 = instruction.Arguments[1];
            var v3 = instruction.Arguments[2];
            
            interpreter.WriteMemory(new Vector3(FloatResolver.ResolveFloat(v1),
                FloatResolver.ResolveFloat(v2), 
                FloatResolver.ResolveFloat(v3)),
                PointerResolver.ResolvePointerAddress(instruction.Arguments[3]??"-1", interpreter));
        }

        public static void Vector4(PawScriptInstruction instruction, ref int instructionSetter, Interpreter interpreter)
        {
            var v1 = instruction.Arguments[0];
            var v2 = instruction.Arguments[1];
            var v3 = instruction.Arguments[2];
            var v4 = instruction.Arguments[3];
            
            interpreter.WriteMemory(new Vector4(FloatResolver.ResolveFloat(v1),
                    FloatResolver.ResolveFloat(v2), 
                    FloatResolver.ResolveFloat(v3),
                    FloatResolver.ResolveFloat(v4)),
                PointerResolver.ResolvePointerAddress(instruction.Arguments[4]??"-1", interpreter));
        }

        public static void Float(PawScriptInstruction instruction, ref int instructionSetter, Interpreter interpreter)
        {
            interpreter.WriteMemory(float.Parse(instruction.Arguments[0]), PointerResolver.ResolvePointerAddress(instruction.Arguments[1]??"-1", interpreter));
        }

        public static void Int(PawScriptInstruction instruction, ref int instructionSetter, Interpreter interpreter)
        {
            interpreter.WriteMemory(int.Parse(instruction.Arguments[0]), PointerResolver.ResolvePointerAddress(instruction.Arguments[1]??"-1", interpreter));
        }

        public static void Evaluate(PawScriptInstruction instruction, ref int instructionSetter,
            Interpreter interpreter)
        {
            //TODO: Implement math string parsing. Ideally with all available operations.
            //interpreter.WriteMemory();
        }
    }
}