namespace PawMapLoader.Res.RKXBOX_Unity_OSS.Res.ViewPortControls
{
    using UnityEngine;

    public class MouseTools
    {
        public static Vector2 MousePos => Input.mousePosition;
        public static Vector2 NrmlMousePos => new Vector2(MousePos.x/Screen.width, MousePos.y/Screen.height);
        public static bool HoveredViewPort => EditorCameras.camera.rect.Contains(NrmlMousePos);
        public static Vector2 ScaledMousePos => new Vector2(
            (NrmlMousePos.x - EditorCameras.camera.rect.x)/EditorCameras.camera.rect.width,
            (NrmlMousePos.y - EditorCameras.camera.rect.y)/EditorCameras.camera.rect.height
            );
        
        public static GameObject GetHoveredGameObject()
        {
            if (!HoveredViewPort) return null;
            if (Physics.Raycast(
                    EditorCameras.camera.ViewportPointToRay(new Vector3(ScaledMousePos.x, ScaledMousePos.y, 0)),
                    out RaycastHit hit))
                return hit.transform.gameObject;
            return null;
        }
    }
}