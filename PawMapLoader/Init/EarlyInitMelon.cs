using PawMapLoader.Res;

namespace PawMapLoader
{
    public class EarlyInitMelon
    {
        public static void EarlyInit()
        {
            Strings.ValidateLocaleExist();
            NTCheck.WineCheck();
        }
    }
}