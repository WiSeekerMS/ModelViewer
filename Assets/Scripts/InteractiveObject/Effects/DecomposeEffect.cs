using System.Collections.Generic;
using Common;
using Configs;
using DG.Tweening;
using InteractiveObject.Base;
using UnityEngine;
using Zenject;

namespace InteractiveObject.Effects
{
    public class DecomposeEffect : MonoBehaviour, IEffect
    {
        [SerializeField] private EffectType _effectType;
        [SerializeField] private List<BasePart> _parts;
        private MainConfig _mainConfig;
        private Sequence _sequence;

        public EffectType EffectType => _effectType;

        [Inject]
        private void Constructor(MainConfig mainConfig)
        {
            _mainConfig = mainConfig;
        }
        
        private void OnDisable()
        {
            _sequence?.Kill();

            foreach (var part in _parts)
            {
                if (part.IsHideWhenDecomposing)
                    part.EnableRenderers = true;

                var partTransform = part.transform;
                partTransform.localPosition = part.GetDefaultLocalPosition;
                partTransform.localRotation = part.GetDefaultLocalRotate;
            }
        }

        private void CreateTween(BasePart part, Vector3 targetPos, Quaternion targetRot)
        {
            var moveTween = part.transform
                .DOLocalMove(targetPos, _mainConfig.MoveSpeed)
                .SetEase(Ease.Linear).Pause();
                
            var rotateTween = part.transform
                .DOLocalRotateQuaternion(targetRot, _mainConfig.RotateSpeed)
                .SetEase(Ease.Linear).Pause();

            _sequence.Join(moveTween);
            _sequence.Join(rotateTween);
        }

        public void Play()
        {
            _sequence?.Kill();
            _sequence = DOTween.Sequence();
            
            foreach (var part in _parts)
            {
                if (part.IsHideWhenDecomposing)
                {
                    part.EnableRenderers = false;
                    continue;    
                }
                
                var targetPosition = part.GetTargetLocalPosition;
                var targetRotation = part.GetTargetLocalRotate;
                CreateTween(part, targetPosition, targetRotation);
            }
        }

        public void Stop()
        {
            _sequence?.Kill();
            _sequence = DOTween.Sequence();
            
            _sequence
                .OnComplete(OnShowHiddenParts)
                .SetDelay(_mainConfig.DelayBeforeComplete);
            
            foreach (var part in _parts)
            {
                var targetPosition = part.GetDefaultLocalPosition;
                var targetRotation = part.GetDefaultLocalRotate;
                CreateTween(part, targetPosition, targetRotation);
            }
        }
        
        private void OnShowHiddenParts()
        {
            foreach (var part in _parts)
            {
                if (!part.IsHideWhenDecomposing)
                    continue;

                part.EnableRenderers = true;
            }
        }
    }
}