namespace PawMapLoader.Res.RKXBOX_Unity_OSS.Res.ObjectHandler
{
    using Data;
    using UnityEngine;

    public class BasePlane
    {
        public static void CreatePlane()
        {
            GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
            Material planeMaterial = plane.GetComponent<Renderer>().material;
            planeMaterial.shader = Shader.Find("Universal Render Pipeline/Lit");
            PML_Scene.Instance.sceneData.Add("plane", new SceneObj { GameObject = plane });
        }
    }
}