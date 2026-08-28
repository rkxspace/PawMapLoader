namespace PawMapLoader.Res
{
    using System.Collections.Generic;

    internal class Languages
    {
        public static IReadOnlyDictionary<string, string> en_US = new Dictionary<string, string>
        {
            { "InitFailTitle", "PawMapLoader init failure!" },
            {
                "InitFailBody", "PawMapLoader has failed to initialize.\n" +
                                "Please consider reporting this bug on Discord.\n" +
                                "For more information, please consult the log."
            },

            { "DamageableError_Split1", "PawScriptDamageable component on " },
            { "DamageableError_Split2", " encountered an error." },

            { "GameDumpHeader", "GAME DUMP" },

            { "LoadingHeader", "Loading..." },
            { "LoadingMessage", "Loading Custom Level..." },
            { "LoadingMessageAdditional", "Loading Additional Assets..." },
            { "LoadingOkayButton", "Okay..." },
            { "MapLoadFailText", "Failed to load!" },
            { "MapLoadFail", "Map AssetBundle failed to load." },
            { "AdditionalLoadFail", "Extra AssetBundle failed to load." },
            { "LoadingFinish", "Done!" },
            { "BundleFailError", "Failed to load bundle: " },

            { "UnsupportedParamErr", "Unsupported parameter: " },
            { "InvalidTypeErr", "Invalid type passed." },
            { "ComponentUnsetErr", "Unset Component on GameObject " },
            { "LevelDataAddFail", "Could not add data: " },
            {
                "NTDllGetErr", "Could not get ntdll.\n" +
                               "You might want to check your PC."
            },

            { "FPOpen", "Open" },
            { "FPSave", "Save" },
            { "EditorButton", "Map Editor" }
        };
    }
}