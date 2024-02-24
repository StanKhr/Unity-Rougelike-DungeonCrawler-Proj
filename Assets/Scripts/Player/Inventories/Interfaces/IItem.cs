using UnityEngine;
using UnityEngine.Localization;

namespace Player.Inventories.Interfaces
{
    public interface IItem
    {
        #region Properties

        string Guid { get; }
        Sprite Icon { get; }
        LocalizedString Name { get; }
        LocalizedString FlavorText { get; }
        string CombinedDescription { get; }

        #endregion
    }
}