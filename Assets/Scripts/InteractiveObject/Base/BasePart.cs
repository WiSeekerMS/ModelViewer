﻿using System.Collections.Generic;
using Common.Localization;
using InteractiveObject.Part;
using InteractiveObject.Part.Interfaces;
using UnityEngine;

namespace InteractiveObject.Base
{
    public class BasePart : MonoBehaviour, IOutline, ILocalizable, IDecomposable
    {
        [SerializeField] private List<MeshRenderer> _renderers;
        [SerializeField] private OutlinePart _outlinePart;
        [SerializeField] private LocalizedItem _localizedItem;
        [SerializeField] private Vector3 _decomposeLocalPosition;
        [SerializeField] private Vector3 _decomposeLocalRotate;
        [SerializeField] private bool _isHideWhenDecomposing;
        private Vector3 _defaultLocalPosition;
        private Quaternion _defaultLocalRotate;
        
        public bool Visibility
        {
            get => gameObject.activeSelf;
            set => gameObject.SetActive(value);
        }

        public bool EnableRenderers
        {
            set => _renderers.ForEach(r => r.enabled = value);
        }

        public bool IsHideWhenDecomposing => _isHideWhenDecomposing;
        public OutlinePart GetOutlinePart => _outlinePart;
        public LocalizedItem GetLocalizedItem => _localizedItem;
        public Vector3 GetDefaultLocalPosition => _defaultLocalPosition;
        public Quaternion GetDefaultLocalRotate => _defaultLocalRotate;
        public Vector3 GetTargetLocalPosition => _decomposeLocalPosition;
        public Quaternion GetTargetLocalRotate => Quaternion.Euler(_decomposeLocalRotate);

        private void Awake()
        {
            _defaultLocalPosition = transform.localPosition;
            _defaultLocalRotate = transform.localRotation;
        }
    }
}