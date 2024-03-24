using Miscellaneous;

namespace Props.InteractionCallbacks
{
    public class InteractableCallbackObjectDisabler : InteractableCallbacksComponent
    {
        #region Properties

        protected override bool UseStartCallback => true;

        #endregion

        #region Methods

        protected override void InteractionStartedCallback(EventContext.GameObjectEvent context)
        {
            gameObject.SetActive(false);
        }

        #endregion
    }
}