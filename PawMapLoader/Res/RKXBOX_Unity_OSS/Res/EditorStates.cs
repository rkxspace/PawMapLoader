namespace PawMapLoader.Res.RKXBOX_Unity_OSS.Res
{
    using System;
    using UnityEngine;
    using Random = System.Random;

    public class EditorStates
    {
        public static EditorStates instance;
        private Rect _cameraRect = new Rect(0.0f, 0.27f, 0.75f, 0.73f);
        public CursorLockMode cursorLockMode = CursorLockMode.None;

        public Random globalRandom = new Random();

        public GameObject selectedGameObject = null;

        public Guid getGuid => Guid.NewGuid();

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