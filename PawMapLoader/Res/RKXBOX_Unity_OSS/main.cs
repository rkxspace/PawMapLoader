namespace PawMapLoader.Res.RKXBOX_Unity_OSS
{
    public class main
    {
        public static void Entry()
        {
            Res.FullScreenManager.EnterWindowedEditorMode();
            Res.SceneManagement.EnterBootScene();
            Res.Camera.CreateEditorCamera();
        }
    }
}