using Player.Interfaces;

namespace Statuses.Main
{
    public class HealthPlayer : Health
    {
        #region Methods

        protected override float GetBaseValue()
        {
            return Personality.Active.Health;
        }

        #endregion
    }
}