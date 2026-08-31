namespace PawMapLoader.Res.RKXBOX_Unity_OSS.Res
{
    using UnityEngine;

    public class EditorStates
    {
        public static EditorStates instance;
        private Rect _cameraRect = new Rect(0.0f, 0.25f, 0.75f, 0.75f);
        public CursorLockMode cursorLockMode = CursorLockMode.None;

        public GameObject selectedGameObject = null;

        public Rect cameraRect
        {
            get => _cameraRect;
            set
            {
                _cameraRect = value;
                EditorCameras.camera.rect = _cameraRect;
            }
        }

        public static void StateSetup()
        {
            instance = new EditorStates();
        }
    }
}