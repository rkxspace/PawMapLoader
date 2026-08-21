using System;
using Il2CppCharacter;
using PawMapLoader.Res.PawScript.Json;
using PawMapLoader.Res.PawScript.Resolvers;
using PawMapLoader.Res.PawScript.Validation;

//TODO: Match code format
namespace PawMapLoader.Res.PawScript.Claws
{
    public class Player
    {
        private static PlayerManager _pm => PlayerManager.Instance;

        public static void GetMainPlayer(PawScriptInstruction instruction, ref int instructionSetter,
            Interpreter interpreter)
        {
            int memAddr = !string.IsNullOrEmpty(instruction.Arguments[0])
                ? PointerResolver.ResolvePointerAddress(instruction.Arguments[0], interpreter)
                : -1;
            interpreter.WriteMemory(PlayerManager.MainPlayer, memAddr);
        }

        public static void GetPlayer(PawScriptInstruction instruction, ref int instructionSetter,
            Interpreter interpreter)
        {
            int memAddr = !string.IsNullOrEmpty(instruction.Arguments[1])
                ? PointerResolver.ResolvePointerAddress(instruction.Arguments[1], interpreter)
                : -1;
            interpreter.WriteMemory(
                _pm.Players[
                    int.TryParse(instruction.Arguments[0], out int outval)
                        ? outval
                        : throw new ArgumentException("Arg0 is not int.")], memAddr);
        }

        public static void GetHeight(PawScriptInstruction instruction, ref int instructionSetter,
            Interpreter interpreter)
        {
            object resolvedPointer1 = PointerResolver.ResolvePointer(instruction.Arguments[0], interpreter);
            TypeValidation.Validate<Il2CppCharacter.Player>(resolvedPointer1);
            Il2CppCharacter.Player player = (Il2CppCharacter.Player)resolvedPointer1;

            int memAddr = !string.IsNullOrEmpty(instruction.Arguments[1])
                ? PointerResolver.ResolvePointerAddress(instruction.Arguments[1], interpreter)
                : -1;
            interpreter.WriteMemory(player.GetHeight(), memAddr);
        }

        public static void AddScale(PawScriptInstruction instruction, ref int instructionSetter,
            Interpreter interpreter)
        {
            object resolvedPointer1 = PointerResolver.ResolvePointer(instruction.Arguments[0], interpreter);
            TypeValidation.Validate<Il2CppCharacter.Player>(resolvedPointer1);

            Il2CppCharacter.Player player = (Il2CppCharacter.Player)resolvedPointer1;
            player.Character.AddGrow(float.TryParse(instruction.Arguments[1], out float outval)
                ? outval
                : throw new ArgumentException("Arg1 is not float."));
        }
    }
}