using PawMapLoader.Res.PawScript.Json;
using PawMapLoader.Res.PawScript.Resolvers;
using PawMapLoader.Res.PawScript.Validation;
using UnityEngine;

namespace PawMapLoader.Res.PawScript.Claws
{
    //TODO: Add building instance stuff
    public class Map
    {
        public static void MoveObject(PawScriptInstruction instruction, ref int instructionSetter,
            Interpreter interpreter)
        {
            var resolvedPointer1 = PointerResolver.ResolvePointer(instruction.Arguments[0], interpreter);
            var resolvedPointer2 = PointerResolver.ResolvePointer(instruction.Arguments[1], interpreter);
            
            TypeValidation.Validate<GameObject>(resolvedPointer1);
            TypeValidation.Validate<Vector3>(resolvedPointer2);
            
            GameObject v1 = (GameObject)resolvedPointer1;
            Vector3 v2 = (Vector3)resolvedPointer2;

            v1.transform.position = v2;
        }

        public static void ScaleObject(PawScriptInstruction instruction, ref int instructionSetter,
            Interpreter interpreter)
        {
            var resolvedPointer1 = PointerResolver.ResolvePointer(instruction.Arguments[0], interpreter);
            var resolvedPointer2 = PointerResolver.ResolvePointer(instruction.Arguments[1], interpreter);
            
            TypeValidation.Validate<GameObject>(resolvedPointer1);
            TypeValidation.Validate<Vector3>(resolvedPointer2);
            
            GameObject v1 = (GameObject)resolvedPointer1;
            Vector3 v2 = (Vector3)resolvedPointer2;

            v1.transform.localScale = v2;
        }

        public static void RotateObject(PawScriptInstruction instruction, ref int instructionSetter,
            Interpreter interpreter)
        {
            var resolvedPointer1 = PointerResolver.ResolvePointer(instruction.Arguments[0], interpreter);
            var resolvedPointer2 = PointerResolver.ResolvePointer(instruction.Arguments[1], interpreter);
            
            TypeValidation.Validate<GameObject>(resolvedPointer1);
            TypeValidation.Validate<Vector4>(resolvedPointer2);
            
            GameObject v1 = (GameObject)resolvedPointer1;
            Vector4 v2 = (Vector4)resolvedPointer2;
            
            v1.transform.rotation = new Quaternion(v2.x, v2.y, v2.z, v2.w);
        }

        public static void DestroyObject(PawScriptInstruction instruction, ref int instructionSetter,
            Interpreter interpreter)
        {
            var resolvedPointer1 = PointerResolver.ResolvePointer(instruction.Arguments[0], interpreter);
            
            TypeValidation.Validate<GameObject>(resolvedPointer1);
            
            GameObject v1 = (GameObject)resolvedPointer1;
            
            Object.DestroyImmediate(v1);
        }
    }
}