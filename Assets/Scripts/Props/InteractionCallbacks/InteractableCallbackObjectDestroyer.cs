using Props.Interfaces;
using UnityEngine;

namespace Props.InteractionCallbacks
{
    public class InteractableCallbackObjectDestroyer : InteractableCallbacksComponent
    {
        #region Properties

        protected override bool UseStartCallback => true;

        #endregion

        #region Methods

        protected override void InteractionStartedCallback(GameObject context)
        {
            Destroy(gameObject);
        }

        #endregion
    }
}