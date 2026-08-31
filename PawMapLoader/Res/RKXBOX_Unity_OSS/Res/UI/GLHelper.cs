namespace PawMapLoader.Res.RKXBOX_Unity_OSS.Res.UI
{
    using UnityEngine;
    using UnityEngine.Rendering;

    public class GLHelper
    {
        private static Material _colourMaterial;

        public static void GLInit()
        {
            if (_colourMaterial == null)
            {
                Shader shdr = Shader.Find("Hidden/Internal-Colored");
                _colourMaterial = new Material(shdr);
                _colourMaterial.shader = shdr;
                _colourMaterial.hideFlags = HideFlags.HideAndDontSave;
                _colourMaterial.SetInt("_SrcBlend", (int)BlendMode.One);
                _colourMaterial.SetInt("_DstBlend", (int)BlendMode.One);
                _colourMaterial.SetInt("_Cull", (int)CullMode.Off);
                _colourMaterial.SetInt("_ZWrite", 1);
            }
        }

        public static void Render(Transform transform)
        {
            GLInit();

            GL.PushMatrix();
            GL.Viewport(EditorCameras.camera.rect);
            GL.LoadProjectionMatrix(EditorCameras.camera.projectionMatrix);
            GL.MultMatrix(transform.localToWorldMatrix);
            _colourMaterial.SetPass(0);
            GL.Begin(GL.LINES);

            GL.Color(new Color(0.7f, 0, 0));
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(1, 0, 0);

            GL.Color(new Color(0, 0.7f, 0));
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, 1, 0);

            GL.Color(new Color(0, 0, 0.7f));
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, 0, 1);

            GL.End();
            GL.PopMatrix();
        }
    }
}