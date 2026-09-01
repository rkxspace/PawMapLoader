namespace PawMapLoader.Res.RKXBOX_Unity_OSS.Res.ObjectHandler
{
    using Data;
    using Il2CppUniGLTF;
    using UnityEngine;

    public class CreateObject
    {
        public static void CreatePrimitive(
            PrimitiveType primitiveType,
            string name,
            Vector3 localPosition,
            Vector3 localRotation,
            GameObject parent = null)
        {
            GameObject go = GameObject.CreatePrimitive(primitiveType);
            go.name = name;
            if (parent) go.transform.SetParent(parent.transform, false);
            go.transform.localPosition = localPosition;
            go.transform.localRotation = Quaternion.Euler(localRotation);
            PML_Scene.Instance.sceneData.Add(
                EditorStates.instance.getGuid.ToString(),
                new SceneObj
                {
                    GameObject = go,
                    Renderer = go.GetComponent<Renderer>()
                }
            );
        }

        public static void CreateFromGLTF(
            string gltfFilePath,
            string name,
            Vector3 localPosition,
            Vector3 localRotation,
            GameObject parent = null)
        {
            if (gltfFilePath.EndsWith(".glb"))
            {
                GlbFileParser dt = new GlbFileParser(gltfFilePath);
                ImporterContext importerContext = new ImporterContext(dt.Parse());
                RuntimeGltfInstance rtgltf = importerContext.Load();
                rtgltf.ShowMeshes();

                GameObject go = rtgltf.Root;
            }
        }
    }
}