namespace PawMapLoader.Res.RKXBOX_Unity_OSS.Res
{
    public class SceneManagement
    {
        public static void EnterBootScene()
        {
            // this is almost certainly the worst way to do this, but hey it works I guess.
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            foreach (UnityEngine.GameObject rootGameObject in UnityEngine.GameObject.GetScene(0).GetRootGameObjects())
            {
                UnityEngine.Object.DestroyImmediate(rootGameObject);
            }
        }

        public static void EnterMainMenuScene()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        }
    }
}