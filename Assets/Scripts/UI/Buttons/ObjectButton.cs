using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Buttons
{
    public class ObjectButton : Button
    {
        [SerializeField] private TextMeshProUGUI _nameTMP;

        public void Init(string buttonName)
        {
            _nameTMP.text = buttonName;
        }

        public void ResetScale()
        {
            transform.localScale = Vector3.one;
        }
    }
}