using System.Collections;
using Common.Localization;
using Configs;
using InteractiveObject;
using InteractiveObject.Base;
using InteractiveObject.Interfaces;
using Inventory;
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
        private ObjectDataInventory _objectDataInventory;
        private MainConfig _mainConfig;
        private InteractiveObjectData _currentInteractiveObjectData;

        public Camera PlayerCamera => _playerCamera;
        public Camera CanvasCamera => _canvasCamera;
        public IInteractiveObject GetCurrentInteractiveObjectData => _currentInteractiveObjectData.InteractiveObject;
        public Transform ObjectInventoryTransform => _inventoryTransform;

        [Inject]
        private void Constructor(
            UIController uiController, 
            PlayerController playerController,
            LocalizationController localizationController,
            ObjectDataInventory objectDataInventory,
            MainConfig mainConfig)
        {
            _uiController = uiController;
            _playerController = playerController;
            _localizationController = localizationController;
            _objectDataInventory = objectDataInventory;
            _mainConfig = mainConfig;
        }

        private void Awake()
        {
            _uiController.ToolbarPanel.PressedIncisionButton += OnPressedIncisionButton;
            _uiController.ToolbarPanel.PressedResetTurnButton += OnPressedResetTurnButton;
            _uiController.ToolbarPanel.PressedEffectButton += OnPressedEffectButton;
            _uiController.ToolbarPanel.PressedDecomposeButton += OnPressedEffectButton;
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
            var modelPrefabs = _mainConfig.ObjectPrefabs;
            var buttonPrefab = _mainConfig.ModelButtonPrefab;
            var buttonsParent = _uiController.ToolbarPanel.ButtonsContentRectTransform;
            
            foreach (var prefab in modelPrefabs)
            {
                yield return _objectDataInventory
                    .CreateModelData(prefab, buttonPrefab, _inventoryTransform, buttonsParent);
            }
        }

        private void OnDestroy()
        {
            _uiController.ToolbarPanel.PressedIncisionButton -= OnPressedIncisionButton;
            _uiController.ToolbarPanel.PressedResetTurnButton -= OnPressedResetTurnButton;
            _uiController.ToolbarPanel.PressedEffectButton -= OnPressedEffectButton;
            _uiController.ToolbarPanel.PressedDecomposeButton -= OnPressedEffectButton;
            _uiController.PressedDataButton -= OnPressedDataButton;
            _playerController.HitObject -= OnHitObject;
        }

        private bool CheckCurrentModelDataAvailability()
        {
            if (_currentInteractiveObjectData != null && !_currentInteractiveObjectData.Equals(null)) return true;
            Debug.Log("[SceneManager] No current model.");
            return false;
        }

        private void OnPressedDataButton(InteractiveObjectData data)
        {
            if (CheckCurrentModelDataAvailability())
            {
                _currentInteractiveObjectData.InteractiveObject.Visibility = false;
            }
            
            _currentInteractiveObjectData = data;
            _currentInteractiveObjectData.InteractiveObject.Visibility = true;
        }

        private void OnPressedIncisionButton(bool isIncision)
        {
            if (!CheckCurrentModelDataAvailability())
                return;
            
            _currentInteractiveObjectData.InteractiveObject.SetVisibilityBodyFront(isIncision);
        }

        private void OnPressedResetTurnButton()
        {
            if (!CheckCurrentModelDataAvailability())
                return;
            
            _currentInteractiveObjectData.InteractiveObject.ResetRotation();
            _playerController.ResetRotation();
        }
        
        private void OnPressedEffectButton(EffectType effectType, bool isOn)
        {
            if (!CheckCurrentModelDataAvailability())
                return;

            var obj = _currentInteractiveObjectData.InteractiveObject;
            switch (isOn)
            {
                case true:
                    obj.StopEffect(effectType);
                    break;
                case false:
                    obj.PlayEffect(effectType);
                    break;
            }
        }

        private void OnHitObject(GameObject obj)
        {
            if (!CheckCurrentModelDataAvailability())
                return;

            var basePart = obj.GetComponent<BasePart>();
            if (!basePart) return;

            var partLocalizedText = _currentInteractiveObjectData.InteractiveObject.GetPartLocalizedText(basePart);
            _uiController.InfoPanel.SetPartName = partLocalizedText;
            _currentInteractiveObjectData.InteractiveObject.MakeAnOutline(basePart);
        }
    }
}