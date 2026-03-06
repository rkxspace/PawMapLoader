using PawMapLoader.Res.PawScript.Json;

namespace PawMapLoader.Res.PawScript.Claws
{
    /// <summary>
    /// Access specific features of the Unity Animation Controller.
    /// </summary>
    public class Animator
    {
        public static void SetParameter(PawScriptInstruction instruction, ref int instructionSetter, Interpreter interpreter)
        {
            UnityEngine.Animator animator = (UnityEngine.Animator)interpreter.Memory[interpreter.NamedPtr[instruction.Arguments[0]]];
            string paramName = instruction.Arguments[1];
            string paramValue = instruction.Arguments[2];

            if (bool.TryParse(paramValue, out bool boolVal))
                animator.SetBool(paramName, boolVal);
            else if (int.TryParse(paramValue, out int intVal))
                animator.SetInteger(paramName, intVal);
            else if (float.TryParse(paramValue, out float floatVal))
                animator.SetFloat(paramName, floatVal);
        }
    }
}