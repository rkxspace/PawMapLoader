using System.Net;
using Il2CppSystem;
using MelonLoader;
using Newtonsoft.Json;
using PawMapLoader.Res.UserConf;
using Uri = System.Uri;

namespace PawMapLoader.Res
{
    /// <summary>
    /// This is the error reporter.
    /// It reports errors.
    /// This Error Reporter will only ever report:
    /// The error.
    /// The stack trace.
    ///
    /// !!! ANY AND ALL PULL REQUESTS THAT EDIT THIS FILE WILL BE CLOSED !!!
    /// !!! IF THERE ARE CHANGES TO BE MADE HERE, MAKE AN ISSUE.         !!! 
    /// </summary>
    public class ErrorReporter
    {
        public static string collectionServer = "https://pmlerr.xilenth.space/error";
        public static bool enabled => UConf.Properties.ErrorReportingEnabled;

        public static void ReportIl2CppException(Exception ex)
        {
            try
            {
                if (!enabled)
                {
                    MelonLogger.Error($"[Il2Cpp]: {ex.Message}\n{ex.StackTrace}");
                    return;
                }

                WebClient wc = new WebClient();
                wc.Headers.Add("user-agent", "Mozilla/5.0");
                string rqj = JsonConvert.SerializeObject(new
                {
                    error = $"[IL2CPP]: {ex.Message}",
                    stacktrace = ex.StackTrace
                });
                wc.UploadString(new Uri(collectionServer), rqj);
            }
            catch { }
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

                WebClient wc = new WebClient();
                wc.Headers.Add("user-agent", "Mozilla/5.0");
                string rqj = JsonConvert.SerializeObject(new
                {
                    error = ex.Message,
                    stacktrace = ex.StackTrace
                });
                wc.UploadString(new Uri(collectionServer), rqj);
            }
            catch { }
        }
    }
}