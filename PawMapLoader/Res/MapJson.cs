using System.IO;
using Newtonsoft.Json;

namespace PawMapLoader.Res
{
    public class MapJson
    {
        public static MapList Maps;

        public static void Read()
        {
            Maps = JsonConvert.DeserializeObject<MapList>(PawMapLoader.Res.FileManagement.ReturnMapsJson());
        }
    }
}