namespace PawMapLoader.Res.RKXBOX_Unity_OSS.Res.Components
{
    using System;
    using MelonLoader;
    using UI;
    using UnityEngine;
    using UnityEngine.Rendering;

    [RegisterTypeInIl2Cpp]
    public class PostRenderHelper : MonoBehaviour
    {
        private Action<ScriptableRenderContext, Camera> Callback = (s, d) =>
        {
            if (EditorStates.instance.selectedGameObject == null) return;
            GLHelper.Render(EditorStates.instance.selectedGameObject.transform);
        };

        public PostRenderHelper(IntPtr ptr) : base(ptr) { }

        void OnEnable()
        {
            RenderPipelineManager.endCameraRendering += Callback;
        }

        void OnDisable()
        {
            RenderPipelineManager.endCameraRendering -= Callback;
        }
    }
}