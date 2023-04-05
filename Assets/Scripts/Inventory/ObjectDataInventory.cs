﻿using System.Collections.Generic;
using InteractiveObject;
using InteractiveObject.Base;
using InteractiveObject.ExampleObjects;
using UI;
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
            ModelButton buttonPrefab, 
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

        public InteractiveObjectData GetDataByIndex(int index)
        {
            return _modelsData.Count > index && index > 0 
                ? _modelsData[index] 
                : null;
        }
    }
}