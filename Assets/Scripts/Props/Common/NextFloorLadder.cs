using System;
using Miscellaneous;
using Props.Interfaces;
using Statuses.Interfaces;
using UnityEngine;

namespace Props.Common
{
    public class NextFloorLadder : Usable, IInteractable
    {
        #region Events

        public static event Action OnNextFloorTriggered;
        
        public event DelegateHolder.GameObjectEvents OnInteractionStarted;
        public event DelegateHolder.GameObjectEvents OnInteractionEnded;

        #endregion

        #region Methods

        protected override bool PerformUseLogic(GameObject user)
        {
            if (!user.TryGetComponent<IHealth>(out var health))
            {
                return false;
            }

            if (!health.Alive)
            {
                return false;
            }
            
            OnNextFloorTriggered?.Invoke();
            return true;
        }

        #endregion
    }
}