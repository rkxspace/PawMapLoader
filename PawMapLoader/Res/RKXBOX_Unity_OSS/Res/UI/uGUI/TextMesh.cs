namespace PawMapLoader.Res.RKXBOX_Unity_OSS.Res.UI.uGUI
{
    using Il2CppTMPro;
    using UnityEngine;

    public class TextMesh : UIElement
    {
        public TextMeshProUGUI textMesh;

        public TextMesh(BoxPanel bxpnl, string name,
            string text, float fontSize,
            TextAlignmentOptions alignment,
            Rect localSpace, Color textColor)
        {
            GameObject textObj = new GameObject($"TMP_{name}");
            textObj.transform.SetParent(textObj.transform);
            TextMeshProUGUI tmp = textObj.AddComponent<TextMeshProUGUI>();
            tmp.text = text;
            tmp.fontSize = fontSize;
            tmp.color = textColor;
            tmp.alignment = alignment;
            SetRect(textObj, localSpace);
            textMesh = tmp;
            SetUI(textObj);
        }
    }
}