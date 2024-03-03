﻿using UnityEngine;

namespace Audio.Interfaces
{
    public interface IClipSelector
    {
        #region Methods

        AudioClip Select();
        bool TryPlayOneShot(AudioSource audioSource)
        {
            if (!audioSource)
            {
                return false;
            }
            
            var clip = Select();
            if (!clip)
            {
                return false;
            }

            audioSource.PlayOneShot(clip);
            return true;
        }

        bool TryPlayOneShotAtPosition(Vector3 position, float volume)
        {
            var clip = Select();
            if (!clip)
            {
                return false;
            }

            AudioSource.PlayClipAtPoint(clip, position, volume);
            return true;
        }

        #endregion
    }
}