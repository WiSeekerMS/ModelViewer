using System.Collections;
using Common.Localization;
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
        private LocalizationController _localizationController;
        private PlayerController _playerController;
        private UIController _uiController;
        private IModel _currentModel;

        [SerializeField] private Model _testPart;

        public Camera PlayerCamera => _playerCamera;
        public Camera CanvasCamera => _canvasCamera;
        public IModel GetCurrentModel => _currentModel;

        [Inject]
        private void Constructor(
            UIController uiController, 
            PlayerController playerController,
            LocalizationController localizationController)
        {
            _uiController = uiController;
            _playerController = playerController;
            _localizationController = localizationController;
        }

        private void Awake()
        {
            _uiController.Toolbar.PressedIncisionButton += OnPressedIncisionButton;
            _uiController.Toolbar.PressedResetTurnButton += OnPressedResetTurnButton;
            _playerController.HitObject += OnHitObject;
        }

        private IEnumerator Start()
        {
            yield return _localizationController.LocalizationInitialization();
            
            _currentModel = _testPart;
            _uiController.InfoPanel.SetDescriptionText = _currentModel.GetLocalizedDescription;
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
            var partLocalizedText = _testPart.GetPartLocalizedText(obj);
            _uiController.InfoPanel.SetPartName = partLocalizedText;
            _testPart.MakeAnOutline(obj);
        }
    }
}