namespace PawMapLoader.Res.Components
{
    using MelonLoader;
    using UnityEngine;

    [RegisterTypeInIl2Cpp]
    public class TransformCopy : MonoBehaviour
    {
        // yippee constraints without the bullshit
        public bool Copy;
        public Transform CopyFrom;

        public bool CopyPosition;
        public Vector3 PositionOffset = Vector3.zero;
        public bool CopyRotation;
        public Vector3 RotationOffset = Vector3.zero;
        public bool CopyScale;
        public Vector3 ScaleOffset = Vector3.zero;

        public void Update()
        {
            if (Copy)
            {
                if (CopyPosition) transform.position = CopyFrom.position + PositionOffset;
                if (CopyRotation) transform.rotation = Quaternion.Euler(CopyFrom.rotation.eulerAngles + RotationOffset);
                if (CopyScale) transform.localScale = CopyFrom.localScale + ScaleOffset;
            }
        }
    }
}