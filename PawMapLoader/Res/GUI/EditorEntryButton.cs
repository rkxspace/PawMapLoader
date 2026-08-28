namespace PawMapLoader.Res.GUI
{
    using System;
    using Enum;
    using Il2CppGame;
    using Il2CppInterop.Runtime.InteropTypes.Arrays;
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
                if (s == "MainMenu") MenuPersistent.Rescanner();
            };
        }

        public static bool MainMenuButton()
        {
            try
            {
                Il2CppArrayBase<TextMeshProUGUI> tmpguil = Resources.FindObjectsOfTypeAll<TextMeshProUGUI>();
                TextMeshProUGUI edtb = null;
                GameVersionView text;
                foreach (TextMeshProUGUI go in tmpguil)
                {
                    if (go.gameObject.transform.parent.gameObject.name == "CreditsButton") edtb = go;
                }

                if (edtb == null) return false;
                edtb.text = Strings.GetString("EditorButton");
                Button btn = edtb.gameObject.GetComponent<Button>();
                btn.onClick = new Button.ButtonClickedEvent();
                btn.onClick.AddListener((Action)(() => { main.Entry(); }));
                text = Resources.FindObjectsOfTypeAll<GameVersionView>()[0];
                edtb = text.gameObject.GetComponent<TextMeshProUGUI>();
                edtb.text = VersionString.PMLVersion;
                return true;
            }
            catch (Exception e)
            {
                MelonLogger.Error(e);
                return false;
            }
        }
    }
}