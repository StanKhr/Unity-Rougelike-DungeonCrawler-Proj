using Audio.Sources;
using UI.Utility;
using UnityEngine;
using UnityEngine.Pool;

namespace Audio.Triggers
{
    public abstract class AudioTriggerPooing : MonoBehaviour
    {
        #region Editor Fields

        [SerializeField] private AudioSourcePooled _audioSourcePooledPrefab;

        #endregion
        
        #region Fields

        private ObjectPool<AudioSourcePooled> _objectPool;

        #endregion

        #region Properties
        
        protected IObjectPool<AudioSourcePooled> Pool
        {
            get
            {
                if (_objectPool != null)
                {
                    return _objectPool;
                }

                _objectPool = new ObjectPool<AudioSourcePooled>(CreateItem, OnGetItem, OnReleaseItem, OnDestroyItem);

                return _objectPool;
            }
        }

        #endregion

        #region Methods
        
        private AudioSourcePooled CreateItem()
        {
            var instance = Instantiate(_audioSourcePooledPrefab);
            instance.Pool = Pool;

            return instance;
        }

        private void OnGetItem(AudioSourcePooled source)
        {
            source.gameObject.SetActive(true);
        }

        private void OnReleaseItem(AudioSourcePooled source)
        {
            source.gameObject.SetActive(false);
        }
        private void OnDestroyItem(AudioSourcePooled source)
        {
            Destroy(source.gameObject);
        }

        #endregion
    }
}