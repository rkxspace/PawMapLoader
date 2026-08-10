using System;
using System.IO;
using Il2CppConfig;
using MelonLoader;
using Newtonsoft.Json;
using PawMapLoader.Res.UserConf;
using PawMapLoader.Res.UserConf.Json;
using FileMode = Il2CppSystem.IO.FileMode;
using Stream = Il2CppSystem.IO.Stream;

namespace PawMapLoader.Res
{
    public class FileManagement
    {
        public static string customMapsDirectory = Path.Combine(UConf.Properties.UserDataDirectory, "Maps");

        public static string configDirectory =
            Path.Combine(UConf.Properties.UserDataDirectory, ".rkxspace\\PawMapLoader");

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

        public static void EnsureConfigDirectory()
        {
            try
            {
                if (Directory.Exists(configDirectory)) return;
                Directory.CreateDirectory(configDirectory);
                File.WriteAllText($"{configDirectory}\\config.json",
                    JsonConvert.SerializeObject(new UserConfigProperties(), Formatting.Indented)
                );
                MelonLogger.Msg("Config Directory Created!");
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
                MelonLogger.Error($"File Not Found: {assetString.Replace(".", "\\")}.pawbox", e);
                if (!assetString.EndsWith("_ADDITIVE")) throw;
                return null;
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
                string scriptPath =
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

        private static string CreateAndReturnConfigFile()
        {
            string jsc = JsonConvert.SerializeObject(new UserConfigProperties(), Formatting.Indented);
            File.WriteAllText($"{configDirectory}\\config.json",
                jsc
            );
            return jsc;
        }

        public static void WriteConfigFile(UserConfigProperties config)
        {
            string jsc = JsonConvert.SerializeObject(config, Formatting.Indented);
            File.WriteAllText($"{configDirectory}\\config.json",
                jsc
            );
        }

        public static string GetConfigFile()
        {
            try
            {
                MelonLogger.Msg("Getting \"config.json\"...");
                return File.Exists($"{configDirectory}\\config.json")
                    ? File.ReadAllText($"{configDirectory}\\config.json")
                    : CreateAndReturnConfigFile();
            }
            catch (Exception e)
            {
                MelonLogger.Error("Error reading config.json file. Defaulting..", e);
                ErrorReporter.Report(e);
                return "{}";
            }
        }
    }
}