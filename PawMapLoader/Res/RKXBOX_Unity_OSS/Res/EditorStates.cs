namespace PawMapLoader.Res.RKXBOX_Unity_OSS.Res
{
    using UnityEngine;

    public class EditorStates
    {
        public static EditorStates instance;

        public static void StateSetup()
        {
            instance = new EditorStates();
        }
        
        public GameObject selectedGameObject = null;
    }
}