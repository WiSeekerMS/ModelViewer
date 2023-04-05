using InteractiveObject.Base;
using UnityEngine;
using Zenject;

namespace Factories
{
    public class InteractiveObjectFactory : PlaceholderFactory<BaseInteractiveObject>
    {
        private DiContainer _diContainer;

        public InteractiveObjectFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }
        
        public BaseInteractiveObject Create(BaseInteractiveObject prefab, Vector3 worldPosition, Transform parent)
        {
            return _diContainer.InstantiatePrefabForComponent<BaseInteractiveObject>(prefab,
                worldPosition, Quaternion.identity, parent);
        }
    }
}