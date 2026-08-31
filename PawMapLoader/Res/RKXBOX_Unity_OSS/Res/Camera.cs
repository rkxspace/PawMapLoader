namespace PawMapLoader.Res.RKXBOX_Unity_OSS.Res
{
    using Components;
    using UnityEngine;
    using UnityEngine.Rendering.Universal;

    public class EditorCameras
    {
        public static Camera camera;
        public static Vector3 OriginalRot = Vector3.zero;

        public static void CreateEditorCamera()
        {
            camera = new GameObject("EditorSceneCamera").AddComponent<Camera>();
            camera.gameObject.AddComponent<UniversalAdditionalCameraData>();
            camera.gameObject.AddComponent<PostRenderHelper>();
            camera.transform.SetPositionAndRotation(
                new Vector3(8, 5, 8),
                Quaternion.Euler(25, 225, 0)
            );
            camera.rect = EditorStates.instance.cameraRect;
            camera.depth = 0;
            camera.tag = "MainCamera";
        }
    }
}