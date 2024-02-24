using UnityEngine;

namespace Player.Inventories.Interfaces
{
    public interface IItem
    {
        #region Properties

        string Guid { get; }
        Sprite Icon { get; }
        string Name { get; }
        string FlavorText { get; }
        string CombinedDescription { get; }

        #endregion
    }
}