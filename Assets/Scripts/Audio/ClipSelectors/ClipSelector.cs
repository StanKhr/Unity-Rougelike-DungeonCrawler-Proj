using Audio.Interfaces;
using UnityEngine;

namespace Audio.ClipSelectors
{
    public abstract class ClipSelector : ScriptableObject, IClipSelector
    {
        #region Methods

        public abstract AudioClip SelectNext();

        #endregion
    }
}