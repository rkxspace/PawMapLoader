namespace PawMapLoader.Res.RKXBOX_Unity_OSS.Res
{
    public class Camera
    {
        public static UnityEngine.Camera camera;
        public static void CreateEditorCamera()
        {
            camera = new UnityEngine.GameObject().AddComponent<UnityEngine.Camera>();
            camera.transform.Rotate(new UnityEngine.Vector3(25, 225, 0));
        }
    }
}