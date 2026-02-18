using Newtonsoft.Json;

namespace PawMapLoader.Res.Json
{
    public class MapJson
    {
        public static void Read()
        {
            Store.Maps = JsonConvert.DeserializeObject<MapList>(PawMapLoader.Res.FileManagement.ReturnMapsJson());
        }
    }
}