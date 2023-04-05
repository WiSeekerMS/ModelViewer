using UnityEngine;

namespace InteractiveObject.Interfaces
{
    public interface IObjectLocalization
    {
        string GetLocalizedName { get; }
        string GetLocalizedDescription { get; }
        string GetPartLocalizedText(GameObject obj);
    }
}