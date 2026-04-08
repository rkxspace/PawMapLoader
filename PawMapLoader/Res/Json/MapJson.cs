using Newtonsoft.Json;

namespace PawMapLoader.Res.Json
{
    public class MapJson
    {
        public static void Read()
        {
            Store.Maps = JsonConvert.DeserializeObject<MapList>(FileManagement.ReturnMapsJson());
        }
    }
}