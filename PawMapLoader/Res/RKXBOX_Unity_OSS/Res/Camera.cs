namespace PawMapLoader.Res.RKXBOX_Unity_OSS.Res
{
    using UnityEngine;

    public class Camera
    {
        public static UnityEngine.Camera camera;
        public static UnityEngine.Camera UICamera;

        public static void CreateEditorCamera()
        {
            camera = new GameObject("EditorSceneCamera").AddComponent<UnityEngine.Camera>();
            camera.transform.SetPositionAndRotation(
                new Vector3(3, 3, 3),
                Quaternion.Euler(25, 225, 0) // what the fuck is this
            );
            camera.rect = new Rect(0.3f, 0f, 0.7f,  0.7f);
            
            UICamera = new GameObject("UICamera").AddComponent<UnityEngine.Camera>();
            UICamera.clearFlags = CameraClearFlags.Depth;
            UICamera.backgroundColor = Color.black;
            UICamera.orthographic = true;
            UICamera.depth = 10;
            UICamera.cullingMask = LayerMask.GetMask("UI");
        }
    }
}