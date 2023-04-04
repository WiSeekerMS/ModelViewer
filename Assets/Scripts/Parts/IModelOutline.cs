using UnityEngine;

namespace Parts
{
    public interface IModelOutline
    {
        void MakeAnOutline(GameObject obj);
        void ResetOutline();
    }
}