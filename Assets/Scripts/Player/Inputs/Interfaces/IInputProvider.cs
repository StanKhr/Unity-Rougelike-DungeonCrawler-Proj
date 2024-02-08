namespace Player.Inputs.Interfaces
{
    public interface IInputProvider
    {
        #region Properties

        IMapWrapperCamera MapWrapperCamera { get; }
        ICursorVisibility CursorVisibility { get; }

        #endregion
    }
}