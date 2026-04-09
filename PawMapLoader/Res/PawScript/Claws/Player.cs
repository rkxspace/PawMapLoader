using Il2CppCharacter;
using PawMapLoader.Res.PawScript.Json;
using PawMapLoader.Res.PawScript.Resolvers;

namespace PawMapLoader.Res.PawScript.Claws
{
    public class Player
    {
        private static PlayerManager _pm => PlayerManager.Instance;

        public static void GetMainPlayer(PawScriptInstruction instruction, ref int instructionSetter,
            Interpreter interpreter)
        {
            int memAddr = !string.IsNullOrEmpty(instruction.Arguments[0]) ? PointerResolver.ResolvePointerAddress(instruction.Arguments[0], interpreter) :-1;
            interpreter.WriteMemory(PlayerManager.MainPlayer, memAddr);
        }
    }
}