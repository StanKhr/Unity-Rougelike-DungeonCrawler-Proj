using Miscellaneous;
using Plugins.StanKhrEssentials.EventWrapper.Main;
using UnityEngine;

namespace Props.InteractionCallbacks
{
    public class InteractableCallbackObjectDisabler : InteractableCallbacksComponent
    {
        #region Properties

        protected override bool UseStartCallback => true;

        #endregion

        #region Methods

        protected override void InteractionStartedCallback(Events.GameObjectEvent context)
        {
            gameObject.SetActive(false);
        }

        #endregion
    }
}