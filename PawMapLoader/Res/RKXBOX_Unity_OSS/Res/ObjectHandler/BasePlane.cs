namespace PawMapLoader.Res.RKXBOX_Unity_OSS.Res.ObjectHandler
{
    using UnityEngine;

    public class BasePlane
    {
        public static void CreatePlane()
        {
            GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
            Material planeMaterial = plane.GetComponent<Renderer>().material;
            planeMaterial.shader = Shader.Find("Universal Render Pipeline/Lit");
        }
    }
}