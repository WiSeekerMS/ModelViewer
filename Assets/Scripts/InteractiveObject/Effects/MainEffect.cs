using Common;
using UnityEngine;

namespace InteractiveObject.Effects
{
    public class MainEffect : MonoBehaviour, IEffect
    {
        [SerializeField] private EffectType _effectType;
        [SerializeField] private ParticleSystem _particleSystem;
        
        public EffectType EffectType => _effectType;

        private void OnDisable()
        {
            Stop();
        }

        public void Play()
        {
            if (_particleSystem)
                _particleSystem.Play();
        }

        public void Stop()
        {
            if (!_particleSystem) return;
            
            _particleSystem.Stop();
            _particleSystem.Clear();
        }
    }
}