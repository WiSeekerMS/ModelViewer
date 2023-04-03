using UnityEditor;
using UnityEngine;

namespace Editor.ModelEditor.Views
{
    public class OpenEditorView
    {
        private static Vector2 _windowsMinSize = new Vector2(500f, 500f);
        
        [MenuItem("Tools/Model Editor")]
        public static void ShowWindow()
        {
            var window = EditorWindow.GetWindow<ModelEditorWindow>();
            window.titleContent = new GUIContent("Model Editor");
            window.minSize = _windowsMinSize;
            window.Focus();
            window.OnInit();
        }
    }
}