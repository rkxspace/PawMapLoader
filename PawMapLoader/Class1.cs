using System.Runtime.CompilerServices;
using MelonLoader;
using PawMapLoader;

[assembly: MelonInfo(typeof(MalonInit), "PawMapLoader", "0.0.3", "Rocky Nexit")]
[assembly: MelonGame("Dare Looks", "Pawperty Damage")]
[assembly: IgnoresAccessChecksTo("Assembly-CSharp")]
[assembly: IgnoresAccessChecksTo("UnityEngine.CoreModule")]
[assembly: MelonPriority(-20)]

namespace PawMapLoader
{
    using MelonLoader;
    using Res;

    public class MalonInit : MelonMod
    {
        public override void OnPreSupportModule() => PreSupport.PSup();
        public override void OnEarlyInitializeMelon() => EarlyInitMelon.EarlyInit();

        public override void OnInitializeMelon() => Init.InitMelon();

        public override void OnUpdate() => Store.Udevnt();

        public override void OnGUI() => Store.UdevntGUI();

        public override void OnSceneWasInitialized(int buildIndex, string sceneName) =>
            Store.InitScnevnt(buildIndex, sceneName);
    }
}