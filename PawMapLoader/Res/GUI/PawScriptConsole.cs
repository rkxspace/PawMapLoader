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
        public static Rect ConsoleRect = new Rect(Screen.width*.6f, Screen.height*.04f, Screen.width*.4f, Screen.height*.6f);
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
        { // another attempt at fixing this damned crash
            float inputBarHeight = 30f;
            float scrollHeight = ConsoleRect.height - inputBarHeight - 25f;

            GUILayout.BeginVertical();

            ScrollPos = GUILayout.BeginScrollView(ScrollPos, GUILayout.ExpandWidth(true), GUILayout.Height(scrollHeight));
            foreach (var line in Logs)
            {
                GUILayout.Label(line);
            }
            GUILayout.EndScrollView();

            GUILayout.BeginHorizontal();
            inptex = GUILayout.TextField(inptex, GUILayout.ExpandWidth(true), GUILayout.Height(inputBarHeight));
            if (GUILayout.Button("Send", GUILayout.Width(80), GUILayout.Height(inputBarHeight)))
            {
                HandleInput(inptex);
                inptex = "";
            }
            GUILayout.EndHorizontal();

            GUILayout.EndVertical();
            UnityEngine.GUI.DragWindow();
        }
        
        public static void HandleInput(string input)
        {
            
        }
    }
}