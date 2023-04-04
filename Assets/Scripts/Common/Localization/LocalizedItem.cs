using UnityEngine;
using UnityEngine.Localization;

namespace Common.Localization
{
    public class LocalizedItem : MonoBehaviour
    {
        [SerializeField] private LocalizedString _localizedString;
        private string _localizedText;

        public string LocalizedText => _localizedText;
        
        private void OnEnable()
        {
            _localizedString.StringChanged += UpdateString;
        }

        private void OnDisable()
        {
            _localizedString.StringChanged -= UpdateString;
        }

        private void UpdateString(string value)
        {
            _localizedText = value;
        }
    }
}