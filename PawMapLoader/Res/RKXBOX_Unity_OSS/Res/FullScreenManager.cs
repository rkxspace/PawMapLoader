namespace PawMapLoader.Res.RKXBOX_Unity_OSS.Res
{
    using Il2CppInterop.Runtime;
    using UnityEngine;

    public class FullScreenManager
    {
        public static FullScreenMode PreviousMode;
        public static Vector2Int PreviousResolution;

        public static void EnterWindowedEditorMode()
        {
            PreviousMode = Screen.fullScreenMode;
            PreviousResolution = new Vector2Int(
                Screen.currentResolution.width,
                Screen.currentResolution.height
            );

            Screen.SetResolution(
                (int)(Screen.currentResolution.width * 0.75f),
                (int)(Screen.currentResolution.height * 0.75f),
                FullScreenMode.Windowed
            );
        }

        public static void ExitWindowedEditorMode()
        {
            Screen.SetResolution(PreviousResolution.x, PreviousResolution.y, PreviousMode);
        }
    }
}