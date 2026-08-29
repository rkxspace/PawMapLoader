namespace PawMapLoader.Res.RKXBOX_Unity_OSS
{
    //TODO
    using System;
    using Res;
    using Res.ObjectHandler;
    using Res.UI;

    public class main
    {
        public static void Entry()
        {
            Action<int, string> t_ev = null;
            t_ev = (i, s) =>
            {
                if (s != "BlankScene") return;
                BasePlane.CreatePlane();
                EditorCameras.CreateEditorCamera();
                EditorUI.Setup();
                EditorStates.StateSetup();
                FullScreenManager.EnterWindowedEditorMode();
                rm();
            };
            
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