using System;
using Audio.ClipSelectors;
using Audio.Interfaces;
using Player.Interfaces;
using UnityEngine;

namespace Audio.Triggers
{
    public class AudioTriggerEndlessLoop : AudioTrigger
    {
        #region Editor Fields

        [SerializeField] private ClipSelectorScriptable _clipSelector;

        #endregion

        #region Properties

        private IClipSelector ClipSelector => _clipSelector;

        #endregion

        #region Unity Callbacks

        private void Update()
        {
            if (AudioSource.isPlaying)
            {
                return;
            }

            var clip = ClipSelector.SelectNext();
            AudioSource.clip = clip;
            AudioSource.Play();
        }

        #endregion
    }
}