using System.Collections.Generic;
using Factories;
using UI;
using UnityEngine;

namespace Inventory
{
    public class ObjectButtonInventory
    {
        private ObjectButtonFactory _factory;
        private List<ModelButton> _buttons = new List<ModelButton>();

        public ObjectButtonInventory(ObjectButtonFactory factory)
        {
            _factory = factory;
        }

        public ModelButton CreateButton(ModelButton prefab, Vector3 worldPosition, Transform parent)
        {
            var modelButton = _factory.Create(prefab, worldPosition, parent);
            _buttons.Add(modelButton);
            return modelButton;
        }
    }
}