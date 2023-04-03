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
        private UIController _uiController;
        private PlayerController _playerController;

        [SerializeField] private Part _testPart;

        public Camera PlayerCamera => _playerCamera;
        public Camera CanvasCamera => _canvasCamera;

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
        }

        private void OnDestroy()
        {
            _uiController.Toolbar.PressedIncisionButton -= OnPressedIncisionButton;
            _uiController.Toolbar.PressedResetTurnButton -= OnPressedResetTurnButton;
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
    }
}