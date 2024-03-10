using System;
using UnityEngine;
using UnityEngine.Pool;

namespace Audio.Sources
{
    public class AudioSourcePooled : MonoBehaviour
    {
        #region Editor Fields

        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private float _maxLifeTime = 2f;

        #endregion

        #region Fields

        private float _lifeTimer;

        #endregion
        
        #region Properties
        
        public IObjectPool<AudioSourcePooled> Pool { get; set; }
        public AudioSource Source => _audioSource;

        #endregion

        #region Unity Callbacks

        private void OnEnable()
        {
            _lifeTimer = _maxLifeTime;
        }

        private void Update()
        {
            if (_lifeTimer > 0f)
            {
                _lifeTimer -= Time.deltaTime;
                return;
            }

            if (Pool == null)
            {
                Destroy(gameObject);
                return;
            }
            
            Pool.Release(this);
        }

        #endregion
    }
}