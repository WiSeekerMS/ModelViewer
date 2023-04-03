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
        private RectTransform _scrollViewContent;
        private VerticalLayoutGroup _verticalLayoutGroup;
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
            _scrollViewContent = _scrollView.content;
            _verticalLayoutGroup = _scrollViewContent.GetComponent<VerticalLayoutGroup>();
            _incisionButtonText = _incisionButton.GetComponentInChildren<TextMeshProUGUI>();
            
            SetIncisionButtonText();
        }

        private void OnDestroy()
        {
            _incisionButton.onClick.RemoveAllListeners();
            _resetTurnButton.onClick.RemoveAllListeners();
        }

        public void FillModelsDataList()
        {
            var spacing = _verticalLayoutGroup != null 
                ? _verticalLayoutGroup.spacing 
                : 0f;

            /*var offsetMax = _scrollViewContent.offsetMax;
            var prefabTransform = infoPrefab.transform as RectTransform;
            var rightShift = prefabTransform.sizeDelta.x * configs.Count + (configs.Count * spacing);

            _scrollViewContent.offsetMax = new Vector2
            {
                x = offsetMax.x + rightShift, 
                y = offsetMax.y
            };*/
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