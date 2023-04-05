using InteractiveObject.Interfaces;
using UI;

namespace InteractiveObject
{
    public class InteractiveObjectData
    {
        private readonly IInteractiveObject _interactiveObject;
        private readonly ModelButton _button;

        public IInteractiveObject InteractiveObject => _interactiveObject;
        public ModelButton ModelButton => _button;
        
        public InteractiveObjectData(IInteractiveObject interactiveObject, ModelButton button)
        {
            _interactiveObject = interactiveObject;
            _button = button;
            _button.SetButtonText = _interactiveObject.GetLocalizedName;
        }
    }
}