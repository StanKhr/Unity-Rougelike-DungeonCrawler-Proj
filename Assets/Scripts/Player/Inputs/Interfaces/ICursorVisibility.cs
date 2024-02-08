namespace Player.Inputs.Interfaces
{
    public interface ICursorVisibility
    {
        #region Properties

        bool CursorVisible { get; }

        #endregion
        
        #region Methods

        void SetVisibility(bool visible);

        #endregion
    }
}