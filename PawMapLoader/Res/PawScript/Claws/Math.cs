using System;
using System.Globalization;
using PawMapLoader.Res.PawScript.Json;
using PawMapLoader.Res.PawScript.Resolvers;
using PawMapLoader.Res.PawScript.Validation;
using UnityEngine;

namespace PawMapLoader.Res.PawScript.Claws
{
    public class Math
    {
        public static void Float(PawScriptInstruction instruction, ref int instructionSetter, Interpreter interpreter)
        {
            interpreter.WriteMemory(float.Parse(instruction.Arguments[0],CultureInfo.InvariantCulture), PointerResolver.ResolvePointerAddress(instruction.Arguments[1]??"-1", interpreter));
        }

        public static void Int(PawScriptInstruction instruction, ref int instructionSetter, Interpreter interpreter)
        {
            interpreter.WriteMemory(int.Parse(instruction.Arguments[0],CultureInfo.InvariantCulture), PointerResolver.ResolvePointerAddress(instruction.Arguments[1]??"-1", interpreter));
        }
        
        public static void Vector2(PawScriptInstruction instruction, ref int instructionSetter, Interpreter interpreter)
        {
            var v1 = PointerResolver.ResolvePointer(instruction.Arguments[0], interpreter);
            var v2 = PointerResolver.ResolvePointer(instruction.Arguments[1], interpreter);
            
            TypeValidation.Validate<float>(v1);
            TypeValidation.Validate<float>(v2);
            
            interpreter.WriteMemory(new Vector2((float)v1, (float)v2),
                PointerResolver.ResolvePointerAddress(instruction.Arguments[2]??"-1", interpreter));
        }

        public static void Vector3(PawScriptInstruction instruction, ref int instructionSetter, Interpreter interpreter)
        {
            var v1 = PointerResolver.ResolvePointer(instruction.Arguments[0], interpreter);
            var v2 = PointerResolver.ResolvePointer(instruction.Arguments[1], interpreter);
            var v3 = PointerResolver.ResolvePointer(instruction.Arguments[2], interpreter);
            
            TypeValidation.Validate<float>(v1);
            TypeValidation.Validate<float>(v2);
            TypeValidation.Validate<float>(v3);
            
            interpreter.WriteMemory(new Vector3((float)v1, (float)v2, (float)v3),
                PointerResolver.ResolvePointerAddress(instruction.Arguments[3]??"-1", interpreter));
        }

        public static void Vector4(PawScriptInstruction instruction, ref int instructionSetter, Interpreter interpreter)
        {
            var v1 = PointerResolver.ResolvePointer(instruction.Arguments[0], interpreter);
            var v2 = PointerResolver.ResolvePointer(instruction.Arguments[1], interpreter);
            var v3 = PointerResolver.ResolvePointer(instruction.Arguments[2], interpreter);
            var v4 = PointerResolver.ResolvePointer(instruction.Arguments[3], interpreter);
            
            TypeValidation.Validate<float>(v1);
            TypeValidation.Validate<float>(v2);
            TypeValidation.Validate<float>(v3);
            TypeValidation.Validate<float>(v4);
            
            interpreter.WriteMemory(new Vector4((float)v1, (float)v2, (float)v3, (float)v4),
                PointerResolver.ResolvePointerAddress(instruction.Arguments[4]??"-1", interpreter));
        }

        public static void Evaluate(PawScriptInstruction instruction, ref int instructionSetter,
            Interpreter interpreter)
        {
            throw new NotImplementedException();
            //TODO: Implement math string parsing. Ideally with all available operations you'd find on a CASIO fx-300ES PLUS.
            //interpreter.WriteMemory();
        }
    }
}