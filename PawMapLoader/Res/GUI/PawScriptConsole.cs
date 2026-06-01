using System.Collections.Generic;
using MelonLoader;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PawMapLoader.Res.GUI
{
    public class PawScriptConsole
    {
        public static PawScript.Interpreter consoleInterpreter;
        public static void Register()
        {
            Store.UdevntGUI += GUIUpdate;
            Store.Udevnt += Update;
            consoleInterpreter = new PawScript.Interpreter();
        }
        
        public static bool ConsoleShown = false;
        public static Rect ConsoleRect = new Rect(Screen.width * .6f, Screen.height * .04f, Screen.width * .4f, Screen.height * .6f);
        public static string ConsoleName = "PawScript Console";
        public static int ConsoleID = ConsoleName.GetHashCode();
        public static List<string> Logs = new List<string>();
        public static Vector2 ScrollPos = Vector2.zero;
        public static string inptex = "";
        
        public static float WindowPadding = 5f;
        public static float LineHeight = 20f;
        public static float CommandBarHeight = 30f;
        
        public static Rect LogRect = new Rect(WindowPadding, WindowPadding, ConsoleRect.width - 2*WindowPadding, (Screen.height - 2*WindowPadding) - CommandBarHeight);
        public static Rect LogContentRect = new Rect(0f, 0f, LogRect.width - 20f, LogRect.height);

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
            
            ConsoleRect = UnityEngine.GUI.Window(ConsoleID, ConsoleRect, (UnityEngine.GUI.WindowFunction)DrawConsole, ConsoleName);
        }

        public static void DrawConsole(int wid)
        { // Days wasted fixing crash: 0
            ScrollPos = UnityEngine.GUI.BeginScrollView(LogRect, ScrollPos, LogContentRect, false, true);
            UnityEngine.GUI.EndScrollView();
        }
        
        public static void HandleInput(string input)
        {
            
        }
    }
}