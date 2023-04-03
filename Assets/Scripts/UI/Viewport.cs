using Common;
using UnityEngine;
using Zenject;

namespace UI
{
    public class Viewport : MonoBehaviour
    {
        private SceneManager _sceneManager;
        private UIController _uiController;
        private RectTransform _rect;
        private Transform _playerCameraTransform;

        [Inject]
        private void Constructor(
            SceneManager sceneManager, 
            UIController uiController)
        {
            _sceneManager = sceneManager;
            _uiController = uiController;
        }

        private void Awake()
        {
            _rect = transform as RectTransform;
            _playerCameraTransform = _sceneManager.PlayerCamera.transform;
            
            _uiController.InfoPanel.ChangedVisibility += OnValueChanged;
        }

        private void OnDestroy()
        {
            _uiController.InfoPanel.ChangedVisibility -= OnValueChanged;
        }

        private void OnValueChanged(RectTransform rectTransform)
        {
            var leftPosition = _uiController.ReferenceResolution.x + rectTransform.offsetMax.x;
            _rect.offsetMin = new Vector2(leftPosition, _rect.offsetMin.y);
            
            var worldPoint = _sceneManager.CanvasCamera.ScreenToWorldPoint(_rect.position);
            _playerCameraTransform.position = new Vector3
            {
                x = -worldPoint.x,
                y = worldPoint.y,
                z = _playerCameraTransform.position.z
            };
        }
    }
}
