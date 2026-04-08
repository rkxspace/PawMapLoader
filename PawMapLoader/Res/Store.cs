using Il2CppSystem.IO;
using PawMapLoader.Res.Json;
using UnityEngine;

namespace PawMapLoader.Res
{
    public class Store
    {
        public static MapList Maps;
        public static bool MapLoadLocked = false;
        public static bool IsMapCustom = false;
        public static AssetBundle LoadedAssetBundle;
        public static AssetBundle ExtraAssetBundle;
        public static Stream BundleStream;

        public class PawScript
        {
            public static bool inversions = false;

            // I don't want scripts using restricted classes by default, as they give more control over the game and system.
            // I also don't really want people using them. They are there just in case, but are highly discouraged from use.
            public static bool PawScriptRestrictedClassesEnabled = false;

            public static readonly bool I_Understand_That_Enabling_This_Allows_Maps_To_Do_Bad = false;

            // Not legally binding. Doesn't matter anyway, your fault for running the code.
            public static readonly bool I_Waive_My_Right_To_Put_Liability_On_Mod_Developers_For_Dangerous_Map_Code_Execution = false;
            public static readonly bool I_Realize_I_Am_An_Imbecile_For_Enabling_This_At_All = false;
            public static readonly bool I_Give_Permission_For_Maps_To_Read_And_Make_Changes_To_My_Device = false;
            public static readonly bool I_Give_Permission_For_Maps_To_Cause_Potentially_Catastrophic_Damage = false;
            public static readonly bool I_Give_Permission_For_Maps_To_Send_And_Receive_Data_To_And_From_External_Networks = false;
            public static readonly string Sig = "";
        }

        // The harmony patches fire twice and I have no idea why.
        // Wait nevermind I might have found the fix. I'll get back if it does or doesn't stop it.
        public class FirePrevention
        {
            public static bool IsGameStarted = false;
            public static bool HasBlockConfig = false;
        }
    }
}