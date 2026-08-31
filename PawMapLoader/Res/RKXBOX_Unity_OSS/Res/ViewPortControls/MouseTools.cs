namespace PawMapLoader.Res.RKXBOX_Unity_OSS.Res.ViewPortControls
{
    using System.Collections.Generic;
    using ObjectHandler;
    using ObjectHandler.Data;
    using UnityEngine;
    using UnityEngine.InputSystem;

    public class MouseTools
    {
        public static Vector2 RotationDelta = Vector2.zero;

        public static Vector2 StartPos = Vector2.zero;
        public static Vector2 MousePos => Mouse.current.position.ReadValue();
        public static Vector2 NrmlMousePos => new Vector2(MousePos.x / Screen.width, MousePos.y / Screen.height);
        public static bool HoveredViewPort => EditorCameras.camera.rect.Contains(NrmlMousePos);
        public static double dragDistance => Distance.DistanceBetween(StartPos, NrmlMousePos);

        public static Vector2 ScaledMousePos => new Vector2(
            (NrmlMousePos.x - EditorCameras.camera.rect.x) / EditorCameras.camera.rect.width,
            (NrmlMousePos.y - EditorCameras.camera.rect.y) / EditorCameras.camera.rect.height
        );

        public static Vector2 NrmlMousePosToAbsolute(Vector2 nrmlMousePos) =>
            new Vector2(
                NrmlMousePos.x * Screen.width, NrmlMousePos.y * Screen.height
            );

        public static Vector2 FullScreenToScaledPos(Vector2 fullScreenPos) =>
            new Vector2(
                (fullScreenPos.x - EditorCameras.camera.rect.x) / EditorCameras.camera.rect.width,
                (fullScreenPos.y - EditorCameras.camera.rect.y) / EditorCameras.camera.rect.height
            );

        public static Vector2 ScaledPosToFullScreen(Vector2 scaledPos) =>
            new Vector2(
                scaledPos.x * EditorCameras.camera.rect.width + EditorCameras.camera.rect.x,
                scaledPos.y * EditorCameras.camera.rect.height + EditorCameras.camera.rect.y
            );

        public static GameObject GetHoveredGameObject()
        {
            if (!HoveredViewPort) return null;
            List<KeyValuePair<string, SceneObj>> potentialObj = new List<KeyValuePair<string, SceneObj>>();
            foreach (KeyValuePair<string, SceneObj> sceneObj in PML_Scene.Instance.sceneData)
            {
                if (sceneObj.Value.Renderer.bounds.IntersectRay(
                        EditorCameras.camera.ViewportPointToRay(
                            new Vector3(ScaledMousePos.x, ScaledMousePos.y, 0)
                        )))
                {
                    potentialObj.Add(sceneObj);
                }
            }

            potentialObj.Sort((a, b) =>
                {
                    double d = Distance.DistanceBetween(
                        a.Value.Renderer.bounds.center, Camera.current.transform.position
                    );
                    double e = Distance.DistanceBetween(
                        b.Value.Renderer.bounds.center, Camera.current.transform.position
                    );
                    return d.CompareTo(e);
                }
            );
            return potentialObj.Count > 0 ? potentialObj[0].Value.GameObject : null;
        }
    }
}