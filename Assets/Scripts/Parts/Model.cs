using System.Collections.Generic;
using System.Linq;
using Common.Localization;
using UnityEngine;

namespace Parts
{
    public class Model : MonoBehaviour, IModel
    {
        [SerializeField] private LocalizedItem _modelName;
        [SerializeField] private LocalizedItem _modelDescription;
        [SerializeField] private GameObject _bodyFront;
        [SerializeField] private Material _outlineMaterial;
        private List<OutlinePart> _outlineParts;
        private List<LocalizedItem> _localizedParts;
        private float _outlineScale;

        public bool Visibility
        {
            get => gameObject.activeSelf;
            set => gameObject.SetActive(value);
        }
        
        public string GetLocalizedName => _modelName != null
            ? _modelName.LocalizedText
            : string.Empty;
        
        public string GetLocalizedDescription => _modelDescription != null 
            ? _modelDescription.LocalizedText
            : string.Empty;

        public Vector2 SetLocalRotation
        {
            set => transform.localRotation = Quaternion.Euler(value.x, value.y, 0f);
        }

        private void OnEnable()
        {
            ResetOutline();
            ResetRotation();
            SetVisibilityBodyFront(true);
        }

        private void Start()
        {
            _localizedParts = transform
                .GetComponentsInChildren<LocalizedItem>()
                .ToList();
            
            _outlineParts = transform
                .GetComponentsInChildren<OutlinePart>()
                .ToList();

            _outlineParts?.ForEach(p =>
            {
                p.Material = new Material(_outlineMaterial);
                _outlineScale = p.OutlineScale;
                p.OutlineScale = 0f;
            });
        }

        public void SetVisibilityBodyFront(bool isVisible)
        {
            _bodyFront.SetActive(isVisible);
        }

        public void ResetRotation()
        {
            transform.rotation = Quaternion.identity;
        }

        public void MakeAnOutline(GameObject obj)
        {
            _outlineParts?.ForEach(p =>
            {
                p.OutlineScale = string.Equals(p.GetParentName, obj.name)
                    ? _outlineScale
                    : 0f;
            });
        }

        public void ResetOutline()
        {
            _outlineParts
                ?.ForEach(p => p.OutlineScale = 0f);
        }

        public string GetPartLocalizedText(GameObject obj)
        {
            return _localizedParts
                ?.FirstOrDefault(l => string.Equals(l.name, obj.name))
                ?.LocalizedText;
        }
    }
}