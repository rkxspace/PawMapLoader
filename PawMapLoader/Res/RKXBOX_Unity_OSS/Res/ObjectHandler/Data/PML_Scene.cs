namespace PawMapLoader.Res.RKXBOX_Unity_OSS.Res.ObjectHandler.Data
{
    using System.Collections.Generic;
    using UnityEngine;

    public class PML_Scene
    {
        public static PML_Scene Instance;
        public Dictionary<string, SceneObj> sceneData = new Dictionary<string, SceneObj>();

        public PML_Scene() => Instance = this;

        public void AddGameObject(GameObject gameObject)
        {
            sceneData.Add(gameObject.name,
                new SceneObj
                {
                    GameObject = gameObject,
                    Renderer = gameObject.GetComponent<Renderer>()
                }
            );
        }
    }
}