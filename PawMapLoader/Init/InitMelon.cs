using System;
using PawMapLoader.Res;
using PawMapLoader.Res.Enum;
using PawMapLoader.Res.Json;
using PawMapLoader.Res.PawScript.Validation;

namespace PawMapLoader
{
    public class Init
    {
        private static bool _ready = false;

        public static void InitMelon()
        {
            RestrictedValidation.GetRestrictedClassesEnabled();
            Store.PawScript.inversions = !Store.PawScript.PawScriptRestrictedClassesEnabled;
            var rnd = new Random();
            // ReSharper disable once ObjectCreationAsStatement
            new RestrictedWatcher(rnd.NextDouble()*Math.Cos(rnd.NextDouble()));
            _ready = true;
            PatchReg.Patch();
            LevelDataProvider.WaitForDataProvider();
        }

        public static void InitMaps()
        {
            if (!_ready) return;
            FileManagement.EnsureCustomMapsDirectory();
            MapJson.Read();
            AssetManager.LoadMapData();
        }
    }
}