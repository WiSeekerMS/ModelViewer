using System;
using Inventory;
using Parts;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private CanvasScaler _canvasScaler;
        [SerializeField] private InfoPanel _infoPanel;
        [SerializeField] private ToolbarPanel toolbarPanel;
        private ModelDataInventory _modelDataInventory;

        public Vector2 ReferenceResolution => _canvasScaler.referenceResolution;
        public InfoPanel InfoPanel => _infoPanel;
        public ToolbarPanel ToolbarPanel => toolbarPanel;

        public event Action<ModelData> PressedDataButton;

        [Inject]
        private void Constructor(ModelDataInventory modelDataInventory)
        {
            _modelDataInventory = modelDataInventory;
        }

        public void Init()
        {
            _infoPanel.SetVisible = false;
 
            _modelDataInventory.ModelsData.ForEach(data =>
            {
                data.ModelButton.Button.onClick.AddListener(() => OnPressedModelDataButton(data));
            });
        }

        private void OnDestroy()
        {
            _modelDataInventory.ModelsData.ForEach(data =>
            {
                data.ModelButton.Button.onClick.RemoveAllListeners();
            });
        }

        private void OnPressedModelDataButton(ModelData data)
        {
            PressedDataButton?.Invoke(data);
        }
    }
}