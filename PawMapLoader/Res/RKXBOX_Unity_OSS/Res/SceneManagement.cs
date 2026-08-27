namespace PawMapLoader.Res.RKXBOX_Unity_OSS.Res
{
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class SceneManagement
    {
        public static void EnterBootScene()
        {
            // this is almost certainly the worst way to do this, but hey it works I guess.
            SceneManager.LoadScene(0);
            foreach (GameObject rootGameObject in SceneManager.GetActiveScene().GetRootGameObjects())
            {
                Object.DestroyImmediate(rootGameObject);
            }
        }


        public static void EnterMainMenuScene()
        {
            SceneManager.LoadScene(1);
        }
    }
}