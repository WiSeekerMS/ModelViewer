using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ModelButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private TextMeshProUGUI _nameTMP;

        public Button Button => _button;

        public string SetButtonText
        {
            set => _nameTMP.text = value;
        }

        public void ResetScale()
        {
            _button.transform.localScale = Vector3.one;
        }
    }
}