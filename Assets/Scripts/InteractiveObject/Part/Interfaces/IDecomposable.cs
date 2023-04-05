using UnityEngine;

namespace InteractiveObject.Part.Interfaces
{
    public interface IDecomposable
    {
        bool IsHideWhenDecomposing { get; }
        Vector3 GetDefaultLocalPosition { get; }
        Quaternion GetDefaultLocalRotate { get; }
        Vector3 GetTargetLocalPosition { get; }
        Quaternion GetTargetLocalRotate { get; }
    }
}