namespace PawMapLoader.Res.RKXBOX_Unity_OSS.Res.UI.uGUI
{
    using Components;
    using UnityEngine;
    using UnityEngine.UI;

    public class EditorCanvas : UIElement
    {
        public Canvas Canvas;

        public EditorCanvas()
        {
            GameObject canvasObj = new GameObject("EditorUI");
            Canvas canvas = canvasObj.AddComponent<Canvas>();
            canvasObj.AddComponent<CanvasScaler>();
            canvasObj.AddComponent<GraphicRaycaster>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            Canvas = canvas;
            SetUI(canvasObj);
        }
    }
}