using UnityEngine;

namespace Parts
{
    public interface IModelTransform
    {
        Vector2 SetLocalRotation { set; }
        void ResetRotation();
    }
}