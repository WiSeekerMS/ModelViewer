using System;
using Common;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;

namespace UI
{
    public class ToolbarPanel : MonoBehaviour
    {
        [SerializeField] private Button _incisionButton;
        [SerializeField] private Button _resetTurnButton;
        [SerializeField] private Button _effectButton;
        [SerializeField] private ScrollRect _scrollView;
        private TextMeshProUGUI _incisionButtonText;
        private bool _isIncision;

        public RectTransform ButtonsContentRectTransform => _scrollView.content;
        public event Action<bool> PressedIncisionButton;
        public event Action PressedResetTurnButton;
        public event Action PressedEffectButton;

        private void Awake()
        {
            _incisionButton.onClick.AddListener(OnPressedIncisionButton);
            _resetTurnButton.onClick.AddListener(OnPressedResetTurnButton);
            _effectButton.onClick.AddListener(OnPressedEffectButton);
        }

        private void Start()
        {
            _incisionButtonText = _incisionButton.GetComponentInChildren<TextMeshProUGUI>();
            SetIncisionButtonText();
        }

        private void OnDestroy()
        {
            _incisionButton.onClick.RemoveAllListeners();
            _resetTurnButton.onClick.RemoveAllListeners();
            _effectButton.onClick.RemoveAllListeners();
        }

        private void SetIncisionButtonText()
        {
            if (_incisionButtonText == null)
            {
                return;
            }

            _incisionButtonText.text = _isIncision
                ? Constants.IncisionButtonOffText
                : Constants.IncisionButtonOnText;
        }

        private void OnPressedIncisionButton()
        {
            PressedIncisionButton?.Invoke(_isIncision);
            _isIncision = !_isIncision;
            SetIncisionButtonText();
        }
        
        private void OnPressedResetTurnButton()
        {
            PressedResetTurnButton?.Invoke();
        }

        private void OnPressedEffectButton()
        {
            PressedEffectButton?.Invoke();
        }
    }
}