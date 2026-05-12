using Il2CppCharacter;
using PawMapLoader.Res.PawScript.Json;
using PawMapLoader.Res.PawScript.Resolvers;

namespace PawMapLoader.Res.PawScript.Claws
{
    // Probably going to leave this mod as singleplayer only. Sorry!
    // I'm just not sure how I'll go about multiple players.
    public class Player
    {
        private static PlayerManager _pm => PlayerManager.Instance;

        public static void GetMainPlayer(PawScriptInstruction instruction, ref int instructionSetter,
            Interpreter interpreter)
        {
            int memAddr = !string.IsNullOrEmpty(instruction.Arguments[0]) ? PointerResolver.ResolvePointerAddress(instruction.Arguments[0], interpreter) :-1;
            interpreter.WriteMemory(PlayerManager.MainPlayer, memAddr);
        }

        public static void AddScale(PawScriptInstruction instruction, ref int instructionSetter,
            Interpreter interpreter)
        {
            var player = (Il2CppCharacter.Player)PointerResolver.ResolvePointer(instruction.Arguments[0], interpreter);
            player.Character.AddGrow(FloatResolver.ResolveFloat(instruction.Arguments[1]));
        }
    }
}