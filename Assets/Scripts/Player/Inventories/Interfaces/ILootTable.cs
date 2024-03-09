using UnityEngine;

namespace Player.Inventories.Interfaces
{
    public interface ILootTable
    {
        #region Methods

        IItem GetItem(GameObject user);

        #endregion
    }
}