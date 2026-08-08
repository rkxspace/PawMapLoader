using Il2CppSystem;
using MelonLoader;
using PawMapLoader.Res;
using PawMapLoader.Res.Enum;
using PawMapLoader.Res.Json;
using PawMapLoader.Res.UserConf;
using Exception = System.Exception;

namespace PawMapLoader
{
    public class Init
    {
        public static void InitMelon()
        {
            try
            {
                FileManagement.EnsureConfigDirectory();
                UConf.LoadConfig();
                AppDomain.CurrentDomain.UnhandledException =
                    (System.Action<Object, UnhandledExceptionEventArgs>)((sender, e) =>
                    {
                        Il2CppSystem.Exception ex = e.ExceptionObject.Cast<Il2CppSystem.Exception>();
                        ErrorReporter.ReportIl2CppException(ex);
                    }); // Catching Il2Cpp errors, since it is useful in the case the mod breaks something.

                LevelDataProvider.WaitForDataProvider();
            }
            catch (Exception e)
            {
                MelonLogger.BigError(
                    "PawMapLoader init failure!",
                    $"Something went horribly wrong in init! This should never happen.\nError:{e}\nStackTrace:\n{e.StackTrace}"
                );
                ErrorReporter.Report(e);
            }
        }

        public static void InitMaps()
        {
            UpdateRegisters.Register();
            FileManagement.EnsureCustomMapsDirectory();
            MapJson.Read();
            AssetManager.LoadMapData();
        }
    }
}