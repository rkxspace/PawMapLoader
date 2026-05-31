using System.Collections.Generic;
using UnityEngine;

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
            if (Input.GetKeyDown(KeyCode.RightShift) && Input.GetKeyDown(KeyCode.Tilde))
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

            GUILayout.BeginScrollView(ScrollPos, GUILayout.Width(ConsoleRect.width), GUILayout.Height(ConsoleRect.height*0.95f));
            foreach (var line in Logs)
            {
                GUILayout.Label(line);
            }
            GUILayout.EndScrollView();
            
            GUILayout.BeginHorizontal();
            inptex = GUILayout.TextField(inptex, GUILayout.Width(ConsoleRect.width*0.92f), GUILayout.Height(ConsoleRect.height*0.05f));
            if (GUILayout.Button("Send", GUILayout.Width(ConsoleRect.width * 0.05f),
                    GUILayout.Height(ConsoleRect.height * 0.08f))) ;
        }
    }
}