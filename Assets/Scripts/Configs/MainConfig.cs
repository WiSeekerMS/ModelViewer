using System.Collections.Generic;
using InteractiveObject.Base;
using UI;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "MainConfig", menuName = "Configs/MainConfig")]
    public class MainConfig : ScriptableObject
    {
        [SerializeField] private float _mouseSensitive;
        [SerializeField] private ModelButton _modelButtonPrefab;
        [SerializeField] private List<BaseInteractiveObject> _objectPrefabs;

        public float MouseSensitive => _mouseSensitive;
        public ModelButton ModelButtonPrefab => _modelButtonPrefab;
        public List<BaseInteractiveObject> ObjectPrefabs => _objectPrefabs;
    }
}