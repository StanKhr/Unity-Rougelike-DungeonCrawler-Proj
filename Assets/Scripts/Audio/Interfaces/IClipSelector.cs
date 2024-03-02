using UnityEngine;

namespace Audio.Interfaces
{
    public interface IClipSelector
    {
        #region Methods

        AudioClip Select();
        bool TryOneShotAudioSource(AudioSource audioSource)
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

        #endregion
    }
}