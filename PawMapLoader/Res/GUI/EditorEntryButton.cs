namespace PawMapLoader.Res.GUI
{
    using System;
    using RKXBOX_Unity_OSS;
    using UnityEngine;
    using UnityEngine.UI;

    public class EditorEntryButton
    {
        public static void Register()
        {
            Store.InitScnevnt += (i, s) =>
            {
                if (s == "MainMenu") MainMenuButton();
            };
        }

        public static void MainMenuButton()
        {
            GameObject cbutton = null;
            foreach (Text text in Resources.FindObjectsOfTypeAll<Text>())
            {
                if (text.name == "CreditsButton") cbutton = text.gameObject;
            }
            _ = cbutton == null ? true : throw new NullReferenceException("Credits Button Missing");
            Button btn = cbutton.GetComponent<Button>();
            btn.onClick = new Button.ButtonClickedEvent();
            btn.onClick.AddListener((Action)(() => { main.Entry(); }));
            Text txt = cbutton.GetComponent<Text>();
            txt.text = Strings.GetString("EditorButton");
        }
    }
}