using System.Collections;
using Common.Localization;
using Configs;
using Inventory;
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
        [SerializeField] private Transform _inventoryTransform;
        private LocalizationController _localizationController;
        private PlayerController _playerController;
        private UIController _uiController;
        private ModelDataInventory _modelDataInventory;
        private MainConfig _mainConfig;
        private ModelData _currentModelData;

        public Camera PlayerCamera => _playerCamera;
        public Camera CanvasCamera => _canvasCamera;
        public IModel GetCurrentModelData => _currentModelData.Model;

        [Inject]
        private void Constructor(
            UIController uiController, 
            PlayerController playerController,
            LocalizationController localizationController,
            ModelDataInventory modelDataInventory,
            MainConfig mainConfig)
        {
            _uiController = uiController;
            _playerController = playerController;
            _localizationController = localizationController;
            _modelDataInventory = modelDataInventory;
            _mainConfig = mainConfig;
        }

        private void Awake()
        {
            _uiController.ToolbarPanel.PressedIncisionButton += OnPressedIncisionButton;
            _uiController.ToolbarPanel.PressedResetTurnButton += OnPressedResetTurnButton;
            _uiController.PressedDataButton += OnPressedDataButton;
            _playerController.HitObject += OnHitObject;
        }

        private IEnumerator Start()
        {
            yield return _localizationController.LocalizationInitialization();
            yield return CreateModelsData();
            _uiController.Init();
        }

        private IEnumerator CreateModelsData()
        {
            var modelPrefabs = _mainConfig.ModelsPrefabs;
            var buttonPrefab = _mainConfig.ModelButtonPrefab;
            var buttonsParent = _uiController.ToolbarPanel.ButtonsContentRectTransform;
            
            foreach (var prefab in modelPrefabs)
            {
                yield return _modelDataInventory
                    .CreateModelData(prefab, buttonPrefab, _inventoryTransform, buttonsParent);
            }
        }

        private void OnDestroy()
        {
            _uiController.ToolbarPanel.PressedIncisionButton -= OnPressedIncisionButton;
            _uiController.ToolbarPanel.PressedResetTurnButton -= OnPressedResetTurnButton;
            _uiController.PressedDataButton -= OnPressedDataButton;
            _playerController.HitObject -= OnHitObject;
        }

        private bool CheckCurrentModelDataAvailability()
        {
            if (_currentModelData != null && !_currentModelData.Equals(null)) return true;
            Debug.Log("[SceneManager] No current model.");
            return false;
        }

        private void OnPressedDataButton(ModelData data)
        {
            if (CheckCurrentModelDataAvailability())
            {
                _currentModelData.Model.Visibility = false;
            }

            _currentModelData = data;
            _currentModelData.Model.Visibility = true;
        }

        private void OnPressedIncisionButton(bool isIncision)
        {
            if (!CheckCurrentModelDataAvailability())
                return;
            
            _currentModelData.Model.SetVisibilityBodyFront(isIncision);
        }

        private void OnPressedResetTurnButton()
        {
            if (!CheckCurrentModelDataAvailability())
                return;
            
            _currentModelData.Model.ResetRotation();
            _playerController.ResetRotation();
        }

        private void OnHitObject(GameObject obj)
        {
            if (!CheckCurrentModelDataAvailability())
                return;
            
            var partLocalizedText = _currentModelData.Model.GetPartLocalizedText(obj);
            _uiController.InfoPanel.SetPartName = partLocalizedText;
            _currentModelData.Model.MakeAnOutline(obj);
        }
    }
}