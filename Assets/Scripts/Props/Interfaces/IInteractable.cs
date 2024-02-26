using Miscellaneous;

namespace Props.Interfaces
{
    public interface IInteractable
    {
        #region Events

        event DelegateHolder.GameObjectEvents OnInteractionStarted;
        event DelegateHolder.GameObjectEvents OnInteractionEnded;

        #endregion
    }
}