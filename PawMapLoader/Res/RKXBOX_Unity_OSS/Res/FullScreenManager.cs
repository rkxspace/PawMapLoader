namespace PawMapLoader.Res.RKXBOX_Unity_OSS.Res
{
    public class FullScreenManager
    {
        public static UnityEngine.FullScreenMode PreviousMode;
        public static void EnterWindowedEditorMode()
        {
            PreviousMode = UnityEngine.Screen.fullScreenMode;
            UnityEngine.Screen.fullScreenMode = UnityEngine.FullScreenMode.Windowed;
        }

        public static void ExitWindowedEditorMode()
        {
            UnityEngine.Screen.fullScreenMode = PreviousMode;
        }
    }
}