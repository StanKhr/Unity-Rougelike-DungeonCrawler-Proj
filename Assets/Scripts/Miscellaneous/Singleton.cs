using UnityEngine;

namespace Miscellaneous
{
    public abstract class Singleton<T> : MonoBehaviour where T : Component
    {
        #region Fields

        public static T Instance { get; private set; }

        #endregion

        #region Unity Callbacks

        protected virtual void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this as T;
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
        }

        #endregion
    }
}