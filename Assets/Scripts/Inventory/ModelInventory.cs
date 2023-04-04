using System.Collections.Generic;
using Factories;
using Parts;
using UnityEngine;

namespace Inventory
{
    public class ModelInventory
    {
        private ModelFactory _factory;
        private List<Model> _models = new List<Model>();
        
        public ModelInventory(ModelFactory factory)
        {
            _factory = factory;
        }

        public Model CreateModel(Model prefab, Vector3 worldPosition, Transform parent)
        {
            var model = _factory.Create(prefab, worldPosition, parent);
            model.Visibility = false;
            _models.Add(model);
            return model;
        }
    }
}