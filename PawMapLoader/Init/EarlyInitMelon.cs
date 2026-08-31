namespace PawMapLoader
{
    using MelonLoader;
    using Res;
    using Res.GUI;
    using UnityEngine.Rendering;

    public class EarlyInitMelon
    {
        public static void EarlyInit()
        {
            PreSupport.PSup();
            Store.InitScnevnt += (i, a) => { MelonLogger.Msg($"TESTING: {a}, {i}"); };

            MelonLogger.Msg($"MDN: {SplashScreen.BeginDelegateField.Method.GetType().FullName}" +
                            $" {SplashScreen.BeginDelegateField.Method.Name}");
            Strings.ValidateLocaleExist();
            NTCheck.WineCheck();
            EditorEntryButton.Register();
        }
    }
}