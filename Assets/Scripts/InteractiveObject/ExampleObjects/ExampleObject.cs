using System.Linq;
using InteractiveObject.Base;

namespace InteractiveObject.ExampleObjects
{
    public class ExampleObject : BaseInteractiveObject
    {
        public override string GetPartLocalizedText(BasePart obj)
        {
            return _parts
                ?.FirstOrDefault(p => string.Equals(p.name, obj.name))
                ?.GetLocalizedItem.LocalizedText;
        }
    }
}