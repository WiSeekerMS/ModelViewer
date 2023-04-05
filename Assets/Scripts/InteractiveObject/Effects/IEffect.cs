using Common;

namespace InteractiveObject.Effects
{
    public interface IEffect
    {
        EffectType EffectType { get; }
        void Play();
        void Stop();
    }
}