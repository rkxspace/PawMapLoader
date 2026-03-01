using System.Collections;
using System.Collections.Generic;
using MelonLoader;
using Newtonsoft.Json;
using PawMapLoader.Res.PawScript.Json;

namespace PawMapLoader.Res.PawScript
{
    public class PawScriptRegister
    {
        // Why does melonloader return an object? Like, seriously?
        public static List<object> RunningScripts = new List<object>();

        public static void Start(string scriptName)
        {
            var pawScriptInstructions = JsonConvert.DeserializeObject<PawScriptInstructions>(FileManagement.GetScriptFile(scriptName));
            RunningScripts.Add(MelonCoroutines.Start(Runner(new Interpreter())));

            IEnumerator Runner(Interpreter interpreter)
            {
                for (int i = 0; i < pawScriptInstructions.Instructions.Count; i++)
                {
                    interpreter.Interpret(pawScriptInstructions.Instructions[i], ref i);
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