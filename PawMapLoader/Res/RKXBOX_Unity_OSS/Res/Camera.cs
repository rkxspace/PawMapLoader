namespace PawMapLoader.Res.RKXBOX_Unity_OSS.Res
{
    using Components;
    using UnityEngine;
    using UnityEngine.Rendering.Universal;

    public class EditorCameras
    {
        public static Camera camera;

        public static void CreateEditorCamera()
        {
            camera = new GameObject("EditorSceneCamera").AddComponent<Camera>();
            camera.gameObject.AddComponent<UniversalAdditionalCameraData>();
            camera.gameObject.AddComponent<PostRenderHelper>();
            camera.transform.SetPositionAndRotation(
                new Vector3(8, 5, 8),
                Quaternion.Euler(25, 225, 0)
            );
            camera.rect = new Rect(0.0f, 0.25f, 0.75f, 0.75f);
            camera.depth = 0;
            camera.tag = "MainCamera";
        }
    }
}