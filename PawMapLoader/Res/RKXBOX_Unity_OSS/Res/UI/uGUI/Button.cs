namespace PawMapLoader.Res.RKXBOX_Unity_OSS.Res.UI.uGUI
{
    using System;
    using Il2CppTMPro;
    using UnityEngine;
    using UnityEngine.UI;

    public class PanelButton : UIElement
    {
        public Button Button;
        public BoxPanel ButtonBacking;
        public TextMesh ButtonText;

        public PanelButton(BoxPanel panel, string name, string text, float fontSize, Color fontColor,
            TextAlignmentOptions alignment, Color colour, Action onClick, Rect localSpace)
        {
            ButtonBacking = new BoxPanel(panel, $"ButtonBacking-{name}", localSpace, colour);
            ButtonText = new TextMesh(
                ButtonBacking, $"ButtonText-{name}", text, fontSize,
                alignment, new Rect(0, 0, 1, 1), fontColor);
            Button = ButtonBacking.rectTransform.gameObject.AddComponent<Button>();
            Button.onClick.AddListener(onClick);
        }
    }
}