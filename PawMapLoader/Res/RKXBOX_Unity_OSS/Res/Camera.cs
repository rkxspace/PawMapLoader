namespace PawMapLoader.Res.RKXBOX_Unity_OSS.Res
{
    using UnityEngine;

    public class Camera
    {
        public static UnityEngine.Camera camera;
        public static RenderTexture renderTexture;

        public static void CreateEditorCamera()
        {
            camera = new GameObject("EditorCamera").AddComponent<UnityEngine.Camera>();
            camera.transform.SetPositionAndRotation(
                new Vector3(3, 3, 3),
                new Quaternion(25, 225, 0, 0)
            );
            //renderTexture = new RenderTexture();
            //renderTexture.
        }
    }
}