namespace PawMapLoader.Res.GUI
{
    using System;
    using Il2CppTMPro;
    using MelonLoader;
    using RKXBOX_Unity_OSS;
    using UnityEngine;
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
            foreach (TextMeshProUGUI go in Resources.FindObjectsOfTypeAll<TextMeshProUGUI>())
            {
                MelonLogger.Msg($"[DEBUG] OBJ_SRCH: {go.gameObject.name} ({go.gameObject.scene.name})");
                if (go.gameObject.name == "CreditsButton")
                {
                    go.gameObject.name = Strings.GetString("EditorButton");
                    Button btn = go.gameObject.GetComponent<Button>();
                    btn.onClick = new Button.ButtonClickedEvent();
                    btn.onClick.AddListener((Action)(() => { main.Entry(); }));
                }
                if (go.gameObject.name == "Version View") go.text = VersionString.PMLVersion;
            }
        }
    }
}