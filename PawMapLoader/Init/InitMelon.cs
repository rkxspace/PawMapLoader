using System.IO;
using MelonLoader.Utils;

namespace PawMapLoader
{
    public class Init
    {
        public static void InitMelon()
        {
            Enum.LevelDataProvider.WaitForDataProvider();
        }

        public static void InitMaps()
        {
            Res.FileManagement.EnsureCustomMapsDirectory();
            Res.MapJson.Read();
            Res.AssetManager.LoadAssetBundles();
        }
    }
}