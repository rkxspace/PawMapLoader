namespace PawMapLoader.Res.RKXBOX_Unity_OSS.Res.Components
{
    using MelonLoader;
    using UnityEngine;
    using ViewPortControls;
    using TextMesh = UI.uGUI.TextMesh;

    [RegisterTypeInIl2Cpp]
    public class Debugger : MonoBehaviour
    {
        public TextMesh Text;

        private void Update()
        {
            Text.textMesh.text = $"MOUSE POS: {(MouseTools.HoveredViewPort ? "VPHOV" : "NHOV")} // " +
                                 $"{MouseTools.NrmlMousePos.x}|{MouseTools.NrmlMousePos.y}" +
                                 $"\nHOVEROBJ: {MouseTools.GetHoveredGameObject().name}";
        }
    }
}