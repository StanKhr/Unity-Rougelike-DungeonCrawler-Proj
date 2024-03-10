namespace NPCs.Interfaces
{
    public interface IEnemyAnimations
    {
        #region Methods

        void PlayIdle();
        void PlayMovement();
        void PlayAttack();
        void PlayDeath();

        #endregion
    }
}