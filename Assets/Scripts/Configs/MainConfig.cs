using System.Collections.Generic;
using Parts;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "MainConfig", menuName = "Configs/MainConfig")]
    public class MainConfig : ScriptableObject
    {
        [SerializeField] private float _mouseSensitive;
        [SerializeField] private List<Model> _modelPrefabs;

        public float MouseSensitive => _mouseSensitive;
    }
}