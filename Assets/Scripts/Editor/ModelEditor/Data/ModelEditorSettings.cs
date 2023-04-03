using UnityEngine;

namespace Editor.ModelEditor.Data
{
    [CreateAssetMenu(fileName = "ModelEditorSettings", menuName = "ModelEditor/ModelEditorSettings", order = 1)]
    public class ModelEditorSettings : ScriptableObject
    {
        [SerializeField] private string _modelsDataPath;
    }
}