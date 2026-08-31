namespace PawMapLoader.Res.RKXBOX_Unity_OSS.Res.UI
{
    using Components;
    using Il2CppTMPro;
    using uGUI;
    using UnityEngine;
    using TextMesh = uGUI.TextMesh;

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
            BoxPanel DebugPanel = new BoxPanel(
                edtCanvas,
                "DebugPanel",
                new Rect(0.0f, 0.5f, 0.4f, 1f),
                new Color(0.08f, 0.08f, 0.08f));

            /*** INNER PANEL ***/

            BoxPanel InnerBoxBottomAlignedBox = new BoxPanel(
                BottomAlignedBox,
                "InnerBottomPanel",
                new Rect(0.0f, 0.00f, 1f, 0.87f),
                new Color(0.12f, 0.12f, 0.12f)
            );

            BoxPanel InnerBoxRightAlignedBox = new BoxPanel(
                RightAlignedBox,
                "InnerRightPanel",
                new Rect(0.0f, 0.00f, 1f, 0.967f),
                new Color(0.12f, 0.12f, 0.12f)
            );

            /*** BOTTOM BAR TEXT ***/

            TextMesh BottomBarVersionText = new TextMesh(
                BottomBar,
                "VersionText",
                VersionString.PMLVersion,
                12,
                TextAlignmentOptions.Left,
                new Rect(0f, 0f, 0.5f, 1f),
                new Color(0.6f, 0.6f, 0.6f)
            );

            TextMesh DebugText = new TextMesh(
                DebugPanel,
                "DebugText",
                string.Empty,
                12,
                TextAlignmentOptions.Left,
                new Rect(0f, 0f, 1f, 1f),
                new Color(1f, 1f, 1f)
            );

            Debugger dbghelper = DebugPanel.rectTransform.gameObject.AddComponent<Debugger>();
            dbghelper.Text = DebugText;
            dbghelper.BoxPanel = DebugPanel;
        }
    }
}