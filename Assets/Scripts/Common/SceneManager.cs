using UnityEngine;

namespace Common
{
    public class SceneManager : MonoBehaviour
    {
        [SerializeField] private Camera _playerCamera;
        [SerializeField] private Camera _canvasCamera;

        public Camera PlayerCamera => _playerCamera;
        public Camera CanvasCamera => _canvasCamera;
    }
}