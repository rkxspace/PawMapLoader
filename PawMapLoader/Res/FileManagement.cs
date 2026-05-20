using System;
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
            try
            {
                if (Directory.Exists(customMapsDirectory)) return;
                Directory.CreateDirectory(customMapsDirectory);
                MelonLogger.Msg("Maps Directory Created!");
            }
            catch (Exception e)
            {
                MelonLogger.Error("Failure to check or create maps directory, possibly due to permissions.", e);
                ErrorReporter.Report(e);
            }
        }

        public static string ReturnMapsJson()
        {
            try
            {
                MelonLogger.Msg("Getting \"maps.json\"...");
                return File.Exists(customMapsJsonFile)
                    ? File.ReadAllText(customMapsJsonFile)
                    : "{\"PawMapFileVersion\": 1, \"PawMaps\": [ ]}";
            }
            catch (Exception e)
            {
                MelonLogger.Error("Error reading maps.json file. Returning a blank maps list.", e);
                ErrorReporter.Report(e);
                return "{\"PawMapFileVersion\": 1, \"PawMaps\": [ ]}";
            }
        }

        public static Stream OpenMapFile(string assetString)
        {
            try
            {
                string assetPath = Path.Combine(customMapsDirectory, $"{assetString.Replace(".", "\\")}.pawbox");
                return File.Exists(assetPath)
                    ? Il2CppSystem.IO.File.Open(assetPath, FileMode.Open)
                    : throw new FileNotFoundException($"{assetPath} doesn't exist");
            }
            catch (FileNotFoundException e)
            {
                MelonLogger.Error($"Map File Not Found: {assetString}", e);
                throw;
            }
            catch (Exception e)
            {
                MelonLogger.Error("Error opening map file.", e);
                ErrorReporter.Report(e);
                throw;
            }
        }

        public static string GetScriptFile(string scriptName)
        {
            try
            {
                var scriptPath =
                    $"{$"{ConfigManager.Instance.Level.Scene.SceneName}_Scripts.{scriptName}".Replace(".", "\\")}.json";
                return File.Exists(scriptPath)
                    ? File.ReadAllText(scriptPath)
                    : throw new FileNotFoundException($"{scriptPath} doesn't exist");
            }
            catch (FileNotFoundException e)
            {
                MelonLogger.Error($"Script File Not Found: {scriptName}", e);
                throw;
            }
            catch (Exception e)
            {
                MelonLogger.Error($"Error opening script file: {scriptName}", e);
                ErrorReporter.Report(e);
                throw;
            }
        }
    }
}