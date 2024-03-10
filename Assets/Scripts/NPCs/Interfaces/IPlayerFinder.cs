namespace NPCs.Components.Interfaces
{
    public interface IPlayerFinder
    {
        #region Properties

        bool PlayerFound { get; }

        #endregion

        #region Methods

        void Tick(float deltaTime);

        #endregion
    }
}