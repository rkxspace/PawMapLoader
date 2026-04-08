using System.Collections.Generic;
using System.Reflection;
using PawMapLoader.Res.PawScript.Claws;

namespace PawMapLoader.Res.PawScript
{
    public class ClawRegister
    {
        public static readonly Dictionary<string, MethodInfo> rClaws = new Dictionary<string, MethodInfo>
        {
            {"Animator.SetParameter", typeof(Animator).GetMethod(nameof(Animator.SetParameter))},
            {"Animator.SetTrigger", typeof(Animator).GetMethod(nameof(Animator.SetTrigger))},
            
            {"GameState.EndGame", typeof(GameState).GetMethod(nameof(GameState.EndGame))},
            {"GameState.RestartGame", typeof(GameState).GetMethod(nameof(GameState.RestartGame))},
            {"GameState.SetTimeScale", typeof(GameState).GetMethod(nameof(GameState.SetTimeScale))},
            {"GameState.ToLobby", typeof(GameState).GetMethod(nameof(GameState.ToLobby))},
            
            {"GarbageManager.Collect", typeof(GarbageManager).GetMethod(nameof(GarbageManager.Collect))},
            
            {"Map.MoveObject", typeof(Map).GetMethod(nameof(Map.MoveObject))},
            {"Map.RotateObject", typeof(Map).GetMethod(nameof(Map.RotateObject))},
            {"Map.ScaleObject", typeof(Map).GetMethod(nameof(Map.ScaleObject))},
            
            {"Math.Evaluate", typeof(Math).GetMethod(nameof(Math.Evaluate))}, //Unfinished - Research how to evaluate.
            {"Math.Float", typeof(Math).GetMethod(nameof(Math.Float))},
            {"Math.Int", typeof(Math).GetMethod(nameof(Math.Int))},
            {"Math.Vector2", typeof(Math).GetMethod(nameof(Math.Vector2))},
            {"Math.Vector3", typeof(Math).GetMethod(nameof(Math.Vector3))},
            {"Math.Vector4", typeof(Math).GetMethod(nameof(Math.Vector4))},
            
            {"MemPointers.CreatePointer", typeof(MemPointers).GetMethod(nameof(MemPointers.CreatePointer))},
            {"MemPointers.DestroyPointer", typeof(MemPointers).GetMethod(nameof(MemPointers.DestroyPointer))},
            
            {"Player.GetMainPlayer", typeof(Player).GetMethod(nameof(Player.GetMainPlayer))},
            
            {"Scene.UnityGameObjectToMemory", typeof(Scene).GetMethod(nameof(Scene.UnityGameObjectToMemory))},
            
            {"Script.ConditionalJump", typeof(Script).GetMethod(nameof(Script.ConditionalJump))},
            {"Script.Jump", typeof(Script).GetMethod(nameof(Script.Jump))},
            {"Script.Dump", typeof(Script).GetMethod(nameof(Script.Dump))},
            {"Script.Log", typeof(Script).GetMethod(nameof(Script.Log))}
            
        };
    }
}