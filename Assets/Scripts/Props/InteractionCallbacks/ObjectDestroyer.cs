using Props.Interfaces;
using UnityEngine;

namespace Props.InteractionCallbacks
{
    public class ObjectDestroyer : InteractableCallbacksBase
    {
        #region Fields

        private IInteractable _interactable;

        #endregion
        
        #region Properties

        protected override bool UseInteractionStarted => true;
        protected override IInteractable Interactable => _interactable;

        #endregion

        #region Unity Callbacks

        protected override void OnEnable()
        {
            _interactable = GetComponent<IInteractable>();
            base.OnEnable();
        }

        #endregion

        #region Methods

        protected override void InteractionStartedCallback(GameObject context)
        {
            Destroy(gameObject);
        }

        #endregion
    }
}