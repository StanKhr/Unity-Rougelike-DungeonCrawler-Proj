namespace Player.Inputs.Interfaces
{
    public interface IInputProvider
    {
        #region Properties

        IMapWrapperCamera Camera { get; }
        IMapWrapperMovement Movement { get; }
        IMapWrapperAbilities Abilities { get; }
        IMapWrapperUtility Utility { get; }
        ICursorVisibility CursorVisibility { get; }

        #endregion
    }
}