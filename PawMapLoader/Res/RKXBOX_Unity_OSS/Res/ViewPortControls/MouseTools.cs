namespace PawMapLoader.Res.RKXBOX_Unity_OSS.Res.ViewPortControls
{
    using UnityEngine;
    using UnityEngine.InputSystem;
    using UnityEngine.InputSystem.Controls;

    public class MouseTools
    {
        public static Vector2 MousePos => Mouse.current.position.value;
        public static Vector2 NrmlMousePos => new Vector2(MousePos.x/Screen.width, MousePos.y/Screen.height);
        public static bool HoveredViewPort => EditorCameras.camera.rect.Contains(NrmlMousePos);
        public static Vector2 ScaledMousePos => new Vector2(
            (NrmlMousePos.x - EditorCameras.camera.rect.x)/EditorCameras.camera.rect.width,
            (NrmlMousePos.y - EditorCameras.camera.rect.y)/EditorCameras.camera.rect.height
            );
        
        public static GameObject GetHoveredGameObject()
        {
            if (!HoveredViewPort) return null;
            foreach (Renderer rend in Object.FindObjectsOfType<Renderer>())
            {
                if (rend.bounds.IntersectRay(
                        EditorCameras.camera.ViewportPointToRay(
                            new Vector3(ScaledMousePos.x, ScaledMousePos.y, 0)
                            ))) {
                    return rend.transform.gameObject;
                }
            }
            return null;
        }
    }
}