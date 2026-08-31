namespace PawMapLoader.Res.RKXBOX_Unity_OSS.Res.ObjectHandler.Data
{
    using UnityEngine;

    public class SceneObjHighlight
    {
        public delegate void MaterialSet();

        public static MaterialSet OnMaterialSet = () => { };
        private static Material _HighlightMaterial;

        public GameObject HighlightObject;

        public SceneObjHighlight(GameObject sourceObject)
        {
            OnMaterialSet += () => HighlightObject.GetComponent<Renderer>().material = _HighlightMaterial;
        }

        public bool Show => HighlightObject.active;
    }
}