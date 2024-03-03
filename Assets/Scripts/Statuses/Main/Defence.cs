using System;
using Statuses.Datas;
using Statuses.Interfaces;

namespace Statuses.Main
{
    public class Defence : Status, IDefence
    {
        #region Events

        public event Action OnDamageAbsorbed;

        #endregion
        
        #region Methods

        public bool TryAbsorbDamage(Damage damage, out float remainingDamageValue)
        {
            if (damage.Value <= CurrentValue)
            {
                remainingDamageValue = 0f;
                
                OnDamageAbsorbed?.Invoke();
                return true;
            }

            remainingDamageValue = damage.Value - CurrentValue;

            return false;
        }

        #endregion
    }
}