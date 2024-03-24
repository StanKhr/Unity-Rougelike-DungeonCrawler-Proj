using Miscellaneous;
using Plugins.StanKhrEssentials.EventWrapper.Main;
using UnityEngine;

namespace Props.InteractionCallbacks
{
    public class InteractableCallbackObjectDestroyer : InteractableCallbacksComponent
    {
        #region Properties

        protected override bool UseStartCallback => true;

        #endregion

        #region Methods

        protected override void InteractionStartedCallback(Events.GameObjectEvent context)
        {
            Destroy(context.GameObject);
        }

        #endregion
    }
}