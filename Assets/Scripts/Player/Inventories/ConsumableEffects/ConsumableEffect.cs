using System;
using Player.Inventories.Interfaces;
using UnityEngine;
using UnityEngine.Localization;

namespace Player.Inventories.ConsumableEffects
{
    [Serializable]
    public abstract class ConsumableEffect : ScriptableObject, IConsumableEffect
    {
        #region Editor Fields

        [SerializeField] private LocalizedString _description;

        #endregion
        
        #region Methods

        public abstract bool TryConsume(GameObject user);
        public virtual string GetDescription()
        {
            return !_description.IsEmpty ? _description.GetLocalizedString() : string.Empty;
        }
        protected LocalizedString GetLocalizedString()
        {
            return _description;
        }

        #endregion

    }
}