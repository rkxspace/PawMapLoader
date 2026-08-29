namespace PawMapLoader.Res.RKXBOX_Unity_OSS.Res.UI.uGUI
{
    using UnityEngine;
    using UnityEngine.UI;

    public class BoxPanel : UIElement
    {
        public RectTransform rectTransform;

        public BoxPanel(EditorCanvas editorCanvas, Rect ScreenSpace, Color colour)
        {
            GameObject bxpnl = new GameObject("BoxPanel");
            bxpnl.transform.SetParent(editorCanvas.Canvas.transform, false);
            Image image = bxpnl.AddComponent<Image>();
            image.color = colour;
            RectTransform rt = bxpnl.GetComponent<RectTransform>();
            rt.anchorMin = new Vector2(ScreenSpace.x, ScreenSpace.y);
            rt.anchorMax = new Vector2(ScreenSpace.width, ScreenSpace.height);
            rt.offsetMin = Vector2.zero;
            rt.offsetMax = Vector2.zero;
            rectTransform = rt;
            SetUI(bxpnl);
        }
    }
}