namespace PawMapLoader.Res.RKXBOX_Unity_OSS.Res.UI.uGUI
{
    using UnityEngine;
    using UnityEngine.UI;

    public class BoxPanel : UIElement
    {
        public RectTransform rectTransform;

        public BoxPanel(EditorCanvas editorCanvas, string name, Rect screenSpace, Color colour)
        {
            GameObject bxpnl = new GameObject($"RootBoxPanel-{name}");
            bxpnl.transform.SetParent(editorCanvas.Canvas.transform, false);
            Image image = bxpnl.AddComponent<Image>();
            image.color = colour;
            RectTransform rt = bxpnl.GetComponent<RectTransform>();
            rt.anchorMin = new Vector2(screenSpace.x, screenSpace.y);
            rt.anchorMax = new Vector2(screenSpace.width, screenSpace.height);
            rt.offsetMin = Vector2.zero;
            rt.offsetMax = Vector2.zero;
            rectTransform = rt;
            SetUI(bxpnl);
        }

        public BoxPanel(BoxPanel UprBxPnl, string name, Rect localSpace, Color colour)
        {
            GameObject bxpnl = new GameObject($"InnerBoxPanel-{name}");
            bxpnl.transform.SetParent(UprBxPnl.rectTransform, false);
            Image image = bxpnl.AddComponent<Image>();
            image.color = colour;
            RectTransform rt = bxpnl.GetComponent<RectTransform>();
            rt.anchorMin = new Vector2(localSpace.x, localSpace.y);
            rt.anchorMax = new Vector2(localSpace.width, localSpace.height);
            rt.offsetMin = Vector2.zero;
            rt.offsetMax = Vector2.zero;
            rectTransform = rt;
            SetUI(bxpnl);
        }
    }
}