using Audio.Triggers;
using Props.Interfaces;
using UnityEditor;
using UnityEngine;

namespace Audio.Editor
{
    [CustomEditor(typeof(AudioTriggerInteractable))]
    public class AudioTriggerInteractableEditor : UnityEditor.Editor
    {
        #region Unity Callbacks

        public override void OnInspectorGUI()
        {
            DrawHelpBox();
            base.OnInspectorGUI();
        }

        #endregion

        #region Methods

        private void DrawHelpBox()
        {
            if (target is not MonoBehaviour monoBehaviour)
            {
                return;
            }

            if (monoBehaviour.TryGetComponent<IInteractable>(out _))
            {
                return;
            }
            
            EditorGUILayout.HelpBox("This object should have a component with IInteractable implemented.\nOtherwise it will throw an exception", MessageType.Error);
        }

        #endregion
    }
}