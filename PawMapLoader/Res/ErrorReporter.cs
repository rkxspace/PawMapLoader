using System.Net;
using Il2CppSystem;
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
        public static string collectionServer = "https://errorcollection.xilenth.space/error";
        
        public static void ReportIl2CppException(Exception ex)
        {
            var wc = new WebClient();
            wc.Headers.Add("user-agent", "Mozilla/5.0");
            wc.UploadString(new Uri(collectionServer), $"{{\"error\": \"[IL2CPP]: {ex.Message}\", \"stacktrace\": \"{ex.StackTrace}\"}}");
        }

        public static void Report(System.Exception ex)
        {
            var wc = new WebClient();
            wc.Headers.Add("user-agent", "Mozilla/5.0");
            wc.UploadString(new Uri(collectionServer), $"{{\"error\": \"{ex.Message}\", \"stacktrace\": \"{ex.StackTrace}\"}}");
        }
    }
}