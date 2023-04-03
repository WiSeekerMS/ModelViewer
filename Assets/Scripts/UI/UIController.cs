using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private CanvasScaler _canvasScaler;
        [SerializeField] private InfoPanel _infoPanel;
        [SerializeField] private Toolbar _toolbar;
        
        public Canvas MainCanvas => _canvas;
        public Vector2 ReferenceResolution => _canvasScaler.referenceResolution;
        public InfoPanel InfoPanel => _infoPanel;
        public Toolbar Toolbar => _toolbar;

        private void Start()
        {
            _infoPanel.SetVisible = false;
        }
    }
}