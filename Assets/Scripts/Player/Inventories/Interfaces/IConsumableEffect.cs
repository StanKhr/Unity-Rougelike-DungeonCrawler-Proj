using UnityEngine;
using UnityEngine.Localization;

namespace Player.Inventories.Interfaces
{
    public interface IConsumableEffect
    {
        #region Methods

        bool TryConsume(GameObject user);
        string GetDescription();

        #endregion
    }
}