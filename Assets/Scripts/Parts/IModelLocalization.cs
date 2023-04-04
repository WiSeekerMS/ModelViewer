using UnityEngine;

namespace Parts
{
    public interface IModelLocalization
    {
        string GetLocalizedName { get; }
        string GetLocalizedDescription { get; }
        string GetPartLocalizedText(GameObject obj);
    }
}