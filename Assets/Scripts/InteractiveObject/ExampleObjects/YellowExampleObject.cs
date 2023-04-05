using System.Linq;
using InteractiveObject.Base;
using UnityEngine;

namespace InteractiveObject.ExampleObjects
{
    public class YellowExampleObject : BaseInteractiveObject
    {
        public override string GetPartLocalizedText(GameObject obj)
        {
            return _localizedParts
                ?.FirstOrDefault(l => string.Equals(l.name, obj.name))
                ?.LocalizedText;
        }

        public override void StartAnimation()
        {
        }

        public override void StopAnimation()
        {
        }
    }
}