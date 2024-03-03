using System;
using Statuses.Interfaces;
using UnityEngine;

namespace Statuses.Feedbacks.Defence
{
    public abstract class DefenceFeedback : MonoBehaviour
    {
        #region Fields

        private IDefence _defence;

        #endregion
        
        #region Properties

        private IDefence Defence => _defence ??= GetComponent<IDefence>();

        #endregion

        #region Unity Callbacks

        private void OnEnable()
        {
            Defence.OnDamageAbsorbed += DamageAbsorbedCallback;
        }

        private void OnDisable()
        {
            Defence.OnDamageAbsorbed -= DamageAbsorbedCallback;
        }

        #endregion

        #region Methods

        protected abstract void DamageAbsorbedCallback();

        #endregion
    }
}