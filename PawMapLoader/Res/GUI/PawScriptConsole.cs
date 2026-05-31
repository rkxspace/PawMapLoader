using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PawMapLoader.Res.GUI
{
    // This GUI crashes the game and I don't know why.
    
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
            
            if (Event.current.type != EventType.Repaint && Event.current.type != EventType.Layout)
                Event.current.Use();
            
            ConsoleRect = UnityEngine.GUI.Window(0, ConsoleRect, (UnityEngine.GUI.WindowFunction)DrawConsole, "PawScript Console");
        }

        public static void DrawConsole(int wid)
        {
            GUILayout.BeginVertical();

            ScrollPos = GUILayout.BeginScrollView(ScrollPos, GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
            foreach (var line in Logs)
            {
                GUILayout.Label(line);
            }
            GUILayout.EndScrollView();
            
            GUILayout.BeginHorizontal();
            inptex = GUILayout.TextField(inptex, GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
            if (GUILayout.Button("Send", GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true)))
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