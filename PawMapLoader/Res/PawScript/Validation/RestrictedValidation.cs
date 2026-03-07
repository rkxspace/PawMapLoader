using System.IO;
using MelonLoader;
using PawMapLoader.Res.PawScript.Json;

namespace PawMapLoader.Res.PawScript.Validation
{
    public class RestrictedValidation
    {
        public static void GetRestrictedClassesEnabled()
        {
            if (Store.PawScript.I_Give_Permission_For_Maps_To_Cause_Potentially_Catastrophic_Damage &&
                Store.PawScript.I_Give_Permission_For_Maps_To_Read_And_Make_Changes_To_My_Device &&
                Store.PawScript.I_Give_Permission_For_Maps_To_Send_And_Receive_Data_To_And_From_External_Networks &&
                Store.PawScript.I_Realize_I_Am_An_Imbecile_For_Enabling_This_At_All &&
                Store.PawScript.I_Understand_That_Enabling_This_Allows_Maps_To_Do_Bad && Store.PawScript
                    .I_Waive_My_Right_To_Put_Liability_On_Mod_Developers_For_Dangerous_Map_Code_Execution)
            {
                Store.PawScript.PawScriptRestrictedClassesEnabled = true;
                MelonLogger.Msg("Restricted classes enabled! If you did not do this, close the game and remove the mod NOW.\n" +
                                    "If you did, congrats you opened up a hole in your security.\n" +
                                    "Do not make issues saying that your system was destroyed by a map, it's your fault for enabling the flags.\n" +
                                    "Read scripts carefully.");
            }
        }

        public static void GetRestrictedClassesExist(PawScriptInstruction[] instructions)
        {
            if (Store.PawScript.PawScriptRestrictedClassesEnabled) return;
            foreach (PawScriptInstruction instruction in instructions)
            {
                if (instruction.Claw.Contains("Restricted"))
                {
                    throw new InvalidDataException("Restricted classes are not allowed in this session.");
                }
            }
        }
    }
}