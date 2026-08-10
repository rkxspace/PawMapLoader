using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using MelonLoader;

namespace PawMapLoader.Res
{
    public class Strings
    {
        public static string Locale = CultureInfo.CurrentCulture.Name;

        public static void ValidateLocaleExist()
        {
            if (!String.IsNullOrEmpty(Locale))
            {
                MelonLogger.Warning($"Locale '{Locale}' does not exist!");
                Locale = "en-US";
            }
        }

        public static string GetString(string key)
        {
            try
            {
                return StringBank[Locale][key];
            }
            catch (Exception e)
            {
                MelonLogger.Warning($"Failed to find string {key} in locale {Locale}. Falling back to en-US.");
                return StringBank["en-US"][key];
            }
        }
        
        public static IReadOnlyDictionary<string, IReadOnlyDictionary<string, string>> StringBank =
            new Dictionary<string, IReadOnlyDictionary<string, string>>
            {
                {"en-US", new Dictionary<string, string>
                    {
                        { "InitFailTitle", "PawMapLoader init failure!" },
                        { "InitFailBody", "PawMapLoader has failed to initialize.\n" +
                                          "Please consider reporting this bug on Discord.\n" +
                                          "For more information, please consult the log."}
                        
                        
                    }
                }
            };
    }
}