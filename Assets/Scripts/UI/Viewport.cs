using Common;
using Common.Constants;
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
        private Transform _objectInventoryTransform;

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
            _objectInventoryTransform = _sceneManager.ObjectInventoryTransform;
            
            _uiController.InfoPanel.ChangedVisibility += OnValueChanged;
        }

        private void OnDestroy()
        {
            _uiController.InfoPanel.ChangedVisibility -= OnValueChanged;
        }

        private void OnValueChanged(RectTransform rectTransform)
        {
            var delta = Mathf.Abs(_playerCameraTransform.position.z / Constants.DefaultPlayerCameraZPos);
            var leftPosition = _uiController.ReferenceResolution.x + rectTransform.offsetMax.x;
            _rect.offsetMin = new Vector2(leftPosition, _rect.offsetMin.y);
            
            var worldPoint = _sceneManager.CanvasCamera.ScreenToWorldPoint(_rect.position);
            _objectInventoryTransform.position = new Vector3
            {
                x = worldPoint.x * delta,
                y = worldPoint.y,
                z = 0f
            };
        }
    }
}
