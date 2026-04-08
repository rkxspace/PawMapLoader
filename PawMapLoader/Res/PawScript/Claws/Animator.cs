using System;
using System.Globalization;
using PawMapLoader.Res.PawScript.Json;
using PawMapLoader.Res.PawScript.Resolvers;

namespace PawMapLoader.Res.PawScript.Claws
{
    /// <summary>
    /// Access specific features of the Unity Animation Controller.
    /// </summary>
    public class Animator
    {
        public static void SetParameter(PawScriptInstruction instruction, ref int instructionSetter, Interpreter interpreter)
        {
            UnityEngine.Animator animator = (UnityEngine.Animator)PointerResolver.ResolvePointer(instruction.Arguments[0], interpreter);

            string paramName = instruction.Arguments[1];
            string paramValue = instruction.Arguments[2];

            if (bool.TryParse(paramValue, out bool boolVal))
                animator.SetBool(paramName, boolVal);
            else if (int.TryParse(paramValue, out int intVal))
                animator.SetInteger(paramName, intVal);
            else if (float.TryParse(paramValue, NumberStyles.Float, CultureInfo.InvariantCulture, out float floatVal))
                animator.SetFloat(paramName, floatVal);
            else throw new ArgumentException($"Unsupported parameter: '{paramValue}'");
        }

        public static void SetTrigger(PawScriptInstruction instruction, ref int instructionSetter, Interpreter interpreter)
        {
            
            UnityEngine.Animator animator = (UnityEngine.Animator)PointerResolver.ResolvePointer(instruction.Arguments[0], interpreter);
            string triggerName = instruction.Arguments[1];
            animator.SetTrigger(triggerName);
        }
    }
}