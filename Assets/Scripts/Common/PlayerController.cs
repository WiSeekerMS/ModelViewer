using Configs;
using Services;
using UniRx;
using UnityEngine;
using Zenject;

namespace Common
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Transform _testObject;
        private SceneManager _sceneManager;
        private InputService _inputService;
        private MainConfig _mainConfig;
        private float _xRotation;
        private float _yRotation;
        private bool _isHit;

        [Inject]
        private void Constructor(
            SceneManager sceneManager,
            InputService inputService, 
            MainConfig mainConfig)
        {
            _sceneManager = sceneManager;
            _inputService = inputService;
            _mainConfig = mainConfig;
        }

        private void Awake()
        {
            Observable
                .EveryUpdate()
                .Subscribe(_ => OnUpdate())
                .AddTo(this);
        
            Observable
                .EveryFixedUpdate()
                .Subscribe(_ => OnFixedUpdate())
                .AddTo(this);
        }

        public void ResetRotation()
        {
            _xRotation = 0f;
            _yRotation = 0f;
        }

        private void OnUpdate()
        {
            if (!_inputService.IsGrab) 
                return;
        
            var valueX = _inputService.XAxisDelta * Time.deltaTime * _mainConfig.MouseSensitive;
            var valueY = _inputService.YAxisDelta * Time.deltaTime * _mainConfig.MouseSensitive;

            _xRotation += valueY;
            _yRotation -= valueX;

            _testObject.localRotation = Quaternion.Euler(_xRotation, _yRotation, 0f);
        }

        private void OnFixedUpdate()
        {
            var mousePosition = _inputService.MousePosition; 
            var ray = _sceneManager.PlayerCamera.ScreenPointToRay(mousePosition);
            _isHit = Physics.Raycast(ray, out var hitInfo, Mathf.Infinity);
            if (!_isHit) return;

            Debug.DrawRay(ray.origin, ray.direction * hitInfo.distance, Color.red);
        }
    }
}
