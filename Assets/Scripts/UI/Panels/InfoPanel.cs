﻿using System;
using Common;
using Common.Constants;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Panels
{
    public class InfoPanel : MonoBehaviour
    {
        [SerializeField] private Button _openButton;
        [SerializeField] private TextMeshProUGUI _descriptionTMP;
        [SerializeField] private TextMeshProUGUI _partNameTMP;
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private RectanglePosition showPosition;
        [SerializeField] private RectanglePosition hidePosition;
        private TextMeshProUGUI _openButtonTMP;
        private RectTransform _rectTransform;
        private bool _isVisible;

        public event Action<RectTransform> ChangedVisibility;

        public bool SetVisible
        {
            set
            {
                _isVisible = value;
                SetVisibility();
                OnPressedShowButton();
            }
        }
        
        public string SetDescriptionText
        {
            set => _descriptionTMP.text = value;
        }

        public string SetPartName
        {
            set => _partNameTMP.text = Constants.PartNameLabel + value;
        }

        private void Awake()
        {
            _rectTransform = transform as RectTransform;
            _openButton.onClick.AddListener(() => SetVisible = !_isVisible);
        }
        
        private void Start()
        {
            _openButtonTMP = _openButton.GetComponentInChildren<TextMeshProUGUI>();
        }

        private void OnDestroy()
        {
            _openButton.onClick.RemoveAllListeners();
        }
        
        private void SetVisibility()
        {
            _canvasGroup.alpha = _isVisible ? 1f : 0f;
            _canvasGroup.interactable = _isVisible;
        }

        private void OnPressedShowButton()
        {
            var position = _isVisible ? showPosition : hidePosition;
            _rectTransform.offsetMax = new Vector2(-position.Right, -position.Top);
            
            _openButtonTMP.text = _isVisible 
                ? Constants.InfoPanelOpenButtonText 
                : Constants.InfoPanelCloseButtonText;
            
            ChangedVisibility?.Invoke(_rectTransform);
        }
    }
}