using UnityEngine;

namespace Player.Inventories.Interfaces
{
    public interface IConsumableEffect
    {
        #region Methods

        bool TryConsume(GameObject user);

        #endregion
    }
}