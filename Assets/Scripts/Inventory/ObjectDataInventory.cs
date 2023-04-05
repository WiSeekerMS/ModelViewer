using System.Collections.Generic;
using InteractiveObject.Base;
using InteractiveObject.Data;
using UI.Buttons;
using UnityEngine;

namespace Inventory
{
    public class ObjectDataInventory
    {
        private readonly InteractiveObjectInventory _interactiveObjectInventory;
        private readonly ObjectButtonInventory _buttonInventory;
        private List<InteractiveObjectData> _modelsData = new List<InteractiveObjectData>();

        public List<InteractiveObjectData> ModelsData => _modelsData;

        public ObjectDataInventory(
            InteractiveObjectInventory interactiveObjectInventory,
            ObjectButtonInventory buttonInventory)
        {
            _interactiveObjectInventory = interactiveObjectInventory;
            _buttonInventory = buttonInventory;
        }

        public IEnumerator<InteractiveObjectData> CreateModelData(
            BaseInteractiveObject interactiveObjectPrefab, 
            ObjectButton buttonPrefab, 
            Transform modelParent, 
            RectTransform buttonsParent)
        {
            var model = _interactiveObjectInventory.CreateModel(interactiveObjectPrefab, Vector3.zero, modelParent);
            var button = _buttonInventory.CreateButton(buttonPrefab, Vector3.zero, buttonsParent);
            button.ResetScale();
            
            var modelData = new InteractiveObjectData(model, button);
            _modelsData.Add(modelData);
            
            yield return modelData;
        }
    }
}