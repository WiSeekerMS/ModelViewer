using Common;
using UnityEngine;

namespace InteractiveObject
{
    [RequireComponent(typeof(MeshRenderer))]
    public class OutlinePart : MonoBehaviour
    {
        private MeshRenderer _meshRenderer;
        private string _parentName;

        public Material Material
        {
            get => _meshRenderer.material;
            set => _meshRenderer.material = value;
        }

        public float OutlineScale
        {
            get => Material.GetFloat(Constants.OutlineScalePropertyName);
            set => Material.SetFloat(Constants.OutlineScalePropertyName, value);
        }

        public string GetParentName => _parentName;

        private void Awake()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
            _parentName = transform.parent.name;
        }
    }
}