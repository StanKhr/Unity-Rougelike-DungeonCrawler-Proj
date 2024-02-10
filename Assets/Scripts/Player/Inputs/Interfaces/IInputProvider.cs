namespace Player.Inputs.Interfaces
{
    public interface IInputProvider
    {
        #region Properties

        IMapWrapperCamera MapWrapperCamera { get; }
        IMapWrapperMovement MapWrapperMovement { get; }
        ICursorVisibility CursorVisibility { get; }

        #endregion
    }
}