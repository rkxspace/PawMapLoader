namespace PawMapLoader.Res.RKXBOX_Unity_OSS
{
    //TODO
    using System;
    using Res;
    using Res.ObjectHandler;

    public class main
    {
        public static void Entry()
        {
            Action<int, string> t_ev = null;
            t_ev = (Action<int, string>)((i, s) =>
            {
                if (s != "BlankScene") return;
                BasePlane.CreatePlane();
                EditorCameras.CreateEditorCamera();
                FullScreenManager.EnterWindowedEditorMode();
                rm();
            });
            
            void rm()
            {
                Store.InitScnevnt -= t_ev.Invoke; 
            }
            
            Store.InitScnevnt += t_ev.Invoke; 
            SceneManagement.EnterBootScene();
        }

        public static void Exit()
        {
            FullScreenManager.ExitWindowedEditorMode();
            SceneManagement.EnterMainMenuScene();
        }
    }
}