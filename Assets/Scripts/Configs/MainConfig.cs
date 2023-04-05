using System.Collections.Generic;
using InteractiveObject.Base;
using UI.Buttons;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "MainConfig", menuName = "Configs/MainConfig")]
    public class MainConfig : ScriptableObject
    {
        [Header("Control")]
        [SerializeField] private float _mouseSensitive;
        
        [Header("Viewer")]
        [SerializeField] private ObjectButton objectButtonPrefab;
        [SerializeField] private List<BaseInteractiveObject> _objectPrefabs;
        
        [Header("Decompose Effect")]
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _rotateSpeed;
        [SerializeField] private float _delayBeforeComplete;

        public float MouseSensitive => _mouseSensitive;
        public ObjectButton ObjectButtonPrefab => objectButtonPrefab;
        public List<BaseInteractiveObject> ObjectPrefabs => _objectPrefabs;
        public float MoveSpeed => _moveSpeed;
        public float RotateSpeed => _rotateSpeed;
        public float DelayBeforeComplete => _delayBeforeComplete;
    }
}