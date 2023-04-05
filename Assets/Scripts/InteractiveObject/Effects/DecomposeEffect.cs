using System.Collections.Generic;
using Common;
using InteractiveObject.Base;
using UnityEngine;

namespace InteractiveObject.Effects
{
    public class DecomposeEffect : MonoBehaviour, IEffect
    {
        [SerializeField] private EffectType _effectType;
        [SerializeField] private List<BasePart> _parts;

        public EffectType EffectType => _effectType;

        public void Play()
        {
        }

        public void Stop()
        {
        }
    }
}