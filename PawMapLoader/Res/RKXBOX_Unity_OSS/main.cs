namespace PawMapLoader.Res.RKXBOX_Unity_OSS
{
    //TODO
    using Res;
    using Res.ObjectHandler;

    public class main
    {
        public static void Entry()
        {
            SceneManagement.EnterBootScene();
            BasePlane.CreatePlane();
            EditorCameras.CreateEditorCamera();
            FullScreenManager.EnterWindowedEditorMode();
        }

        public static void Exit()
        {
            FullScreenManager.ExitWindowedEditorMode();
            SceneManagement.EnterMainMenuScene();
        }
    }
}