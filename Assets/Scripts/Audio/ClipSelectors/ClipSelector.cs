using UnityEngine;

namespace Audio.ClipSelectors
{
    public abstract class ClipSelector : MonoBehaviour
    {
        #region Methods

        public abstract AudioClip Select();
        public bool TryOneShotAudioSource(AudioSource audioSource)
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