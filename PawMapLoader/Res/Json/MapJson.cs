using MelonLoader;
using Newtonsoft.Json;

namespace PawMapLoader.Res.Json
{
    public class MapJson
    {
        public static void Read()
        {
            MelonLogger.Msg("Deserializing map json...");
            Store.Maps = JsonConvert.DeserializeObject<MapList>(FileManagement.ReturnMapsJson());
        }
    }
}