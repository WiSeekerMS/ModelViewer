using UnityEngine;

namespace Parts
{
    public class Part : MonoBehaviour, IPart
    {
        [SerializeField] private GameObject _bodyFront;

        public Vector2 SetLocalRotation
        {
            set => transform.localRotation = Quaternion.Euler(value.x, value.y, 0f);
        }

        public void SetVisibilityBodyFront(bool isVisible)
        {
            _bodyFront.SetActive(isVisible);
        }

        public void ResetRotation()
        {
            transform.rotation = Quaternion.identity;
        }
    }
}