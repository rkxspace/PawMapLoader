namespace PawMapLoader.Res.RKXBOX_Unity_OSS.Res
{
    using System.IO;
    using System.Reflection;
    using UnityEngine;
    using UnityEngine.SceneManagement;
    using Object = UnityEngine.Object;

    public class SceneManagement
    {
        public static void EnterBootScene()
        {
            Stream blank = Assembly.GetCallingAssembly().GetManifestResourceStream("PawMapLoader.Res.RKXBOX_Unity_OSS" +
                ".Assets.blankScene");

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