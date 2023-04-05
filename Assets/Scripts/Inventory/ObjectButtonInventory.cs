using System.Collections.Generic;
using Factories;
using UI.Buttons;
using UnityEngine;

namespace Inventory
{
    public class ObjectButtonInventory
    {
        private ObjectButtonFactory _factory;
        private List<ObjectButton> _buttons = new List<ObjectButton>();

        public ObjectButtonInventory(ObjectButtonFactory factory)
        {
            _factory = factory;
        }

        public ObjectButton CreateButton(ObjectButton prefab, Vector3 worldPosition, Transform parent)
        {
            var modelButton = _factory.Create(prefab, worldPosition, parent);
            _buttons.Add(modelButton);
            return modelButton;
        }
    }
}