namespace PawMapLoader.Res.RKXBOX_Unity_OSS.Res.UI
{
    using uGUI;
    using UnityEngine;

    public class EditorUI
    {
        public static void Setup()
        {
            EditorCanvas edtCanvas = new EditorCanvas();
            BoxPanel bxpnl01 = new BoxPanel(edtCanvas, new Rect(0.0f, 0.0f, 1f, 1f));
        }
    }
}