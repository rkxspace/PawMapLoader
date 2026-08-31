namespace PawMapLoader.Res.RKXBOX_Unity_OSS.Res.Components
{
    using MelonLoader;
    using UI.uGUI;
    using UnityEngine;
    using ViewPortControls;
    using TextMesh = UI.uGUI.TextMesh;

    [RegisterTypeInIl2Cpp]
    public class Debugger : MonoBehaviour
    {
        public BoxPanel BoxPanel;
        public TextMesh Text;

        private void Update()
        {
            BoxPanel.UpdateRect(new Rect(
                Mathf.Clamp(MouseTools.NrmlMousePos.x + 0.01f, 0.01f, 0.79f),
                Mathf.Clamp(MouseTools.NrmlMousePos.y + 0.01f, 0.03f, 0.89f),
                Mathf.Clamp(MouseTools.NrmlMousePos.x + 0.21f, 0.22f, 1f),
                Mathf.Clamp(MouseTools.NrmlMousePos.y + 0.11f, 0.14f, 1f)
            ));
            Text.textMesh.text = $"MOUSE POS: {(MouseTools.HoveredViewPort ? "VPHOV" : "NHOV")} // " +
                                 $"{MouseTools.NrmlMousePos.x}|{MouseTools.NrmlMousePos.y}" +
                                 $"\nHOVEROBJ: {MouseTools.GetHoveredGameObject()?.name}";
        }
    }
}