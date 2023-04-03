using Editor.ModelEditor.Installers;
using UnityEditor;
using Zenject;

namespace Editor.ModelEditor.Views
{
    public class ModelEditorWindow : ZenjectEditorWindow
    {
        private SerializedObject _serializedObject;
        private SerializedProperty _inventory;
        private DrawingPalette _drawingPalette;

        public override void InstallBindings()
        {
            Container.Install<ModelEditorInstaller>();
        }

        [Inject]
        public void Construct()
        {
        }

        public void OnInit()
        {
            _drawingPalette = new DrawingPalette();
        }

        private void OnDestroy()
        {
            _serializedObject?.Dispose();
        }

        public override void OnGUI()
        {
            _drawingPalette.DrawWindowElements(position);
            //_serializedObject?.ApplyModifiedProperties();
        }

        #region EventsHandlers
        #endregion
    }
}