using UnityEngine;

namespace Parts
{
    public class Part : MonoBehaviour
    {
        [SerializeField] private GameObject _bodyFront;

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