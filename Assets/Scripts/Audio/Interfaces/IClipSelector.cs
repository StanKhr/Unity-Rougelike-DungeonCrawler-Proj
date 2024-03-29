﻿using UnityEngine;

namespace Audio.Interfaces
{
    public interface IClipSelector
    {
        #region Constants

        private const float BaseVolume = 1.0f;

        #endregion
        
        #region Methods

        AudioClip SelectNext();
        bool TryOneShotOnAudioSource(AudioSource audioSource, float volume = BaseVolume)
        {
            if (!audioSource)
            {
                return false;
            }
            
            var clip = SelectNext();
            if (!clip)
            {
                return false;
            }

            audioSource.PlayOneShot(clip, volume);
            return true;
        }

        // bool TryOneShotAtPosition(Vector3 position, float volume = BaseVolume)
        // {
        //     var clip = SelectNext();
        //     if (!clip)
        //     {
        //         return false;
        //     }
        //
        //     AudioSource.PlayClipAtPoint(clip, position, volume);
        //     return true;
        // }

        #endregion
    }
}