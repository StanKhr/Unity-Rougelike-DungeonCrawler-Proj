using System;
using UnityEngine;
using UnityEngine.Pool;

namespace Miscellaneous.ObjectPooling
{
    public class PooledObject : MonoBehaviour
    {
        #region Editor Fields

        [SerializeField] private float _lifetime = 2f;

        #endregion

        #region Fields

        private float _releaseTimer = 0f;

        #endregion

        #region Properties

        public IObjectPool<PooledObject> Pool { private get; set; } 

        #endregion
        
        #region Unity Callbacks

        private void OnEnable()
        {
            _releaseTimer = _lifetime;
        }

        private void Update()
        {
            if (_releaseTimer > 0f)
            {
                _releaseTimer -= Time.deltaTime;
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