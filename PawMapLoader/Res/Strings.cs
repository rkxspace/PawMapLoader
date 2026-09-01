namespace PawMapLoader.Res
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using MelonLoader;

    public class Strings
    {
        public static string Locale = CultureInfo.CurrentCulture.Name;

        public static IReadOnlyDictionary<string, IReadOnlyDictionary<string, string>> StringBank =
            new Dictionary<string, IReadOnlyDictionary<string, string>>
            {
                { "en-US", Languages.en_US }
            };

        public static void ValidateLocaleExist()
        {
            if (string.IsNullOrEmpty(Locale))
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
            catch (KeyNotFoundException e)
            {
                MelonLogger.Warning($"Failed to find string {key} in locale {Locale}. Falling back to en-US.");
                return StringBank["en-US"][key];
            }
            catch (Exception e)
            {
                MelonLogger.Error("String get fail. Defaulting to key.");
                return key;
            }
        }
    }
}