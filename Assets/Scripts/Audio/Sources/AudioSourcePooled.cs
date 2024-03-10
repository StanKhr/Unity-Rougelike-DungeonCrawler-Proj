using System;
using Miscellaneous.ObjectPooling;
using UnityEngine;
using UnityEngine.Pool;

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