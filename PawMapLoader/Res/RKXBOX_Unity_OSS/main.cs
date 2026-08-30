namespace PawMapLoader.Res.RKXBOX_Unity_OSS
{
    //TODO
    using System;
    using Res;
    using Res.ObjectHandler;
    using Res.ObjectHandler.Data;
    using Res.UI;
    using Res.ViewPortControls;
    using UnityEngine;

    public class main
    {
        private static Store.Update BindingEv = () => Bindings.MouseSelect();
        public static void Entry()
        {
            Action<int, string> t_ev = null;
            t_ev = (i, s) =>
            {
                if (s != "BlankScene") return;
                new PML_Scene();
                BasePlane.CreatePlane();
                EditorCameras.CreateEditorCamera();
                EditorUI.Setup();
                EditorStates.StateSetup();
                Store.Udevnt += BindingEv;
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
            Store.Udevnt -= BindingEv;
            Camera.onPostRender = (Action<Camera>)(s => { });
            FullScreenManager.ExitWindowedEditorMode();
            SceneManagement.EnterMainMenuScene();
        }
    }
}