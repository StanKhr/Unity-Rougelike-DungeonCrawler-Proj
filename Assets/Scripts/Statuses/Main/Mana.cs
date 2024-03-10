using Player.Interfaces;
using Statuses.Interfaces;

namespace Statuses.Main
{
    public class Mana : Status, IMana
    {
        #region Methods

        protected override float GetBaseValue()
        {
            return Personality.Active.Mana;
        }

        #endregion
    }
}