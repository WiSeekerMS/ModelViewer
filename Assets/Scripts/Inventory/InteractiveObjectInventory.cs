using System.Collections.Generic;
using Factories;
using InteractiveObject.Base;
using UnityEngine;

namespace Inventory
{
    public class InteractiveObjectInventory
    {
        private InteractiveObjectFactory _factory;
        private List<BaseInteractiveObject> _models = new List<BaseInteractiveObject>();
        
        public InteractiveObjectInventory(InteractiveObjectFactory factory)
        {
            _factory = factory;
        }

        public BaseInteractiveObject CreateModel(BaseInteractiveObject prefab, Vector3 worldPosition, Transform parent)
        {
            var model = _factory.Create(prefab, worldPosition, parent);
            model.Visibility = false;
            _models.Add(model);
            return model;
        }
    }
}