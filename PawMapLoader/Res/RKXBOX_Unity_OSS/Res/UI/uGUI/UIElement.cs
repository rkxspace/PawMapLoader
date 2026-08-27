namespace PawMapLoader.Res.RKXBOX_Unity_OSS.Res.UI.uGUI
{
    using UnityEngine;

    public abstract class UIElement
    {
        public void SetUI(GameObject UIElement)
        {
            UIElement.layer = LayerMask.NameToLayer("UI");
        } 
    }
}