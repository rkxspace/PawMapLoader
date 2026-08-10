using System.Collections.Generic;
using PawMapLoader.Res.PawScript.Claws;
using PawMapLoader.Res.PawScript.Json;

namespace PawMapLoader.Res.PawScript
{
    public delegate void InstructionDelegate(PawScriptInstruction instruction, ref int instructionSetter,
        Interpreter interpreter);

    public class ClawRegister
    {
        public static readonly IReadOnlyDictionary<string, InstructionDelegate> rClaws =
            new Dictionary<string, InstructionDelegate>
            {
                { "Animator.SetParameter", Animator.SetParameter },
                { "Animator.SetTrigger", Animator.SetTrigger },

                { "GameState.EndGame", GameState.EndGame },
                { "GameState.RestartGame", GameState.RestartGame },
                { "GameState.SetTimeScale", GameState.SetTimeScale },
                { "GameState.ToLobby", GameState.ToLobby },

                { "GarbageManager.Collect", GarbageManager.Collect },

                { "Map.MoveObject", Map.MoveObject },
                { "Map.RotateObject", Map.RotateObject },
                { "Map.ScaleObject", Map.ScaleObject },
                { "Map.DestroyObject", Map.DestroyObject },

                { "Math.Float", Math.Float },
                { "Math.Int", Math.Int },
                { "Math.Vector2", Math.Vector2 },
                { "Math.Vector3", Math.Vector3 },
                { "Math.Vector4", Math.Vector4 },
                { "Math.FloatAdd", Math.FloatAdd },
                { "Math.FloatSub", Math.FloatSub },
                { "Math.FloatMul", Math.FloatMul },
                { "Math.FloatDiv", Math.FloatDiv },
                { "Math.FloatMod", Math.FloatMod },
                { "Math.IntAdd", Math.IntAdd },
                { "Math.IntSub", Math.IntSub },
                { "Math.IntMul", Math.IntMul },
                { "Math.IntDiv", Math.IntDiv },
                { "Math.IntMod", Math.IntMod },

                { "MemPointers.CreatePointer", MemPointers.CreatePointer },
                { "MemPointers.DestroyPointer", MemPointers.DestroyPointer },

                { "Player.GetMainPlayer", Player.GetMainPlayer },
                { "Player.GetPlayer", Player.GetPlayer },
                { "Player.AddScale", Player.AddScale },

                { "Scene.UnityGameObjectToMemory", Scene.UnityGameObjectToMemory },
                { "Scene.ImportObjectToScene", Scene.ImportObjectToScene },

                { "Script.ConditionalJump", Script.ConditionalJump },
                { "Script.Jump", Script.Jump },
                { "Script.Dump", Script.Dump },
                { "Script.Log", Script.Log }
            };
    }
}