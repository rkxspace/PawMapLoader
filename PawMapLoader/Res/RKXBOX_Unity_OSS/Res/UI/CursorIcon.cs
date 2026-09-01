namespace PawMapLoader.Res.RKXBOX_Unity_OSS.Res.UI
{
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using UnityEngine;

    public class CursorIcon
    {
        public static Dictionary<string, Texture2D> cursors = new Dictionary<string, Texture2D>();

        public static void LoadCursors()
        {
            Stream tmpStream;
            Texture2D tmp;
            byte[] tmpData;

            tmpStream = Assembly.GetCallingAssembly()
                .GetManifestResourceStream("PawMapLoader.Res.RKXBOX_Unity_OSS.Assets.Cursors." +
                                           "google_icon_videocamera.png");
            tmpData = new byte[tmpStream.Length];
            tmpStream.Read(tmpData, 0, tmpData.Length);
            tmpStream.Close();
            tmp = new Texture2D(24, 24);
            tmp.LoadImage(tmpData);
            cursors.Add("Camera", tmp);
        }
    }
}