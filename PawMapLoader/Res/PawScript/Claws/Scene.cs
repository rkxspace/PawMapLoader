using PawMapLoader.Res.Components;
using PawMapLoader.Res.PawScript.Json;
using UnityEngine;

namespace PawMapLoader.Res.PawScript.Claws
{
    public class Scene
    {
        public static void ObjectToMemory(PawScriptInstruction instruction, ref int instructionSetter,
            Interpreter interpreter)
        {
            interpreter.WriteMemory(SceneRoot.Instance.transform.Find(instruction.Arguments[0]).gameObject,
                int.TryParse(instruction.Arguments[1], out int b) ? b : -1);
        }

        public static void ImportObject(PawScriptInstruction instruction, ref int instructionSetter,
            Interpreter interpreter)
        {
            Object uOb = Object.Instantiate(Store.ExtraAssetBundle.LoadAsset(instruction.Arguments[0]));
            uOb.Cast<GameObject>().transform.parent = SceneRoot.Instance.transform;
        }
    }
}