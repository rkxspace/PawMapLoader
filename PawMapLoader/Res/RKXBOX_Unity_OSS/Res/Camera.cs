namespace PawMapLoader.Res.RKXBOX_Unity_OSS.Res
{
    using UnityEngine;
    using UnityEngine.Rendering.Universal;

    public class EditorCameras
    {
        public static Camera camera;
        public static Camera UICamera;

        public static void CreateEditorCamera()
        {
            camera = new GameObject("EditorSceneCamera").AddComponent<Camera>();
            camera.gameObject.AddComponent<UniversalAdditionalCameraData>();
            camera.transform.SetPositionAndRotation(
                new Vector3(8, 5, 8),
                Quaternion.Euler(25, 225, 0)
            );
            camera.rect = new Rect(0.0f, 0.3f, 0.7f, 0.7f);
            camera.depth = 0;
            camera.tag = "MainCamera";
            
            /*
            UICamera = new GameObject("UICamera").AddComponent<Camera>();
            UICamera.gameObject.AddComponent<UniversalAdditionalCameraData>();
            UICamera.clearFlags = CameraClearFlags.Skybox;
            UICamera.orthographic = true;
            UICamera.cullingMask = LayerMask.GetMask("UI");
            
            camera.GetUniversalAdditionalCameraData().cameraStack.Add(UICamera);*/
        }
    }
}