namespace Player.Interfaces
{
    public interface IPlayerAnimations
    {
        #region Methods

        void PlayHandsIdleLoop();
        void PlayWeaponAttackCharge(float weaponAttackSpeed);
        void PlayWeaponAttackRelease();

        #endregion
    }
}