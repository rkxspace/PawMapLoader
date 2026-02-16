using System.IO;
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
            if (Directory.Exists(customMapsDirectory))
            {
                MelonLogger.Msg("Maps Directory Found!");
            }
            else
            {
                MelonLogger.Msg("Maps Directory Not Found!");
                
                Directory.CreateDirectory(customMapsDirectory);
                
                MelonLogger.Msg("Maps Directory Created!");
            }
        }

        public static string ReturnMapsJson()
        {
            return File.Exists(customMapsJsonFile) ? File.ReadAllText(customMapsJsonFile) : "{\"PawMapFileVersion\": 1, \"PawMaps\": [ ]}";
        }

        public static Stream OpenMapFile(string assetString)
        {
            assetString = assetString.Replace(".", "\\");
            string assetPath = Path.Combine(customMapsDirectory, assetString + ".pawbox");
            if (File.Exists(assetPath))
            {
                return Il2CppSystem.IO.File.Open(assetPath, FileMode.Open);
            }
            MelonLogger.Error("Map File Not Found: " + assetPath);
            return null;
        }
    }
}