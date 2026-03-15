using System.Collections;
using System.Collections.Generic;
using MelonLoader;
using Newtonsoft.Json;
using PawMapLoader.Res.PawScript.Json;
using PawMapLoader.Res.PawScript.Validation;
using UnityEngine;

namespace PawMapLoader.Res.PawScript
{
    public class PawScriptRegister
    {
        // Why does melonloader return an object? Like, seriously?
        public static List<object> RunningScripts = new List<object>();

        public static void Start(string scriptName)
        {
            var pawScriptInstructions = JsonConvert.DeserializeObject<PawScriptInstructions>(FileManagement.GetScriptFile(scriptName));
            RestrictedValidation.GetRestrictedClassesExist(pawScriptInstructions.Instructions);
            RunningScripts.Add(MelonCoroutines.Start(Runner(new Interpreter {InstructionDumpReserve = pawScriptInstructions.Instructions})));

            IEnumerator Runner(Interpreter interpreter)
            {
                for (int i = 0; i < pawScriptInstructions.Instructions.Count; i++)
                {
                    if (pawScriptInstructions.Instructions[i].Delay >= 0)
                        yield return new WaitForSeconds(pawScriptInstructions.Instructions[i].Delay);
                    interpreter.Interpret(pawScriptInstructions.Instructions[i], ref i);
                }
            }
        }

        public static void StopAll()
        {
            foreach (object runningScript in RunningScripts) MelonCoroutines.Stop(runningScript);
            RunningScripts.Clear();
        }
    }
}