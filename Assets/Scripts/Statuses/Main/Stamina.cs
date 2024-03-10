using Statuses.Interfaces;
using UnityEngine;

namespace Statuses.Main
{
    public class Stamina : Status, IStamina
    {
        #region Editor Fields

        [SerializeField] private float _regenerateDelaySeconds = 0.5f;
        [SerializeField, Range(0f, 1f)] private float _rechargePercentPerSec = 0.01f;

        #endregion
        
        #region Fields

        private float _delayTimer;

        #endregion

        #region Properties

        // protected override bool EventNotificationEnabled => false;

        #endregion
        
        #region Methods

        public bool TryDecrease(float value)
        {
            if (CurrentValue <= 0f)
            {
                return false;
            }

            CurrentValue -= value;
            _delayTimer = _regenerateDelaySeconds;

            return true;
        }

        public void Tick(float deltaTime)
        {
            if (_delayTimer > 0f)
            {
                _delayTimer -= deltaTime;
                return;
            }

            if (CurrentValue >= MaxValue)
            {
                return;
            }

            CurrentValue += MaxValue * _rechargePercentPerSec * deltaTime;
        }

        #endregion
    }
}