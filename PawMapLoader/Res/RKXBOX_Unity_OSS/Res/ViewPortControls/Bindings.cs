namespace PawMapLoader.Res.RKXBOX_Unity_OSS.Res.ViewPortControls
{
    using UnityEngine.InputSystem;

    public class Bindings
    {
        public static void MouseSelect()
        {
            if (Mouse.current.leftButton.wasReleasedThisFrame)
                EditorStates.instance.selectedGameObject = MouseTools.GetHoveredGameObject();
        }
    }
}