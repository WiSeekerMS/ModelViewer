using UnityEngine;

namespace InteractiveObject.Interfaces
{
    public interface IObjectTransform
    {
        Vector2 SetLocalRotation { set; }
        void ResetRotation();
    }
}