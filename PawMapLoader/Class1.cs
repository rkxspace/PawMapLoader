using MelonLoader;
using PawMapLoader;
using PawMapLoader.Res.PawScript;
using UnityEngine;

[assembly: MelonInfo(typeof(MalonInit), "PawMapLoader", "0.0.3", "Rocky Nexit")]
[assembly: MelonGame("Dare Looks", "Pawperty Damage")]

namespace PawMapLoader
{
    public class MalonInit : MelonMod
    {
        public override void OnInitializeMelon() => Init.InitMelon();

        public override void OnUpdate()
        {
            PawScriptRegister.lastFrameTime = Time.timeAsDouble;
        }
    }
}