﻿using UI;
using UnityEngine;
using Zenject;

namespace Factories
{
    public class ModelButtonFactory : PlaceholderFactory<ModelButton>
    {
        private DiContainer _diContainer;

        public ModelButtonFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }
        
        public ModelButton Create(ModelButton prefab, Vector3 worldPosition, Transform parent)
        {
            return _diContainer.InstantiatePrefabForComponent<ModelButton>(prefab,
                worldPosition, Quaternion.identity, parent);
        }
    }
}