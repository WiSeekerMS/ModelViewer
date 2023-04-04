using System.Collections.Generic;
using Parts;
using UI;
using UnityEngine;

namespace Inventory
{
    public class ModelDataInventory
    {
        private readonly ModelInventory _modelInventory;
        private readonly ModelButtonInventory _buttonInventory;
        private List<ModelData> _modelsData = new List<ModelData>();

        public List<ModelData> ModelsData => _modelsData;

        public ModelDataInventory(
            ModelInventory modelInventory,
            ModelButtonInventory buttonInventory)
        {
            _modelInventory = modelInventory;
            _buttonInventory = buttonInventory;
        }

        public IEnumerator<ModelData> CreateModelData(
            Model modelPrefab, 
            ModelButton buttonPrefab, 
            Transform modelParent, 
            RectTransform buttonsParent)
        {
            var model = _modelInventory.CreateModel(modelPrefab, Vector3.zero, modelParent);
            var button = _buttonInventory.CreateButton(buttonPrefab, Vector3.zero, buttonsParent);
            button.ResetScale();
            
            var modelData = new ModelData(model, button);
            _modelsData.Add(modelData);
            
            yield return modelData;
        }

        public ModelData GetDataByIndex(int index)
        {
            return _modelsData.Count > index && index > 0 
                ? _modelsData[index] 
                : null;
        }
    }
}