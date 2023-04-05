using System.Collections.Generic;
using Common;
using DG.Tweening;
using InteractiveObject.Base;
using UnityEngine;

namespace InteractiveObject.Effects
{
    public class DecomposeEffect : MonoBehaviour, IEffect
    {
        [SerializeField] private EffectType _effectType;
        [SerializeField] private List<BasePart> _parts;
        private Sequence _sequence;

        private const float MoveSpeed = 0.5f;
        private const float RotateSpeed = 0.5f;
        private const float DelayBeforeComplete = 1f;

        public EffectType EffectType => _effectType;

        private void OnDisable()
        {
            _sequence?.Kill();

            foreach (var part in _parts)
            {
                if (part.IsHideWhenDecomposing)
                    part.EnableRenderers = true;

                part.transform.localPosition = part.GetDefaultLocalPosition;
                part.transform.localRotation = part.GetDefaultLocalRotate;
            }
        }

        private void CreateTween(BasePart part, Vector3 targetPos, Quaternion targetRot)
        {
            var moveTween = part.transform
                .DOLocalMove(targetPos, MoveSpeed)
                .SetEase(Ease.Linear).Pause();
                
            var rotateTween = part.transform
                .DOLocalRotateQuaternion(targetRot, RotateSpeed)
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
            _sequence.OnComplete(OnShowHiddenParts).SetDelay(DelayBeforeComplete);
            
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