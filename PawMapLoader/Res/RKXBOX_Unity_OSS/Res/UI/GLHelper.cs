namespace PawMapLoader.Res.RKXBOX_Unity_OSS.Res.UI
{
    public class GLHelper
    {
        private static UnityEngine.Shader _colourMaterial;

        public static void GLInit()
        {
            if (_colourMaterial == null)
            {
                _colourMaterial = UnityEngine.Shader.Find("Hidden/InternalErrorShader");
            }
        }

        public static void Render()
        {
            
        }
    }
}