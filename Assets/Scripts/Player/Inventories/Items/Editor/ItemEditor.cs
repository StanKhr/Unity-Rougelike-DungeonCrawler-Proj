using Player.Inventories.Interfaces;
using UnityEditor;
using UnityEngine;

namespace Player.Inventories.Items.Editor
{
    [CustomEditor(typeof(Item), true)]
    public class ItemEditor : UnityEditor.Editor
    {
        #region Constants

        private const float SecondSpeedValue = 60;

        #endregion

        #region Unity Callbacks

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            CheckGuid();
            DrawGuid();

            serializedObject.ApplyModifiedProperties();

            base.OnInspectorGUI();

            if (target is IWeapon weapon)
            {
                DrawWeaponStuff(weapon);
            }
        }

        #endregion

        #region Methods

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

        private void DrawWeaponStuff(IWeapon weapon)
        {
            var averageDamage = weapon.DamageValue * (weapon.SpeedValue / SecondSpeedValue);
            var critDamage = averageDamage * weapon.CritDamageMultiplier;

            EditorGUILayout.HelpBox($"Average DPS: {averageDamage.ToString("F1")} - {critDamage.ToString("F1")}",
                MessageType.Info);
        }

        private string GenerateGuid()
        {
            return GUID.Generate().ToString();
        }

        #endregion
    }
}