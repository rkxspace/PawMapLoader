using System;
using System.Collections.Generic;
using MelonLoader;
using PawMapLoader.Res.PawScript.Json;
using Object = UnityEngine.Object;

namespace PawMapLoader.Res.PawScript
{
    public class Interpreter
    {
        public static List<object> Memory = new List<object>();
        public static int Executions = 0;

        /// <summary>
        /// This can happen if manually triggered or if the user restarts/exits.
        /// </summary>
        public static void Reset()
        {
            Memory.Clear();
            Executions = 0;
        }

        public static void Interpret(PawScriptInstruction instruction)
        {
            Executions++;
            switch (instruction.Instruction)
            {
                case "ClearMemory": Reset(); break;
                
                case "LoadAssetFromExtraBundle":
                {
                    try
                    {
                        Memory.Add(Store.LoadedAssetBundle?.LoadAsset(instruction.Arguments[0]));
                        MelonLogger.Msg("Stored new asset to position " + (Memory.Count - 1));
                    }
                    catch (Exception e)
                    {
                        MelonLogger.Error("Failed to load asset from bundle (Exec " + Executions + "): " + e.Message + "\n" + e.StackTrace);
                    }

                    break;
                }

                case "PlaceAssetFromMemory":
                {
                    try
                    {
                        Memory.Add(Object.Instantiate((Object)Memory[int.Parse(instruction.Arguments[0])]));
                        MelonLogger.Msg("Stored new instance to position " + (Memory.Count - 1));
                    }
                    catch (Exception e)
                    {
                        MelonLogger.Error("Failed to create instance (Exec " + Executions + "): " + e.Message + "\n" + e.StackTrace);
                    }
                    
                    break;
                }
                
                case "Skip": break;
                
                default: MelonLogger.Error("No Instruction Specified on Exec " + Executions.ToString()); break;
            }
        }
    }
}