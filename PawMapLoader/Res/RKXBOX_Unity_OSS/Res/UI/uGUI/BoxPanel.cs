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
            SetRect(bxpnl, screenSpace);
            rectTransform = bxpnl.GetComponent<RectTransform>();
            SetUI(bxpnl);
        }

        public BoxPanel(BoxPanel UprBxPnl, string name, Rect localSpace, Color colour)
        {
            GameObject bxpnl = new GameObject($"InnerBoxPanel-{name}");
            bxpnl.transform.SetParent(UprBxPnl.rectTransform, false);
            Image image = bxpnl.AddComponent<Image>();
            image.color = colour;
            SetRect(bxpnl, localSpace);
            rectTransform = bxpnl.GetComponent<RectTransform>();
            SetUI(bxpnl);
        }

        public void UpdateRect(Rect rect)
        {
            rectTransform.anchorMin = new Vector2(rect.x, rect.y);
            rectTransform.anchorMax = new Vector2(rect.width, rect.height);
            rectTransform.offsetMin = Vector2.zero;
            rectTransform.offsetMax = Vector2.zero;
        }
    }
}