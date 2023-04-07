using Common.Enums;

namespace Effects.Interfaces
{
    public interface IEffect
    {
        EffectType EffectType { get; }
        void Play();
        void Stop();
    }
}