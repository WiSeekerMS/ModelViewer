using UnityEngine;

namespace Parts
{
    public interface IModel
    {
        string GetLocalizedDescription { get; }
        Vector2 SetLocalRotation { set; }
        void SetVisibilityBodyFront(bool isVisible);
        void ResetRotation();
        void MakeAnOutline(GameObject obj);
        string GetPartLocalizedText(GameObject obj);
    }
}