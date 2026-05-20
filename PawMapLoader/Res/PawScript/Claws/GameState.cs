using Il2CppGame;
using PawMapLoader.Res.PawScript.Json;
using PawMapLoader.Res.PawScript.Resolvers;
using PawMapLoader.Res.PawScript.Validation;

namespace PawMapLoader.Res.PawScript.Claws
{
    public class GameState
    {
        public static void EndGame(PawScriptInstruction instruction, ref int instructionSetter, Interpreter interpreter)
        {
            GameManager.Instance.FinishGame();
        }

        public static void RestartGame(PawScriptInstruction instruction, ref int instructionSetter,
            Interpreter interpreter)
        {
            GameManager.Instance.RestartGame();
        }

        public static void SetTimeScale(PawScriptInstruction instruction, ref int instructionSetter,
            Interpreter interpreter)
        {
            object resolvedPointer = PointerResolver.ResolvePointer(instruction.Arguments[0], interpreter);
            TypeValidation.Validate<float>(resolvedPointer);
            float ts = (float)resolvedPointer;
            GameManager.Instance.SetTimeScale(ts);
        }

        public static void ToLobby(PawScriptInstruction instruction, ref int instructionSetter, Interpreter interpreter)
        {
            GameManager.Instance.GoToLobby();
        }
    }
}