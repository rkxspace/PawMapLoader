namespace PawMapLoader.Res.RKXBOX_Unity_OSS
{
    //TODO
    using Res;
    using Res.ObjectHandler;

    public class main
    {
        public static void Entry()
        {
            FullScreenManager.EnterWindowedEditorMode();
            SceneManagement.EnterBootScene();
            Camera.CreateEditorCamera();
            BasePlane.CreatePlane();
        }

        public static void Exit()
        {
            FullScreenManager.ExitWindowedEditorMode();
            SceneManagement.EnterMainMenuScene();
        }
    }
}