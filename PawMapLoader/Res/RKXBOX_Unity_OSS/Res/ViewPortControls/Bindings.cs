namespace PawMapLoader.Res.RKXBOX_Unity_OSS.Res.ViewPortControls
{
    using UI;
    using UnityEngine;
    using UnityEngine.InputSystem;

    public class Bindings
    {
        private static Vector2 _lastFrameMousePos = Vector2.zero;
        private static bool IsViewportDragging = false;

        public static void MouseSelect()
        {
            Clock.UpdateClocks();

            // Unity on proton likes to lock the cursor into the window for some odd reason.
            // This should fix it... I hope... it's kinda needed for an editor.
            Cursor.lockState = EditorStates.instance.cursorLockMode;
            Cursor.visible = true;


            if (Mouse.current.leftButton.wasPressedThisFrame)
                MouseTools.StartPos = MouseTools.NrmlMousePos;

            if (Mouse.current.rightButton.wasPressedThisFrame && EditorCameras.camera.rect
                    .Contains(MouseTools.NrmlMousePos))
            {
                EditorStates.instance.cursorLockMode = CursorLockMode.Confined;
                MouseTools.StartPos = MouseTools.NrmlMousePos;
                _lastFrameMousePos = MouseTools.NrmlMousePos;
                MouseTools.RotationDelta = Vector2.zero;
                EditorCameras.OriginalRot = EditorCameras.camera.transform.eulerAngles;
                Cursor.SetCursor(CursorIcon.cursors["Camera"], Vector2.one / 2, CursorMode.Auto);
                IsViewportDragging = true;
            }


            if (Mouse.current.leftButton.wasReleasedThisFrame && MouseTools.dragDistance < 0.02f &&
                MouseTools.HoveredViewPort)
                EditorStates.instance.selectedGameObject = MouseTools.GetHoveredGameObject();

            if (Mouse.current.rightButton.isPressed && MouseTools.dragDistance > 0.02f && IsViewportDragging
                && !Mouse.current.leftButton.isPressed)
            {
                if (Keyboard.current.wKey.isPressed)
                {
                    EditorCameras.camera.transform.position += EditorCameras.camera.transform.forward * Time
                        .deltaTime * 20;
                }

                if (Keyboard.current.sKey.isPressed)
                {
                    EditorCameras.camera.transform.position += -1 * EditorCameras.camera.transform.forward * Time
                        .deltaTime * 20;
                }

                if (Keyboard.current.aKey.isPressed)
                {
                    EditorCameras.camera.transform.position += -1 * EditorCameras.camera.transform.right * Time
                        .deltaTime * 20;
                }

                if (Keyboard.current.dKey.isPressed)
                {
                    EditorCameras.camera.transform.position += EditorCameras.camera.transform.right * Time
                        .deltaTime * 20;
                }


                MouseTools.RotationDelta += 100 * (_lastFrameMousePos - MouseTools.NrmlMousePos);
                EditorCameras.camera.transform.rotation =
                    Quaternion.Euler(EditorCameras.OriginalRot.x + MouseTools.RotationDelta.y,
                        EditorCameras.OriginalRot.y + -1 * MouseTools.RotationDelta.x, 0);

                Vector2 motionEstimate = MouseTools.NrmlMousePos - (_lastFrameMousePos - MouseTools.NrmlMousePos);
                if (!EditorCameras.camera.rect.Contains(motionEstimate) ||
                    !EditorCameras.camera.rect.Contains(MouseTools.NrmlMousePos))
                {
                    Vector2 estimateScaled = MouseTools.FullScreenToScaledPos(motionEstimate);
                    Vector2 newPosition = estimateScaled;
                    if (estimateScaled.x < 0.05)
                        newPosition.x = estimateScaled.x + 1;
                    if (estimateScaled.x > 0.95)
                        newPosition.x = estimateScaled.x - 1;
                    if (estimateScaled.y < 0.05)
                        newPosition.y = estimateScaled.y + 1;
                    if (estimateScaled.y > 0.95)
                        newPosition.y = estimateScaled.y - 1;
                    newPosition.x = Mathf.Clamp(newPosition.x, 0, 1);
                    newPosition.y = Mathf.Clamp(newPosition.y, 0, 1);
                    _lastFrameMousePos = MouseTools.ScaledPosToFullScreen(newPosition);
                    Mouse.current.WarpCursorPosition(
                        MouseTools.NrmlMousePosToAbsolute(MouseTools.ScaledPosToFullScreen(newPosition))
                    );
                }
                else _lastFrameMousePos = MouseTools.NrmlMousePos;
            }
            else if (Mouse.current.rightButton.wasReleasedThisFrame)
            {
                EditorStates.instance.cursorLockMode = CursorLockMode.None;
                EditorCameras.OriginalRot = EditorCameras.camera.transform.eulerAngles;
                IsViewportDragging = false;
                Cursor.SetCursor(null, CursorMode.Auto);
            }
        }
    }
}