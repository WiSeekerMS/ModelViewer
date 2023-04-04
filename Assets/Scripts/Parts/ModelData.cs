using UI;

namespace Parts
{
    public class ModelData
    {
        private readonly Model _model;
        private readonly ModelButton _button;

        public Model Model => _model;
        public ModelButton ModelButton => _button;
        
        public ModelData(Model model, ModelButton button)
        {
            _model = model;
            _button = button;
            _button.SetButtonText = _model.GetLocalizedName;
        }
    }
}