namespace PawMapLoader.Res.RKXBOX_Unity_OSS.Res.Components
{
    using System;
    using MelonLoader;
    using UI;
    using UnityEngine;

    [RegisterTypeInIl2Cpp]
    public class PostRenderHelper : MonoBehaviour
    {
        public PostRenderHelper(IntPtr ptr) : base(ptr) { }

        void OnEnable()
        {
            Camera.onPostRender += (Action<Camera>)(s =>
            {
                if (EditorStates.instance.selectedGameObject == null) return;
                GLHelper.Render(EditorStates.instance.selectedGameObject.transform);
            });
        }
    }
}