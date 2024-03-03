using UnityEngine;

namespace Props.InteractionCallbacks
{
    public class InteractableCallbackObjectDisabler : InteractableCallbacksComponent
    {
        #region Properties

        protected override bool UseStartCallback => true;

        #endregion

        #region Methods

        protected override void InteractionStartedCallback(GameObject context)
        {
            gameObject.SetActive(false);
        }

        #endregion
    }
}