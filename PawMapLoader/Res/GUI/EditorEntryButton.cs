namespace PawMapLoader.Res.GUI
{
    using System;
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
                if (s == "MainMenu") Res.Enum.MenuPersistent.Rescanner();
            };
        }

        public static bool MainMenuButton()
        {
            try
            {
                Il2CppArrayBase<TextMeshProUGUI> tmpguil = Resources.FindObjectsOfTypeAll<TextMeshProUGUI>();
                TextMeshProUGUI edtb = null;
                TextMeshProUGUI text = null;
                foreach (TextMeshProUGUI go in tmpguil)
                {
                    if (go.gameObject.name == "CreditsButton") edtb = go;
                    if (go.gameObject.name == "Version View") text = go;
                }

                if (edtb == null) return false;
                edtb.gameObject.name = Strings.GetString("EditorButton");
                Button btn = edtb.gameObject.GetComponent<Button>();
                btn.onClick = new Button.ButtonClickedEvent();
                btn.onClick.AddListener((Action)(() => { main.Entry(); }));
                if (text == null) return false;
                text.text = VersionString.PMLVersion;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}