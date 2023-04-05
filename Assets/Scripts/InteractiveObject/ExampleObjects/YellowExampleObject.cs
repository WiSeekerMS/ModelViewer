using System.Linq;
using InteractiveObject.Base;

namespace InteractiveObject.ExampleObjects
{
    public class YellowExampleObject : BaseInteractiveObject
    {
        public override string GetPartLocalizedText(BasePart obj)
        {
            return _parts
                ?.FirstOrDefault(p => string.Equals(p.name, obj.name))
                ?.GetLocalizedItem.LocalizedText;
        }
    }
}