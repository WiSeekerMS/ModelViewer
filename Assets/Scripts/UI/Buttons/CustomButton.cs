using TMPro;
using UnityEngine.UI;

namespace UI.Buttons
{
    public class CustomButton : Button
    {
        private TextMeshProUGUI _buttonTMP;
        private string _buttonText;
        private bool _isOn;

        public bool IsOn => _isOn;

        public void Init(string buttonName)
        {
            _buttonText = buttonName;
            _buttonTMP = transform
                .GetChild(0)
                .GetComponent<TextMeshProUGUI>();
            
            onClick.AddListener(OnClick);
            SetButtonText();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            onClick.RemoveListener(OnClick);
        }

        private void OnClick()
        {
            _isOn = !_isOn;
            SetButtonText();
        }

        private void SetButtonText()
        {
            _buttonTMP.text = _isOn
                ? _buttonText + " Off"
                : _buttonText + " On";
        }
        
        public void ResetButton()
        {
            _isOn = false;
            SetButtonText();
        }
    }
}