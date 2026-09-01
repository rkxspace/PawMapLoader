namespace PawMapLoader.Res.RKXBOX_Unity_OSS.Res.UI
{
    using UnityEngine;
    using UnityEngine.Rendering;

    public class GLHelper
    {
        private static Material _gizmoMaterial;
        private static Material _highlightMaterial;

        public static void GLInit()
        {
            if (_gizmoMaterial == null)
            {
                Shader shdr = Shader.Find("Hidden/Internal-Colored");
                _gizmoMaterial = new Material(shdr);
                _gizmoMaterial.shader = shdr;
                //_colourMaterial.hideFlags = HideFlags.HideAndDontSave;
                _gizmoMaterial.SetInt("_SrcBlend", (int)BlendMode.SrcAlpha);
                _gizmoMaterial.SetInt("_DstBlend", (int)BlendMode.OneMinusSrcAlpha);
                _gizmoMaterial.SetInt("_Cull", (int)CullMode.Off);
                _gizmoMaterial.SetInt("_ZWrite", 0);
                shdr = Shader.Find("Hidden/Internal-Colored");
                _highlightMaterial = new Material(shdr);
                _highlightMaterial.shader = shdr;
                //_colourMaterial.hideFlags = HideFlags.HideAndDontSave;
                _highlightMaterial.SetInt("_SrcBlend", (int)BlendMode.SrcAlpha);
                _highlightMaterial.SetInt("_DstBlend", (int)BlendMode.OneMinusSrcAlpha);
                _highlightMaterial.SetInt("_Cull", (int)CullMode.Off);
                _highlightMaterial.SetInt("_ZWrite", 0);
            }
        }


        public static void Render(Transform transform, bool isHover)
        {
            if (transform == null) return;
            GLInit();

            GL.PushMatrix();
            GL.Viewport(EditorCameras.camera.pixelRect);
            GL.LoadProjectionMatrix(EditorCameras.camera.projectionMatrix);
            GL.modelview = EditorCameras.camera.worldToCameraMatrix * transform.localToWorldMatrix;
            _gizmoMaterial.SetPass(0);


            if (isHover)
            {
                GL.Begin(GL.LINES);
                Mesh mesh = transform.GetComponent<MeshFilter>().sharedMesh;
                GL.Color(new Color(.8f, .1f, .4f, 1f));
                Vector3[] vertices = mesh.vertices;
                int[] triangles = mesh.triangles;
                for (int i = 0; i < triangles.Length; i++)
                {
                    Vector3 vert = vertices[triangles[i]];
                    GL.Vertex3(vert.x, vert.y, vert.z);
                }

                GL.End();
            }

            GL.Begin(GL.LINES);

            GL.Color(new Color(1, 0, 0));
            GL.Vertex3(-1, 0, 0);
            GL.Vertex3(1, 0, 0);

            GL.Color(new Color(0, 1, 0));
            GL.Vertex3(0, -1, 0);
            GL.Vertex3(0, 1, 0);

            GL.Color(new Color(0, 0, 1));
            GL.Vertex3(0, 0, -1);
            GL.Vertex3(0, 0, 1);

            GL.End();
            GL.PopMatrix();
        }
    }
}