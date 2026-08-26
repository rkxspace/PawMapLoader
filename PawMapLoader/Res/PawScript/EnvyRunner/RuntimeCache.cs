namespace PawMapLoader.Res.PawScript.EnvyRunner
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Json;
    using MelonLoader;
    using Newtonsoft.Json;

    public class RuntimeCache
    {
        private static long StaleTime => DateTime.Now.AddHours(1).Ticks;
        private static Dictionary<string, Tuple<long, long, PawScriptInstructions>> _scriptCache = 
            new Dictionary<string, Tuple<long, long, PawScriptInstructions>>();

        public static PawScriptInstructions GetScript(string scriptName)
        {
            try
            {
                PreloadScript(scriptName);
                return _scriptCache.TryGetValue(scriptName, out Tuple<long, long, PawScriptInstructions> val) ? 
                    val.Item3
                    : throw new FileNotFoundException($"Script loading for \"{scriptName}\" failed.");
            }
            catch (Exception e)
            {
                MelonLogger.Error($"Failed to load script \"{scriptName}\".", e);
                throw;
            }
        }

        public static void PreloadScript(string scriptName)
        {
            if (
                !(_scriptCache.TryGetValue(scriptName, out Tuple<long, long, PawScriptInstructions> val) && (val.Item2 <
                    DateTime.Now.Ticks)))
            {
                _scriptCache.Add( scriptName,
                    new Tuple<long, long, PawScriptInstructions>(DateTime.Now.Ticks, StaleTime,
                        JsonConvert.DeserializeObject<PawScriptInstructions>(FileManagement.GetScriptFile(scriptName))
                        )
                    );
            }
        }
        public static void RemoveCacheEntry(string scriptName)
        {
            _scriptCache.Remove(scriptName);
        }
        public static void ClearCache()
        {
            _scriptCache.Clear();
        }
    }
}