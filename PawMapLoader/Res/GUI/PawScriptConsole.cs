using System.Collections.Generic;
using MelonLoader;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PawMapLoader.Res.GUI
{
    
    public class PawScriptConsole
    {
        public static void Register()
        {
            Store.UdevntGUI += GUIUpdate;
            Store.Udevnt += Update;
        }
        
        public static bool ConsoleShown = false;
        public static Rect ConsoleRect = new Rect(Screen.width*.45f, Screen.height*.04f, Screen.width*.55f, Screen.height*.6f);
        public static List<string> Logs = new List<string>();
        public static Vector2 ScrollPos = Vector2.zero;
        public static string inptex = "";

        public static void Update()
        {
            if (Keyboard.current.rightShiftKey.isPressed && Keyboard.current.backquoteKey.wasPressedThisFrame)
            {
                ConsoleShown = !ConsoleShown;
            }
        }

        public static void GUIUpdate()
        {
            if (!ConsoleShown) return;
            
            MelonLogger.Msg("crdraw");
            ConsoleRect = UnityEngine.GUI.Window(0, ConsoleRect, (UnityEngine.GUI.WindowFunction)DrawConsole, "PawScript Console");
        }

        public static void DrawConsole(int wid)
        {
            MelonLogger.Msg("start");
            GUILayout.BeginVertical();

            MelonLogger.Msg("1");
            ScrollPos = GUILayout.BeginScrollView(ScrollPos, GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
            MelonLogger.Msg("2");
            foreach (var line in Logs)
            {
                GUILayout.Label(line);
            }
            MelonLogger.Msg("3");
            GUILayout.EndScrollView();
            MelonLogger.Msg("4");
            GUILayout.BeginHorizontal();
            MelonLogger.Msg("5");
            inptex = GUILayout.TextField(inptex, GUILayout.ExpandWidth(true), GUILayout.Height(30));
            MelonLogger.Msg("6");
            if (GUILayout.Button("Send", GUILayout.Width(80), GUILayout.Height(30)))
            {
                HandleInput(inptex);
                inptex = "";
            }
            MelonLogger.Msg("7");
            GUILayout.EndHorizontal();
            MelonLogger.Msg("8");
            GUILayout.EndVertical();
            MelonLogger.Msg("9");
            UnityEngine.GUI.DragWindow();
            MelonLogger.Msg("10");
        }

        public static void HandleInput(string input)
        {
            
        }
    }
}