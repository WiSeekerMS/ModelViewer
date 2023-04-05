using Common.Localization;

namespace InteractiveObject.Part.Interfaces
{
    public interface ILocalizable
    {
        LocalizedItem GetLocalizedItem { get; }
    }
}