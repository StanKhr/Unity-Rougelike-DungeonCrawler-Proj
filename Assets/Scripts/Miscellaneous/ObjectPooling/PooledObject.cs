using Player.Interfaces;
using Player.Miscellaneous;
using UnityEngine;
using UnityEngine.Pool;

namespace Miscellaneous.ObjectPooling
{
    public abstract class PooledObject : MonoBehaviour
    {
        #region Editor Fields

        [SerializeField] private TimerComponent _selfDestroyTimer;

        #endregion

        #region Properties

        public IObjectPool<PooledObject> Pool { private get; set; } 
        public ITimer SelfDestroyTimer => _selfDestroyTimer;

        #endregion
        
        #region Unity Callbacks

        protected virtual void OnEnable()
        {
            SelfDestroyTimer.OnTimerEnded.AddListener(TimerEndedCallback);
            SelfDestroyTimer.TryStart();
        }

        protected virtual void OnDisable()
        {
            SelfDestroyTimer.OnTimerEnded.RemoveListener(TimerEndedCallback);
        }

        #endregion

        #region Methods
        
        private void TimerEndedCallback()
        {
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