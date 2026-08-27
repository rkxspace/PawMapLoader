namespace PawMapLoader.Res.RKXBOX_Unity_OSS
{
    using Res;

    public class main
    {
        public static void Entry()
        {
            FullScreenManager.EnterWindowedEditorMode();
            SceneManagement.EnterBootScene();
            Camera.CreateEditorCamera();
        }

        public static void Exit()
        {
            FullScreenManager.ExitWindowedEditorMode();
            SceneManagement.EnterMainMenuScene();
        }
    }
}