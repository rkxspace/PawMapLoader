using PawMapLoader.Res.Components;
using PawMapLoader.Res.PawScript.Json;

namespace PawMapLoader.Res.PawScript.Claws
{
    public class Scene
    {
        public static void UnityGameObjectToMemory(PawScriptInstruction instruction, ref int instructionSetter,
            Interpreter interpreter)
        {
            interpreter.WriteMemory(SceneRoot.Instance.transform.Find(instruction.Arguments[0]).gameObject, int.TryParse(instruction.Arguments[1], out int b) ? b : -1 );
        }
    }
}