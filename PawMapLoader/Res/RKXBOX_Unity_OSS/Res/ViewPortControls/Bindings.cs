namespace PawMapLoader.Res.RKXBOX_Unity_OSS.Res.ViewPortControls
{
    using UnityEngine;
    using UnityEngine.InputSystem;

    public class Bindings
    {
        private static Vector2 _lastFrameMousePos = Vector2.zero;

        public static void MouseSelect()
        {
            // Unity on proton likes to lock the cursor into the window for some odd reason.
            // This should fix it... I hope... it's kinda needed for an editor.
            Cursor.lockState = EditorStates.instance.cursorLockMode;
            Cursor.visible = true;


            if (Mouse.current.leftButton.wasPressedThisFrame)
                MouseTools.StartPos = MouseTools.NrmlMousePos;

            if (Mouse.current.rightButton.wasPressedThisFrame)
            {
                EditorStates.instance.cursorLockMode = CursorLockMode.Confined;
                MouseTools.StartPos = MouseTools.NrmlMousePos;
                _lastFrameMousePos = MouseTools.NrmlMousePos;
                MouseTools.RotationDelta = Vector2.zero;
                EditorCameras.OriginalRot = EditorCameras.camera.transform.eulerAngles;
            }


            if (Mouse.current.leftButton.wasReleasedThisFrame && MouseTools.dragDistance < 0.02f)
                EditorStates.instance.selectedGameObject = MouseTools.GetHoveredGameObject();

            if (Mouse.current.rightButton.isPressed && MouseTools.dragDistance > 0.02f && EditorCameras.camera.rect
                    .Contains(MouseTools.NrmlMousePos)
                && !Mouse.current.leftButton.isPressed)
            {
                if (Keyboard.current.wKey.isPressed)
                {
                    EditorCameras.camera.transform.position += EditorCameras.camera.transform.forward * Time
                        .deltaTime * 100;
                }

                if (Keyboard.current.sKey.isPressed)
                {
                    EditorCameras.camera.transform.position += -1 * EditorCameras.camera.transform.forward * Time
                        .deltaTime * 100;
                }

                if (Keyboard.current.aKey.isPressed)
                {
                    EditorCameras.camera.transform.position += -1 * EditorCameras.camera.transform.right * Time
                        .deltaTime * 100;
                }

                if (Keyboard.current.dKey.isPressed)
                {
                    EditorCameras.camera.transform.position += EditorCameras.camera.transform.right * Time
                        .deltaTime * 100;
                }


                MouseTools.RotationDelta += 100 * (_lastFrameMousePos - MouseTools.NrmlMousePos);
                EditorCameras.camera.transform.rotation =
                    Quaternion.Euler(EditorCameras.OriginalRot.x + -1 * MouseTools.RotationDelta.y,
                        EditorCameras.OriginalRot.y + MouseTools.RotationDelta.x, 0);

                Vector2 motionEstimate = MouseTools.NrmlMousePos + (_lastFrameMousePos - MouseTools.NrmlMousePos);
                if (!EditorCameras.camera.rect.Contains(motionEstimate))
                {
                    Vector2 estimateScaled = MouseTools.FullScreenToScaledPos(motionEstimate);
                    Vector2 newPosition = estimateScaled;
                    if (estimateScaled.x < 0) newPosition.x = estimateScaled.x + 1;
                    if (estimateScaled.x > 1) newPosition.x = estimateScaled.x - 1;
                    if (estimateScaled.y < 0) newPosition.y = estimateScaled.y + 1;
                    if (estimateScaled.y > 1) newPosition.y = estimateScaled.y - 1;
                    Mouse.current.WarpCursorPosition(MouseTools.ScaledPosToFullScreen(newPosition));
                }
                else _lastFrameMousePos = MouseTools.NrmlMousePos;
            }
            else if (Mouse.current.rightButton.wasReleasedThisFrame)
            {
                EditorStates.instance.cursorLockMode = CursorLockMode.None;
                EditorCameras.OriginalRot = EditorCameras.camera.transform.eulerAngles;
            }
        }
    }
}