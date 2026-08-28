using PawMapLoader.Res;

namespace PawMapLoader
{
    using Res.GUI;

    public class EarlyInitMelon
    {
        public static void EarlyInit()
        {
            Strings.ValidateLocaleExist();
            NTCheck.WineCheck();
            EditorEntryButton.Register();
        }
    }
}