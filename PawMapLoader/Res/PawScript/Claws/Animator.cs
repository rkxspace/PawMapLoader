namespace PawMapLoader.Res.PawScript.Claws
{
    public class Animator
    {
        public static void SetParameter(PawMapLoader.Res.PawScript.Json.PawScriptInstruction instruction,
            ref int instructionSetter,
            Interpreter interpreter)
        {
            object resolvedPointer =
                PawMapLoader.Res.PawScript.Resolvers.PointerResolver.ResolvePointer(instruction.Arguments[0],
                    interpreter);
            PawMapLoader.Res.PawScript.Validation.TypeValidation.Validate<UnityEngine.Animator>(resolvedPointer);

            UnityEngine.Animator animator = (UnityEngine.Animator)resolvedPointer;

            string paramName = instruction.Arguments[1];
            string paramValue = instruction.Arguments[2];

            if (bool.TryParse(paramValue, out bool boolVal))
                animator.SetBool(paramName, boolVal);
            else if (int.TryParse(paramValue, out int intVal))
                animator.SetInteger(paramName, intVal);
            else if (float.TryParse(paramValue, System.Globalization.NumberStyles.Float,
                         System.Globalization.CultureInfo.InvariantCulture, out float floatVal))
                animator.SetFloat(paramName, floatVal);
            else throw new System.ArgumentException($"{Strings.GetString("UnsupportedParamErr")}'{paramValue}'");
        }

        public static void SetTrigger(PawMapLoader.Res.PawScript.Json.PawScriptInstruction instruction,
            ref int instructionSetter,
            Interpreter interpreter)
        {
            UnityEngine.Animator animator =
                (UnityEngine.Animator)PawMapLoader.Res.PawScript.Resolvers.PointerResolver.ResolvePointer(
                    instruction.Arguments[0], interpreter);
            string triggerName = instruction.Arguments[1];
            animator.SetTrigger(triggerName);
        }
    }
}