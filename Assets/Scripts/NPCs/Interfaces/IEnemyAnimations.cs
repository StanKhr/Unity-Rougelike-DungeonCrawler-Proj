namespace NPCs.Interfaces
{
    public interface IEnemyAnimations
    {
        #region Methods

        void SetLocomotionVelocity(float velocity);
        void PlayAttack();
        void PlayDeath();

        #endregion
    }
}