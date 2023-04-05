using InteractiveObject.Interfaces;
using UI.Buttons;

namespace InteractiveObject.Data
{
    public class InteractiveObjectData
    {
        private readonly IInteractiveObject _interactiveObject;
        private readonly ObjectButton _button;

        public IInteractiveObject InteractiveObject => _interactiveObject;
        public ObjectButton ObjectButton => _button;
        
        public InteractiveObjectData(IInteractiveObject interactiveObject, ObjectButton button)
        {
            _interactiveObject = interactiveObject;
            
            _button = button;
            _button.Init(_interactiveObject.GetLocalizedName);
        }
    }
}