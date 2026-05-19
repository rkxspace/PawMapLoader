using System.Collections;
using System.Collections.Generic;
using MelonLoader;
using Newtonsoft.Json;
using PawMapLoader.Res.PawScript.Events;
using PawMapLoader.Res.PawScript.Json;
using UnityEngine;

namespace PawMapLoader.Res.PawScript
{
    public class PawScriptRegister
    {
        public static List<object> RunningScripts = new List<object>();
        public static double lastFrameTime = 0;

        public static void Start(string scriptName, DamageEvent dmgEvent = null)
        {
            var pawScriptInstructions = JsonConvert.DeserializeObject<PawScriptInstructions>(FileManagement.GetScriptFile(scriptName));
            RunningScripts.Add(MelonCoroutines.Start(Runner(new Interpreter {InstructionDumpReserve = pawScriptInstructions.Instructions})));

            IEnumerator Runner(Interpreter interpreter)
            {
                if (dmgEvent != null)
                {
                    interpreter.Memory = new Dictionary<int, object>
                    {
                        { 0, dmgEvent.source },
                        { 1, dmgEvent.damageable.MaxHealth },
                        { 2, dmgEvent.damageable.Health },
                        { 3, dmgEvent.damage.Player },
                        { 4, dmgEvent.damage.IsDirectHit },
                        { 5, dmgEvent.damage.Direction },
                        { 6, dmgEvent.damage.Amount },
                        { 7, dmgEvent.eventParams.OldHealth },
                        { 8, dmgEvent.eventParams.NewHealth }

                    };
                    interpreter.NamedPtr = new Dictionary<string, int>
                    {
                        {"EventSource", 0},
                        {"MaxHealth", 1},
                        {"Health", 2},
                        {"Player", 3},
                        {"IsDirectHit", 4},
                        {"Direction", 5},
                        {"Amount", 6},
                        {"OldHealth", 7},
                        {"NewHealth", 8},
                    };
                }
                for (int i = 0; i < pawScriptInstructions.Instructions.Count; i++) 
                {
                    if ((Time.timeAsDouble - lastFrameTime) > 0.1)
                    {
                        MelonLogger.Warning($"Pawscript instruction delayed by 1 second: Frame has not been produced in {Time.timeAsDouble - lastFrameTime}.");
                        yield return new WaitForSeconds(1f);
                    }
                    if (pawScriptInstructions.Instructions[i].Delay > 0)
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