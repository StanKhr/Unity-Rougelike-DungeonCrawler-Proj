using UI.Utility;
using UnityEngine;
using UnityEngine.Pool;

namespace Miscellaneous.ObjectPooling
{
    public class ObjectPoolWrapper
    {
        #region Constants

        private const int DefaultCapacityValue = 10;
        private const int MaxSizeValue = 1000;

        #endregion

        #region Constructors

        public ObjectPoolWrapper(PooledObject prefabReference, int capacity = DefaultCapacityValue,
            int maxSize = MaxSizeValue)
        {
            _prefabReference = prefabReference;
            _pool = new ObjectPool<PooledObject>(CreateInstance, OnGet, OnRelease, OnDestroy, defaultCapacity: capacity,
                maxSize: maxSize);
        }

        #endregion

        #region Fields

        private readonly PooledObject _prefabReference;
        private readonly ObjectPool<PooledObject> _pool;

        #endregion

        #region Properties

        private IObjectPool<PooledObject> Pool => _pool;

        #endregion

        #region Public Methods

        public PooledObject Get()
        {
            return Pool.Get();
        }

        #endregion

        #region Methods

        protected virtual PooledObject CreateInstance()
        {
            var newInstance = Object.Instantiate(_prefabReference);
            newInstance.Pool = Pool;

            return newInstance;
        }

        protected virtual void OnDestroy(PooledObject obj)
        {
            Object.Destroy(obj.gameObject);
        }

        protected virtual void OnRelease(PooledObject obj)
        {
            obj.gameObject.SetActiveSmart(false);
        }

        protected virtual void OnGet(PooledObject obj)
        {
            obj.gameObject.SetActiveSmart(true);
        }

        #endregion
    }
}