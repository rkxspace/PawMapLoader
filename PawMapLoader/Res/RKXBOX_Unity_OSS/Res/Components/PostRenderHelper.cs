namespace PawMapLoader.Res.RKXBOX_Unity_OSS.Res.Components
{
    using MelonLoader;
    using UI;
    using UnityEngine;

    [RegisterTypeInIl2Cpp]
    public class PostRenderHelper : MonoBehaviour
    {
        void OnPostRender()
        {
            if (EditorStates.instance.selectedGameObject == null) return;
            GLHelper.Render(EditorStates.instance.selectedGameObject.transform);
        }
    }
}