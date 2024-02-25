using System;
using Player.Inventories.Interfaces;
using UnityEngine;

namespace Player.Inventories.ConsumableEffects
{
    [Serializable]
    public abstract class ConsumableEffect : ScriptableObject, IConsumableEffect
    {
        #region Methods

        public abstract bool TryConsume(GameObject user);
        
        #endregion
        
    }
}