using Audio.Interfaces;
using UnityEngine;

namespace Audio.ClipSelectors
{
    public abstract class ClipSelectorScriptable : ScriptableObject, IClipSelector
    {
        #region Methods

        public abstract AudioClip Select();

        #endregion
    }
}