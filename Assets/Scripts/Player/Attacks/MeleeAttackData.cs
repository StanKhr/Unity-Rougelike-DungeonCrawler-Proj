using Player.Inventories.Interfaces;

namespace Player.Attacks
{
    public struct MeleeAttackData
    {
        #region Constructors

        public MeleeAttackData(IWeapon weapon, float critChangePercentage)
        {
            Weapon = weapon;
            CritChangePercentage = critChangePercentage;
        }

        #endregion
        
        #region Properties

        public IWeapon Weapon { get; }
        public float CritChangePercentage { get; }

        #endregion
    }
}