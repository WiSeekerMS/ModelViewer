﻿using System.Collections.Generic;
using System.Linq;
using Common.Localization;
using InteractiveObject.Interfaces;
using UnityEngine;

namespace InteractiveObject.Base
{
    public class BaseInteractiveObject : MonoBehaviour, IInteractiveObject
    {
        [SerializeField] protected LocalizedItem _modelName;
        [SerializeField] protected LocalizedItem _modelDescription;
        [SerializeField] protected GameObject _bodyFront;
        [SerializeField] protected Material _outlineMaterial;
        protected List<BasePart> _parts;
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

        private void OnEnable()
        {
            ResetOutline();
            ResetRotation();
            SetVisibilityBodyFront(true);
        }

        private void Start()
        {
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

        public void SetVisibilityBodyFront(bool isVisible)
        {
            _bodyFront.SetActive(isVisible);
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
            _parts
                ?.ForEach(p => p.GetOutlinePart.OutlineScale = 0f);
        }
        
        public virtual string GetPartLocalizedText(BasePart obj)
        {
            return string.Empty;
        }

        public virtual void StartAnimation()
        {
        }

        public virtual void StopAnimation()
        {
        }
    }
}