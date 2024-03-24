using System;
using Miscellaneous;
using Plugins.StanKhrEssentials.EventWrapper.Interfaces;
using Plugins.StanKhrEssentials.EventWrapper.Main;
using Statuses.Datas;
using Statuses.Interfaces;
using UnityEngine;

namespace Statuses.Main
{
    public class Health : Status, IHealth, IDamageable
    {
        #region Events

        public IEvent OnDied { get; } = EventFactory.CreateEvent();
        public IEvent OnResurrected { get; } = EventFactory.CreateEvent();
        public IContextEvent<EventContext.FloatEvent> OnDamaged { get; } =
            EventFactory.CreateContextEvent<EventContext.FloatEvent>();
        
        #endregion

        #region Properties

        public override float CurrentValue
        {
            get => base.CurrentValue;
            protected set
            {
                var previousValue = CurrentValue;
                base.CurrentValue = value;

                var healthDifference = previousValue - CurrentValue;
                if (Math.Abs(previousValue - CurrentValue) <= 0f)
                {
                    return;
                }
                
                if (CurrentValue > previousValue)
                {
                    if (previousValue <= 0f)
                    {
                        OnResurrected?.NotifyListeners();
                        return;
                    }
                    
                    return;
                }

                OnDamaged?.NotifyListeners(new EventContext.FloatEvent
                {
                    Float = healthDifference
                });
                
                if ((this as IHealth).Alive)
                {
                    return;
                }
                
                OnDied?.NotifyListeners();
            }
        }

        #endregion

        #region Methods

#if UNITY_EDITOR
        [ContextMenu("Test Add Health (20)")]
        private void TestAddHealth()
        {
            CurrentValue += 20;
        }
#endif

        public bool TryApplyDamage(Damage damage)
        {
            if (!(this as IHealth).Alive)
            {
                return false;
            }

            if (TryGetComponent<IDefence>(out var defence))
            {
                if (defence.TryAbsorbDamage(damage, out var remainingDamageValue))
                {
                    return false;
                }

                damage.Value = remainingDamageValue;
            }

            CurrentValue -= damage.Value;

            return true;
        }

        public bool TryHeal(float healValue)
        {
            if (!(this as IHealth).Alive)
            {
                return false;
            }
            
            CurrentValue += healValue;

            return true;
        }

        public void Resurrect()
        {
            CurrentValue = MaxValue;
        }

        public void Kill()
        {
            if (!(this as IHealth).Alive)
            {
                return;
            }
            
            CurrentValue = 0f;
        }

        #endregion
    }
}