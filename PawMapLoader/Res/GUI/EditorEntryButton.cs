namespace PawMapLoader.Res.GUI
{
    using System;
    using RKXBOX_Unity_OSS;
    using UnityEngine;
    using UnityEngine.SceneManagement;
    using UnityEngine.UI;

    public class EditorEntryButton
    {
        public static void Register()
        {
            Store.InitScnevnt += (i, s) =>
            {
                if (s == "MainMenu") MainMenuButton(i);
            };
        }

        public static void MainMenuButton(int sceneBuildIndex)
        {
            GameObject cbutton = SceneManager.GetSceneByBuildIndex(sceneBuildIndex).GetRootGameObjects()[19]?
                .transform.GetChild(3).GetChild(0).GetChild(2).GetChild(4).gameObject;
            SceneManager.GetSceneByBuildIndex(sceneBuildIndex).GetRootGameObjects()[19]
                .transform.GetChild(5).gameObject.GetComponent<Text>().text = VersionString.PMLVersion;

            _ = cbutton != null ? true : throw new NullReferenceException("Credits Button Missing");
            Button btn = cbutton.GetComponent<Button>();
            btn.onClick = new Button.ButtonClickedEvent();
            btn.onClick.AddListener((Action)(() => { main.Entry(); }));
            Text txt = cbutton.GetComponent<Text>();
            txt.text = Strings.GetString("EditorButton");
        }
    }
}