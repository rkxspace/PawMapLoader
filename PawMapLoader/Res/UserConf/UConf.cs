using MelonLoader;
using Newtonsoft.Json;
using PawMapLoader.Res.UserConf.Json;

namespace PawMapLoader.Res.UserConf
{
    public class UConf
    {
        public static UserConfigProperties Properties;

        public static void LoadConfig()
        {
            Properties = JsonConvert.DeserializeObject<UserConfigProperties>(FileManagement.GetConfigFile());
        }

        public static void SaveConfig()
        {
            FileManagement.WriteConfigFile(Properties);
        }
    }
}