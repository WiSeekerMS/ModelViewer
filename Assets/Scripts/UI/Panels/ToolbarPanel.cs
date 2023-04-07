using System;
using Common;
using Common.Constants;
using Common.Enums;
using UI.Buttons;
using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;

namespace UI.Panels
{
    public class ToolbarPanel : MonoBehaviour
    {
        [SerializeField] private CustomButton _incisionButton;
        [SerializeField] private CustomButton _effectButton;
        [SerializeField] private CustomButton _decomposeButton;
        [SerializeField] private Button _resetTurnButton;
        [SerializeField] private ScrollRect _scrollView;

        public RectTransform ButtonsContentRectTransform => _scrollView.content;
        public event Action<bool> PressedIncisionButton;
        public event Action PressedResetTurnButton;
        public event Action<EffectType, bool> PressedEffectButton;
        public event Action<EffectType, bool> PressedDecomposeButton;

        private void Awake()
        {
            _incisionButton.onClick.AddListener(OnPressedIncisionButton);
            _resetTurnButton.onClick.AddListener(OnPressedResetTurnButton);
            _effectButton.onClick.AddListener(OnPressedEffectButton);
            _decomposeButton.onClick.AddListener(OnPressedDecomposeButton);
        }

        private void Start()
        {
            _incisionButton.Init(Constants.IncisionButtonText);
            _decomposeButton.Init(Constants.DecomposeButtonText);
            _effectButton.Init(Constants.EffectButtonText);
        }

        private void OnDestroy()
        {
            _incisionButton.onClick.RemoveAllListeners();
            _resetTurnButton.onClick.RemoveAllListeners();
            _effectButton.onClick.RemoveAllListeners();
            _decomposeButton.onClick.RemoveAllListeners();
        }

        private void OnPressedIncisionButton()
        {
            PressedIncisionButton?.Invoke(_incisionButton.IsOn);
        }
        
        private void OnPressedResetTurnButton()
        {
            PressedResetTurnButton?.Invoke();
        }

        private void OnPressedEffectButton()
        {
            PressedEffectButton?.Invoke(EffectType.MainEffect, _effectButton.IsOn);
        }

        private void OnPressedDecomposeButton()
        {
            PressedDecomposeButton?.Invoke(EffectType.Decompose, _decomposeButton.IsOn);
        }

        public void ResetButtons()
        {
            _incisionButton.ResetButton();
            _decomposeButton.ResetButton();
            _effectButton.ResetButton();
        }
    }
}