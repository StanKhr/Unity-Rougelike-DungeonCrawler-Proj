using System;
using Audio.Interfaces;
using UnityEngine;

namespace Audio.ClipSelectors.Pure
{
    [Serializable]
    public class ClipSelectorPure : IClipSelector
    {
        #region Editor Fields

        [SerializeField] private AudioClip _audioClip;

        #endregion        
        
        #region Methods

        public virtual AudioClip Select()
        {
            return _audioClip;
        }

        #endregion
    }
}