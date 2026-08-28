namespace PawMapLoader.Res.RKXBOX_Unity_OSS.Res
{
    using UnityEngine;

    public class EditorCameras
    {
        public static Camera camera;
        public static Camera UICamera;

        public static void CreateEditorCamera()
        {
            camera = new GameObject("EditorSceneCamera").AddComponent<Camera>();
            camera.transform.SetPositionAndRotation(
                new Vector3(8, 5, 8),
                Quaternion.Euler(25, 225, 0)
            );
            camera.rect = new Rect(0.0f, 0.3f, 0.7f, 0.7f);
            camera.depth = 0;

            UICamera = new GameObject("UICamera").AddComponent<Camera>();
            UICamera.clearFlags = CameraClearFlags.Nothing;
            UICamera.orthographic = true;
            UICamera.depth = 10;
            UICamera.cullingMask = LayerMask.GetMask("UI");
        }
    }
}