using UnityEngine;

namespace Parts
{
    public interface IModel : IModelTransform, IModelLocalization
    {
        bool Visibility { get; set; }
        void SetVisibilityBodyFront(bool isVisible);
        void MakeAnOutline(GameObject obj);
        void ResetOutline();
    }
}