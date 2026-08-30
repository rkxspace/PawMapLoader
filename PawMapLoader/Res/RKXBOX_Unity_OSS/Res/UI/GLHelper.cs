namespace PawMapLoader.Res.RKXBOX_Unity_OSS.Res.UI
{
    using UnityEngine;

    public class GLHelper
    {
        private static Material _colourMaterial;

        public static void GLInit()
        {
            if (_colourMaterial == null)
            {
                Shader shdr = Shader.Find("Hidden/Internal-Colored");
                _colourMaterial = new Material(shdr);
                _colourMaterial.hideFlags = HideFlags.HideAndDontSave;
                _colourMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                _colourMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.One);
                _colourMaterial.SetInt("_Cull", (int)UnityEngine.Rendering.CullMode.Off);
                _colourMaterial.SetInt("_ZWrite", 0);
                _colourMaterial.SetPass(0);
            }
        }

        public static void Render(Transform transform)
        {
            GLInit();
            
            GL.PushMatrix();
            GL.MultMatrix(transform.localToWorldMatrix);
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