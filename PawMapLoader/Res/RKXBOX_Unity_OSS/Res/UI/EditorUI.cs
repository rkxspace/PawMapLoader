namespace PawMapLoader.Res.RKXBOX_Unity_OSS.Res.UI
{
    using uGUI;
    using UnityEngine;

    public class EditorUI
    {
        public static void Setup()
        {
            EditorCanvas edtCanvas = new EditorCanvas();
            BoxPanel BottomBar = new BoxPanel(
                edtCanvas,
                "LowerExtentBar",
                new Rect(0.0f, 0.00f, 1f, 0.03f),
                new Color(0.03f, 0.03f, 0.03f));
            BoxPanel BottomAlignedBox = new BoxPanel(
                edtCanvas,
                "BottomPanel",
                new Rect(0.0f, 0.03f, 0.75f, 0.27f),
                new Color(0.08f, 0.08f, 0.08f));
            BoxPanel RightAlignedBox = new BoxPanel(
                edtCanvas,
                "RightPanel",
                new Rect(0.75f, 0.03f, 1f, 1f),
                new Color(0.08f, 0.08f, 0.08f));

            BoxPanel InnerBoxBottomAlignedBox = new BoxPanel(
                BottomAlignedBox,
                "InnerBottomPanel",
                new Rect(0.0f, 0.03f, 0.75f, 0.27f),
                new Color(0.1f, 0.1f, 0.1f)
            );
        }
    }
}