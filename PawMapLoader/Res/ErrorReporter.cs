using System.Net;
using Il2CppSystem;
using MelonLoader;
using Newtonsoft.Json;
using Uri = System.Uri;

namespace PawMapLoader.Res
{
    /// <summary>
    /// This is the error reporter.
    /// It reports errors.
    /// This Error Reporter will only ever report:
    /// The error.
    /// The stack trace.
    /// </summary>
    public class ErrorReporter
    {
        public static bool enabled = true;
        public static string collectionServer = "https://errorcollection.xilenth.space/error";
        
        public static void ReportIl2CppException(Exception ex)
        {
            try
            {
                if (!enabled)
                {
                    MelonLogger.Error($"[Il2Cpp]: {ex.Message}\n{ex.StackTrace}");
                    return;
                }

                var wc = new WebClient();
                wc.Headers.Add("user-agent", "Mozilla/5.0");
                var rqj = JsonConvert.SerializeObject(new
                {
                    error = $"[IL2CPP]: {ex.Message}",
                    stacktrace = ex.StackTrace
                });
                wc.UploadString(new Uri(collectionServer), rqj);
            } catch {}
        }

        public static void Report(System.Exception ex)
        {
            try
            {
                if (!enabled)
                {
                    MelonLogger.Error($"{ex.Message}\n{ex.StackTrace}");
                    return;
                }

                var wc = new WebClient();
                wc.Headers.Add("user-agent", "Mozilla/5.0");
                var rqj = JsonConvert.SerializeObject(new
                {
                    error = ex.Message,
                    stacktrace = ex.StackTrace
                });
                wc.UploadString(new Uri(collectionServer), rqj);
            } catch {}
        }
    }
}