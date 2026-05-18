using Il2CppInterop.Runtime;
using Il2CppSystem;
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
            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
                ErrorReporter.Report(e.ExceptionObject as Exception);
            IntPtr ptr = IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<UnhandledExceptionEventHandler>.NativeClassPtr);
            var ilue = new UnhandledExceptionEventHandler(ptr);
            Il2CppSystem.AppDomain.CurrentDomain.UnhandledException = (System.Action<Object, UnhandledExceptionEventArgs>)((sender, e) =>
            {
                var ex = e.ExceptionObject.Cast<Il2CppSystem.Exception>();
                ErrorReporter.ReportIl2CppException(ex);
            });
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