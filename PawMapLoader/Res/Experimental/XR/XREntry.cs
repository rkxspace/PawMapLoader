namespace PawMapLoader.Res.Experimental.XR
{
    public class XREntry
    {
        public static XRRuntime XRi;

        public static void Entry()
        {
            XRi = new XRRuntime();
        }

        public static void Update() { }
    }
}