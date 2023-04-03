using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "MainConfig", menuName = "Configs/MainConfig")]
    public class MainConfig : ScriptableObject
    {
        [SerializeField] private float _mouseSensitive;

        public float MouseSensitive => _mouseSensitive;
    }
}