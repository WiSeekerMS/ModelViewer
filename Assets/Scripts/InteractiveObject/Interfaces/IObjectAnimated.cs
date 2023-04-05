using Common;

namespace InteractiveObject.Interfaces
{
    public interface IObjectAnimated
    {
        void PlayEffect(EffectType effectType);
        void StopEffect(EffectType effectType);
    }
}