using UI;
using UI.Buttons;
using UnityEngine;
using Zenject;

namespace Factories
{
    public class ObjectButtonFactory : PlaceholderFactory<ObjectButton>
    {
        private DiContainer _diContainer;

        public ObjectButtonFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }
        
        public ObjectButton Create(ObjectButton prefab, Vector3 worldPosition, Transform parent)
        {
            return _diContainer.InstantiatePrefabForComponent<ObjectButton>(prefab,
                worldPosition, Quaternion.identity, parent);
        }
    }
}