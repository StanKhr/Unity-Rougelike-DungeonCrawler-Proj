using System;
using UnityEditor;
using UnityEngine;
using WorldGeneration.Generators;

namespace WorldGeneration.Editor
{
    [CustomEditor(typeof(LevelGenerator), true)]
    public class LevelGeneratorEditor : UnityEditor.Editor
    {
        #region Unity Callbacks

        public override void OnInspectorGUI()
        {
            // serializedObject.Update();
            // DrawSeedGenerateButton();
            // serializedObject.ApplyModifiedProperties();
            base.OnInspectorGUI();
        }

        #endregion
        
        #region Methods

        // private void DrawSeedGenerateButton()
        // {
        //     if (!GUILayout.Button("Generate new Seed"))
        //     {
        //         return;
        //     }
        //
        //     var seedProperty = serializedObject.FindProperty("_randomSeed");
        //     var guidHash = GUID.Generate().GetHashCode();
        //     
        //     seedProperty.intValue = guidHash;
        // }

        #endregion
    }
}