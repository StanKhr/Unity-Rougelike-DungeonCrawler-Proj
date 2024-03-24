using Miscellaneous.ObjectPooling;
using UnityEngine;

namespace Audio.Sources
{
    public class AudioSourcePooled : PooledObject
    {
        #region Editor Fields

        [SerializeField] private AudioSource _audioSource;

        #endregion
        
        #region Properties
        
        public AudioSource Source => _audioSource;

        #endregion
    }
}