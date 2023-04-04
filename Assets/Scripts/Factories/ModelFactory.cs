using Parts;
using UnityEngine;
using Zenject;

namespace Factories
{
    public class ModelFactory : PlaceholderFactory<Model>
    {
        private DiContainer _diContainer;

        public ModelFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }
        
        public Model Create(Model prefab, Vector3 worldPosition, Transform parent)
        {
            return _diContainer.InstantiatePrefabForComponent<Model>(prefab,
                worldPosition, Quaternion.identity, parent);
        }
    }
}