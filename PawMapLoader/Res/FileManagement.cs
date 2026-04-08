using System.IO;
using Il2CppConfig;
using MelonLoader;
using MelonLoader.Utils;
using FileMode = Il2CppSystem.IO.FileMode;
using Stream = Il2CppSystem.IO.Stream;

namespace PawMapLoader.Res
{
    public class FileManagement
    {
        public static string customMapsDirectory = Path.Combine(MelonEnvironment.UserDataDirectory, "Maps");
        public static string customMapsJsonFile = Path.Combine(customMapsDirectory, "maps.json");

        public static void EnsureCustomMapsDirectory()
        {
            if (Directory.Exists(customMapsDirectory)) return;
            Directory.CreateDirectory(customMapsDirectory);
            MelonLogger.Msg("Maps Directory Created!");
        }

        public static string ReturnMapsJson()
        {
            MelonLogger.Msg("Getting \"maps.json\"...");
            return File.Exists(customMapsJsonFile) ? File.ReadAllText(customMapsJsonFile) : "{\"PawMapFileVersion\": 1, \"PawMaps\": [ ]}";
        }

        public static Stream OpenMapFile(string assetString)
        {
            string assetPath = Path.Combine(customMapsDirectory, assetString.Replace(".", "\\") + ".pawbox");
            if (File.Exists(assetPath)) return Il2CppSystem.IO.File.Open(assetPath, FileMode.Open);
            throw new FileNotFoundException("Map File Not Found: " + assetPath);
        }

        public static string GetScriptFile(string scriptName)
        {
            var scriptPath = (ConfigManager.Instance.Level.Scene.SceneName + ".Scripts." + scriptName).Replace(".", "\\") + ".json";
            return File.Exists(scriptPath) ? File.ReadAllText(scriptPath) : null;
        }
    }
}