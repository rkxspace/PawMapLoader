using System.Collections.Generic;
using PawMapLoader.Res.PawScript.Claws;

namespace PawMapLoader.Res.PawScript.Registers
{
    public class GameStateClaw
    {
        public static readonly IReadOnlyDictionary<string, InstructionDelegate> cGameState =
            new Dictionary<string, InstructionDelegate>
            {
                { "EndGame", GameState.EndGame },
                { "RestartGame", GameState.RestartGame },
                { "SetTimeScale", GameState.SetTimeScale },
                { "ToLobby", GameState.ToLobby }
            };
    }
}