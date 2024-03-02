using Audio.Interfaces;
using UnityEngine;

namespace Audio.ClipSelectors
{
    public abstract class ClipSelectorMono : MonoBehaviour, IClipSelector
    {
        #region Methods

        public abstract AudioClip Select();

        #endregion
    }
}