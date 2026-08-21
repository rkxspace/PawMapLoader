using System.Collections.Generic;
using PawMapLoader.Res.PawScript.Claws;

namespace PawMapLoader.Res.PawScript.Registers
{
    public class PlayerClaw
    {
        public static readonly IReadOnlyDictionary<string, InstructionDelegate> cPlayer =
            new Dictionary<string, InstructionDelegate>
            {
                { "GetMainPlayer", Player.GetMainPlayer },
                { "GetPlayer", Player.GetPlayer },
                { "GetPlayerAnimator", Player.GetPlayerAnimator },
                { "GetHeight", Player.GetHeight },
                { "AddScale", Player.AddScale }
            };
    }
}