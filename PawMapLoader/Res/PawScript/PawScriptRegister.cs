using System.Collections;
using System.Collections.Generic;
using MelonLoader;
using Newtonsoft.Json;
using PawMapLoader.Res.PawScript.Json;

namespace PawMapLoader.Res.PawScript
{
    public class PawScriptRegister
    {
        public static List<object> RunningScripts = new List<object>();

        public static void Start(string scriptName)
        {
            var pawScriptInstructions = JsonConvert.DeserializeObject<PawScriptInstructions>(FileManagement.GetScriptFile(scriptName));
            RunningScripts.Add(MelonCoroutines.Start(Runner()));

            IEnumerator Runner()
            {
                foreach (PawScriptInstruction instruction in pawScriptInstructions.Instructions)
                {
                    Interpreter.Interpret(instruction);
                    yield return null;
                }
            }
        }

        public static void StopAll()
        {
            foreach (object runningScript in RunningScripts) MelonCoroutines.Stop(runningScript);
        }
    }
}