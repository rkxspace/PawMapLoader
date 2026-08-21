using System.Collections.Generic;
using PawMapLoader.Res.PawScript.Claws;

namespace PawMapLoader.Res.PawScript.Registers
{
    public class AnimatorClaw
    {
        public static readonly IReadOnlyDictionary<string, InstructionDelegate> cAnimator =
            new Dictionary<string, InstructionDelegate>
            {
                { "SetParameter", Animator.SetParameter },
                { "SetTrigger", Animator.SetTrigger }
            };
    }
}