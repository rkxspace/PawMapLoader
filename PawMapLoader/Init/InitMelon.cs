using PawMapLoader.Res;
using PawMapLoader.Res.Enum;
using PawMapLoader.Res.Json;

namespace PawMapLoader
{
    public class Init
    {
        public static void InitMelon()
        {
            LevelDataProvider.WaitForDataProvider();
        }

        public static void InitMaps()
        {
            FileManagement.EnsureCustomMapsDirectory();
            MapJson.Read();
            AssetManager.LoadMapData();
        }
    }
}