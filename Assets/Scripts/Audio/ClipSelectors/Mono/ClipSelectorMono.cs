using System;
using Audio.Interfaces;
using UnityEngine;

namespace Audio.ClipSelectors.Mono
{
    [Obsolete]
    public abstract class ClipSelectorMono : MonoBehaviour, IClipSelector
    {
        #region Methods

        public abstract AudioClip Select();

        #endregion
    }
}