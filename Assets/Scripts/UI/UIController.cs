using System;
using InteractiveObject.Data;
using Inventory;
using UI.Panels;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private CanvasScaler _canvasScaler;
        [SerializeField] private InfoPanel _infoPanel;
        [SerializeField] private ToolbarPanel _toolbarPanel;
        private ObjectDataInventory _objectDataInventory;

        public Vector2 ReferenceResolution => _canvasScaler.referenceResolution;
        public InfoPanel InfoPanel => _infoPanel;
        public ToolbarPanel ToolbarPanel => _toolbarPanel;

        public event Action<InteractiveObjectData> PressedDataButton;

        [Inject]
        private void Constructor(ObjectDataInventory objectDataInventory)
        {
            _objectDataInventory = objectDataInventory;
        }

        public void Init()
        {
            _infoPanel.SetVisible = false;
            _objectDataInventory.ModelsData.ForEach(data =>
            {
                data.ObjectButton.onClick.AddListener(() => OnPressedModelDataButton(data));
            });
        }

        private void OnDestroy()
        {
            _objectDataInventory.ModelsData.ForEach(data =>
            {
                data.ObjectButton.onClick.RemoveAllListeners();
            });
        }

        private void EnableDataButton(InteractiveObjectData data, bool value)
        {
            data.ObjectButton.interactable = value;
        }

        private void ToggleActiveButton(InteractiveObjectData data)
        {
            _objectDataInventory.ModelsData
                .ForEach(modelData =>
                {
                    var value = data != modelData;
                    EnableDataButton(modelData, value);
                });
        }

        private void OnPressedModelDataButton(InteractiveObjectData data)
        {
            ToggleActiveButton(data);

            _toolbarPanel.ResetButtons();
            _infoPanel.SetDescriptionText = data.InteractiveObject.GetLocalizedDescription;
            _infoPanel.SetPartName = string.Empty;
            
            PressedDataButton?.Invoke(data);
        }
    }
}