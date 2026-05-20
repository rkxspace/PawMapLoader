using Il2CppInterop.Runtime;
using Il2CppSystem;
using MelonLoader;
using PawMapLoader.Res;
using PawMapLoader.Res.Enum;
using PawMapLoader.Res.Json;
using AppDomain = System.AppDomain;
using Exception = System.Exception;
using IntPtr = System.IntPtr;
using UnhandledExceptionEventHandler = Il2CppSystem.UnhandledExceptionEventHandler;

namespace PawMapLoader
{
    public class Init
    {
        public static void InitMelon()
        {
            try
            {
                Il2CppSystem.AppDomain.CurrentDomain.UnhandledException =
                    (System.Action<Object, UnhandledExceptionEventArgs>)((sender, e) =>
                    {
                        var ex = e.ExceptionObject.Cast<Il2CppSystem.Exception>();
                        ErrorReporter.ReportIl2CppException(ex);
                    }); // Catching Il2Cpp errors, since it is useful in the case the mod breaks something.

                LevelDataProvider.WaitForDataProvider();
            }
            catch (Exception e)
            {
                MelonLogger.Error(
                    "PawMapLoader init failure! This should never happen.", e
                    );
                ErrorReporter.Report(e);
            }
        }

        public static void InitMaps()
        {
            FileManagement.EnsureCustomMapsDirectory();
            MapJson.Read();
            AssetManager.LoadMapData();
        }
    }
}