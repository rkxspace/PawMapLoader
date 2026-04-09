using System.Linq;
using PawMapLoader.Res.Components;
using PawMapLoader.Res.PawScript.Json;
using UnityEngine;

namespace PawMapLoader.Res.PawScript.Claws
{
    public class Scene
    {
        public static void UnityGameObjectToMemory(PawScriptInstruction instruction, ref int instructionSetter,
            Interpreter interpreter)
        {
            interpreter.WriteMemory(Resources.FindObjectsOfTypeAll<SceneRoot>().FirstOrDefault().transform.Find(instruction.Arguments[0]), int.TryParse(instruction.Arguments[1], out int b) ? b : 0 );
        }
    }
}