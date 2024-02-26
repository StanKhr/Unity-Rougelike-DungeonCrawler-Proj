using Props.Interfaces;

namespace Props.InteractionCallbacks
{
    public abstract class InteractableCallbacksComponent : InteractableCallbacksBase
    {
        #region Fields

        private IInteractable _interactable;

        #endregion

        #region Properties

        protected override IInteractable Interactable => _interactable ??= GetComponent<IInteractable>();

        #endregion
    }
}