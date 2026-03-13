using PawMapLoader.Res.PawScript.Json;
using PawMapLoader.Res.PawScript.Resolvers;
using UnityEngine;

namespace PawMapLoader.Res.PawScript.Claws
{
    //TODO: Add building instance stuff
    public class Map
    {
        public static void MoveObject(PawScriptInstruction instruction, ref int instructionSetter,
            Interpreter interpreter)
        {
            GameObject v1 = (GameObject)PointerResolver.ResolvePointer(instruction.Arguments[0], interpreter);
            Vector3 v2 = (Vector3)PointerResolver.ResolvePointer(instruction.Arguments[1], interpreter);

            v1.transform.position = v2;
        }

        public static void ScaleObject(PawScriptInstruction instruction, ref int instructionSetter,
            Interpreter interpreter)
        {
            GameObject v1 = (GameObject)PointerResolver.ResolvePointer(instruction.Arguments[0], interpreter);
            Vector3 v2 = (Vector3)PointerResolver.ResolvePointer(instruction.Arguments[1], interpreter);

            v1.transform.localScale = v2;
        }

        public static void RotateObject(PawScriptInstruction instruction, ref int instructionSetter,
            Interpreter interpreter)
        {
            GameObject v1 = (GameObject)PointerResolver.ResolvePointer(instruction.Arguments[0], interpreter);
            Vector4 v2 = (Vector4)PointerResolver.ResolvePointer(instruction.Arguments[1], interpreter);
            
            v1.transform.rotation = new Quaternion(v2.x, v2.y, v2.z, v2.w);
        }
    }
}