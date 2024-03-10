using Miscellaneous.ObjectPooling;
using UnityEngine;

namespace Miscellaneous.WorldAttackCallbacks
{
    public class WorldAttackParticle : PooledObject
    {
        #region Editor Fields

        [SerializeField] private AudioSource _audioSource;

        #endregion
        
        #region Methods

        public void TriggerAudio(AudioClip selectNext)
        {
            if (!selectNext)
            {
                return;
            }
            
            _audioSource.PlayOneShot(selectNext);
        }

        #endregion
    }
}