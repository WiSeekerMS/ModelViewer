using UI;

namespace Parts
{
    public class ModelData
    {
        private readonly IModel _model;
        private readonly ModelButton _button;

        public IModel Model => _model;
        public ModelButton ModelButton => _button;
        
        public ModelData(IModel model, ModelButton button)
        {
            _model = model;
            _button = button;
            _button.SetButtonText = _model.GetLocalizedName;
        }
    }
}