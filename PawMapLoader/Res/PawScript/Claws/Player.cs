using System;
using System.Globalization;
using Il2CppCharacter;
using PawMapLoader.Res.PawScript.Json;
using PawMapLoader.Res.PawScript.Resolvers;
using PawMapLoader.Res.PawScript.Validation;

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

        public static void GetPlayer(PawScriptInstruction instruction, ref int instructionSetter,
            Interpreter interpreter)
        {
            int memAddr = !string.IsNullOrEmpty(instruction.Arguments[1]) ? PointerResolver.ResolvePointerAddress(instruction.Arguments[1], interpreter) :-1;
            interpreter.WriteMemory(_pm.Players[int.TryParse(instruction.Arguments[0], out var outval) ? outval : throw new ArgumentException("Arg0 is not int.")], memAddr);
        }

        public static void AddScale(PawScriptInstruction instruction, ref int instructionSetter,
            Interpreter interpreter)
        {
            var resolvedPointer1 = PointerResolver.ResolvePointer(instruction.Arguments[0], interpreter);
            TypeValidation.Validate<Il2CppCharacter.Player>(resolvedPointer1);
            
            var player = (Il2CppCharacter.Player)resolvedPointer1;
            player.Character.AddGrow(float.TryParse(instruction.Arguments[1], out var outval) ? outval : throw new ArgumentException("Arg1 is not float."));
        }
    }
}