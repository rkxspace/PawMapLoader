using MelonLoader;
using PawMapLoader;
using PawMapLoader.Res;

[assembly: MelonInfo(typeof(MalonInit), "PawMapLoader", "0.0.3", "Rocky Nexit")]
[assembly: MelonGame("Dare Looks", "Pawperty Damage")]
[assembly: MelonPriority(-20)]

namespace PawMapLoader
{
    public class MalonInit : MelonMod
    {
        public override void OnEarlyInitializeMelon() => EarlyInitMelon.EarlyInit();

        public override void OnInitializeMelon() => Init.InitMelon();

        public override void OnUpdate() => Store.Udevnt();

        public override void OnGUI() => Store.UdevntGUI();
    }
}