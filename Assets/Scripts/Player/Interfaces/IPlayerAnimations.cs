namespace Player.Interfaces
{
    public interface IPlayerAnimations
    {
        #region Methods

        void ResetHandsAnimation();
        void PlayWeaponAttackCharge(float weaponAttackSpeed);
        void PlayWeaponAttackRelease();

        #endregion
    }
}