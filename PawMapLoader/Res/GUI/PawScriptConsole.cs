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
        public static Rect ConsoleRect;
        public static string ConsoleName = "PawScript Console";
        public static int ConsoleID = ConsoleName.GetHashCode();
        public static List<string> Logs = new List<string>();
        public static Vector2 ScrollPos = Vector2.zero;
        public static string inptex = "";

        public static void Update()
        {
            if (Keyboard.current.rightShiftKey.isPressed && Keyboard.current.backquoteKey.wasPressedThisFrame)
            {
                ConsoleRect = new Rect(Screen.width * .6f, Screen.height * .04f, Screen.width * .4f, Screen.height * .6f);
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
            // emptied to diagnose point of crash
        }
        
        public static void HandleInput(string input)
        {
            
        }
    }
}