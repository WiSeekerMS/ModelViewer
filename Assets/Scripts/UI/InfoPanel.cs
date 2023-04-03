using System;
using Common;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class InfoPanel : MonoBehaviour
    {
        [SerializeField] private Button _openButton;
        [SerializeField] private RectanglePositions _showPosition;
        [SerializeField] private RectanglePositions _hidePosition;
        private TextMeshProUGUI _openButtonText;
        private RectTransform _rectTransform;
        private bool _isVisible;

        public event Action<RectTransform> ChangedVisibility;

        public bool SetVisible
        {
            set
            {
                _isVisible = value;
                OnPressedShowButton();
            }
        }

        private void Awake()
        {
            _rectTransform = transform as RectTransform;
            _openButton.onClick.AddListener(OnPressedShowButton);
        }
        
        private void Start()
        {
            _openButtonText = _openButton.GetComponentInChildren<TextMeshProUGUI>();
        }

        private void OnDestroy()
        {
            _openButton.onClick.RemoveAllListeners();
        }

        private void OnPressedShowButton()
        {
            var position = _isVisible ? _showPosition : _hidePosition;
            _rectTransform.offsetMax = new Vector2(-position.Right, -position.Top);
            
            _openButtonText.text = _isVisible 
                ? Constants.InfoPanelOpenButtonText 
                : Constants.InfoPanelCloseButtonText;
            
            ChangedVisibility?.Invoke(_rectTransform);
            _isVisible = !_isVisible;
        }
    }
}