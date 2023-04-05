using System;
using Configs;
using Services;
using UniRx;
using UnityEngine;
using Zenject;

namespace Common
{
    public class PlayerController : MonoBehaviour
    {
        private SceneManager _sceneManager;
        private InputService _inputService;
        private MainConfig _mainConfig;
        private RaycastHit _lastHit;
        private float _xRotation;
        private float _yRotation;

        public event Action<GameObject> HitObject;

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
            if (!_inputService.IsGrab) return;

            var model = _sceneManager.GetCurrentInteractiveObjectData;
            if (model == null || model.Equals(null)) return;
        
            var valueX = _inputService.XAxisDelta * Time.deltaTime * _mainConfig.MouseSensitive;
            var valueY = _inputService.YAxisDelta * Time.deltaTime * _mainConfig.MouseSensitive;

            _xRotation += valueY;
            _yRotation -= valueX;

            model.SetLocalRotation = new Vector2(_xRotation, _yRotation);
        }

        private void OnFixedUpdate()
        {
            var mousePosition = _inputService.MousePosition; 
            var ray = _sceneManager.PlayerCamera.ScreenPointToRay(mousePosition);
            var isHit = Physics.Raycast(ray, out var hitInfo, Mathf.Infinity);
            if (!isHit || _lastHit.collider == hitInfo.collider) return;
            
            _lastHit = hitInfo;
            HitObject?.Invoke(_lastHit.transform.gameObject);
            Debug.DrawRay(ray.origin, ray.direction * hitInfo.distance, Color.red);
        }
    }
}
