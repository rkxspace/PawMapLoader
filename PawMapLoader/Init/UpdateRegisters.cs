namespace PawMapLoader
{
    using UnityEngine;
    using Res;

    public class UpdateRegisters
    {
        public static void Register()
        {
            Store.Udevnt += () => Res.PawScript.EnvyRunner.RuntimeStores.lastFrameTime = Time.timeAsDouble;
        }
    }
}

