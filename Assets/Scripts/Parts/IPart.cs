using UnityEngine;

namespace Parts
{
    public interface IPart
    {
        Vector2 SetLocalRotation { set; }
        void SetVisibilityBodyFront(bool isVisible);
        void ResetRotation();
    }
}