using Audio.Interfaces;
using UnityEngine;

namespace Audio.ClipSelectors.Scriptables
{
    public abstract class ClipSelectorScriptable : ScriptableObject, IClipSelector
    {
        #region Methods

        public abstract AudioClip Select();

        #endregion
    }
}