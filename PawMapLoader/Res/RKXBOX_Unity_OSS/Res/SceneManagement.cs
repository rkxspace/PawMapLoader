namespace PawMapLoader.Res.RKXBOX_Unity_OSS.Res
{
    using System.IO;
    using System.Reflection;
    using UnityEngine;
    using UnityEngine.SceneManagement;
    using MemoryStream = Il2CppSystem.IO.MemoryStream;
    using Object = UnityEngine.Object;

    public class SceneManagement
    {
        public static void EnterBootScene()
        {
            Stream blank = Assembly.GetCallingAssembly().GetManifestResourceStream("PawMapLoader.Res.RKXBOX_Unity_OSS" +
                ".Assets.blankScene");

            byte[] temp = new byte[blank.Length];
            blank.Read(temp, 0, (int)blank.Length);
            blank.Close();
            MemoryStream memoryStream = new MemoryStream(temp);
            AssetBundle.LoadFromMemory(memoryStream.ToArray());
            SceneManager.LoadScene("BlankScene");

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