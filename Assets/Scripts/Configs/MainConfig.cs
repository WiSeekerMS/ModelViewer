using System.Collections.Generic;
using Parts;
using UI;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "MainConfig", menuName = "Configs/MainConfig")]
    public class MainConfig : ScriptableObject
    {
        [SerializeField] private float _mouseSensitive;
        [SerializeField] private ModelButton _modelButtonPrefab;
        [SerializeField] private List<Model> _modelPrefabs;

        public float MouseSensitive => _mouseSensitive;
        public ModelButton ModelButtonPrefab => _modelButtonPrefab;
        public List<Model> ModelsPrefabs => _modelPrefabs;
    }
}