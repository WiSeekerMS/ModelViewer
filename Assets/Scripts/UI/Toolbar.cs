using System;
using Common;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;

namespace UI
{
    public class Toolbar : MonoBehaviour
    {
        [SerializeField] private Button _incisionButton;
        [SerializeField] private Button _resetTurnButton;
        [SerializeField] private ScrollRect _scrollView;
        private TextMeshProUGUI _incisionButtonText;
        private bool _isIncision;

        public event Action<bool> PressedIncisionButton;
        public event Action PressedResetTurnButton;

        private void Awake()
        {
            _incisionButton.onClick.AddListener(OnPressedIncisionButton);
            _resetTurnButton.onClick.AddListener(OnPressedResetTurnButton);
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
    }
}