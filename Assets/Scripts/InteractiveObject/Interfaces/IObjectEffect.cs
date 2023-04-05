using Common;

namespace InteractiveObject.Interfaces
{
    public interface IObjectEffect
    {
        void PlayEffect(EffectType effectType);
        void StopEffect(EffectType effectType);
    }
}