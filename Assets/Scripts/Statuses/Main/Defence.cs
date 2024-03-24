using Plugins.StanKhrEssentials.EventWrapper.Interfaces;
using Plugins.StanKhrEssentials.EventWrapper.Main;
using Statuses.Datas;
using Statuses.Interfaces;

namespace Statuses.Main
{
    public class Defence : Status, IDefence
    {
        #region Events

        public IEvent OnDamageAbsorbed { get; } = EventFactory.CreateEvent();

        #endregion
        
        #region Methods

        public bool TryAbsorbDamage(Damage damage, out float remainingDamageValue)
        {
            if (damage.Value <= CurrentValue)
            {
                remainingDamageValue = 0f;
                
                OnDamageAbsorbed?.NotifyListeners();
                return true;
            }

            remainingDamageValue = damage.Value - CurrentValue;

            return false;
        }

        #endregion
    }
}