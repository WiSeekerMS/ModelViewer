using System.Collections.Generic;
using System.Linq;
using Common;
using Common.Localization;
using InteractiveObject.Effects;
using InteractiveObject.Interfaces;
using UnityEngine;

namespace InteractiveObject.Base
{
    public class BaseInteractiveObject : MonoBehaviour, IInteractiveObject
    {
        [SerializeField] protected LocalizedItem _modelName;
        [SerializeField] protected LocalizedItem _modelDescription;
        [SerializeField] protected BasePart _bodyFront;
        [SerializeField] protected Material _outlineMaterial;
        protected List<BasePart> _parts;
        protected List<IEffect> _effects;
        protected float _outlineScale;

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

        private void Start()
        {
            _effects = transform
                .GetComponents<IEffect>()
                .ToList();
            
            _parts = transform
                .GetComponentsInChildren<BasePart>()
                .ToList();

            _parts?.ForEach(p =>
            {
                p.GetOutlinePart.Material = new Material(_outlineMaterial);
                _outlineScale = p.GetOutlinePart.OutlineScale;
                p.GetOutlinePart.OutlineScale = 0f;
            });
        }
        
        private void OnEnable()
        {
            ResetOutline();
            ResetRotation();
            SetVisibilityBodyFront(true);
        }

        public void SetVisibilityBodyFront(bool isVisible)
        {
            _bodyFront.Visibility = isVisible;
        }

        public void ResetRotation()
        {
            transform.rotation = Quaternion.identity;
        }

        public void MakeAnOutline(BasePart obj)
        {
            _parts?.ForEach(p =>
            {
                p.GetOutlinePart.OutlineScale = string.Equals(p.GetOutlinePart.GetParentName, obj.name)
                    ? _outlineScale
                    : 0f;
            });
        }

        public void ResetOutline()
        {
            _parts?.ForEach(p => p.GetOutlinePart.OutlineScale = 0f);
        }
        
        public virtual string GetPartLocalizedText(BasePart obj)
        {
            return string.Empty;
        }

        private IEffect GetEffectByType(EffectType effectType)
        {
            if (_effects == null)
            {
                Debug.Log("[BaseInteractiveObject] Effect list is empty.");
                return null;
            }

            var effect = _effects.Find(e => e.EffectType == effectType);
            if (effect != null) return effect;
            
            Debug.Log("[BaseInteractiveObject] Specified effect not found.");
            return null;
        }

        public void PlayEffect(EffectType effectType)
        {
            var effect = GetEffectByType(effectType);
            if (effect == null || effect.Equals(null))
                return;
            
            effect.Play();
        }

        public void StopEffect(EffectType effectType)
        {
            var effect = GetEffectByType(effectType);
            if (effect == null || effect.Equals(null))
                return;
            
            effect.Stop();
        }
    }
}