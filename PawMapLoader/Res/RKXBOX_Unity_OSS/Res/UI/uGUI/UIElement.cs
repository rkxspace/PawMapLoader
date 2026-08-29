namespace PawMapLoader.Res.RKXBOX_Unity_OSS.Res.UI.uGUI
{
    using UnityEngine;

    public abstract class UIElement
    {
        public void SetUI(GameObject UIElement)
        {
            UIElement.layer = LayerMask.NameToLayer("UI");
        }

        public void SetRect(GameObject gameObject, Rect space)
        {
            RectTransform rt = gameObject.GetComponent<RectTransform>();
            rt.anchorMin = new Vector2(space.x, space.y);
            rt.anchorMax = new Vector2(space.width, space.height);
            rt.offsetMin = Vector2.zero;
            rt.offsetMax = Vector2.zero;
        }
    }
}