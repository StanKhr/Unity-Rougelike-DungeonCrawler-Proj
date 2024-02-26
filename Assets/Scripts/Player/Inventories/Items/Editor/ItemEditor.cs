using UnityEditor;
using UnityEngine;

namespace Player.Inventories.Items.Editor
{
    [CustomEditor(typeof(Item), true)]
    public class ItemEditor : UnityEditor.Editor
    {
        #region Methods

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            CheckGuid();
            DrawGuid();
            serializedObject.ApplyModifiedProperties();
            
            base.OnInspectorGUI();
        }

        private void CheckGuid()
        {
            if (Application.isPlaying)
            {
                return;
            }

            var guid = serializedObject.FindProperty("_guid");
            if (!string.IsNullOrEmpty(guid.stringValue))
            {
                return;
            }

            guid.stringValue = GenerateGuid();
        }

        private void DrawGuid()
        {
            var guid = serializedObject.FindProperty("_guid");
            EditorGUILayout.BeginVertical("Box");
            
            if (GUILayout.Button("Generate new GUID"))
            {
                guid.stringValue = GenerateGuid();
            }
            guid.stringValue = EditorGUILayout.TextField("GUID", guid.stringValue);
            
            EditorGUILayout.EndVertical();
        }

        private string GenerateGuid()
        {
            return GUID.Generate().ToString();
        }

        #endregion
    }
}