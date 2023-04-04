using Parts;
using UI;
using UnityEngine;
using Zenject;

namespace Common
{
    public class SceneManager : MonoBehaviour
    {
        [SerializeField] private Camera _playerCamera;
        [SerializeField] private Camera _canvasCamera;
        private PlayerController _playerController;
        private UIController _uiController;
        private IPart _currentPart;

        [SerializeField] private Part _testPart;

        public Camera PlayerCamera => _playerCamera;
        public Camera CanvasCamera => _canvasCamera;
        public IPart GetCurrentPart => _currentPart;

        [Inject]
        private void Constructor(
            UIController uiController, 
            PlayerController playerController)
        {
            _uiController = uiController;
            _playerController = playerController;
        }

        private void Awake()
        {
            _uiController.Toolbar.PressedIncisionButton += OnPressedIncisionButton;
            _uiController.Toolbar.PressedResetTurnButton += OnPressedResetTurnButton;
            _playerController.HitObject += OnHitObject;
        }

        private void Start()
        {
            _currentPart = _testPart;
        }

        private void OnDestroy()
        {
            _uiController.Toolbar.PressedIncisionButton -= OnPressedIncisionButton;
            _uiController.Toolbar.PressedResetTurnButton -= OnPressedResetTurnButton;
            _playerController.HitObject -= OnHitObject;
        }

        private void OnPressedIncisionButton(bool isIncision)
        {
            _testPart.SetVisibilityBodyFront(isIncision);
        }

        private void OnPressedResetTurnButton()
        {
            _testPart.ResetRotation();
            _playerController.ResetRotation();
        }

        private void OnHitObject(GameObject obj)
        {
            _uiController.InfoPanel.SetPartName = obj.name;
        }
    }
}