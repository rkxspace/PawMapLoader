using PawMapLoader.Res;
using PawMapLoader.Res.PawScript;
using UnityEngine;

namespace PawMapLoader
{
    public class UpdateRegisters
    {
        public static void Register()
        {
            Store.Udevnt += () => PawScriptRegister.lastFrameTime = Time.timeAsDouble;
            Res.GUI.PawScriptConsole.Register();
        }
    }
}