namespace PawMapLoader.Res.RKXBOX_Unity_OSS.Res.Components
{
    using System;
    using MelonLoader;
    using UI;
    using UnityEngine;
    using UnityEngine.Rendering;
    using ViewPortControls;

    [RegisterTypeInIl2Cpp]
    public class PostRenderHelper : MonoBehaviour
    {
        private Action<ScriptableRenderContext, Camera> Callback = (s, d) =>
        {
            try
            {
                if (EditorStates.instance.selectedGameObject != null)
                    GLHelper.Render(EditorStates.instance.selectedGameObject.transform, false);
                GameObject gohover = MouseTools.HoveredGameObject;
                if (MouseTools.HoveredViewPort && gohover != null &&
                    gohover != EditorStates.instance.selectedGameObject)
                    GLHelper.Render(gohover.transform, true);
            }
            catch (Exception)
            {
                // ignored
            }
        };

        public PostRenderHelper(IntPtr ptr) : base(ptr) { }

        private void Awake()
        {
            RenderPipelineManager.endCameraRendering += Callback;
        }

        private void OnDestroy()
        {
            RenderPipelineManager.endCameraRendering -= Callback;
        }
    }
}