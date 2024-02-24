using Props.Interfaces;
using UnityEngine;

namespace Props.InteractionCallbacks
{
    public abstract class InteractableCallbacksBase : MonoBehaviour
    {
        #region Properties

        protected virtual bool UseInteractionStarted => false;
        protected virtual bool UseInteractionEnded => false;
        protected abstract IInteractable Interactable { get; }

        #endregion

        #region Unity Callbacks

        protected virtual void OnEnable()
        {
            if (UseInteractionStarted)
            {
                Interactable.OnInteractionStarted += InteractionStartedCallback;
            }

            if (UseInteractionEnded)
            {
                Interactable.OnInteractionEnded += InteractionEndedCallback;
            }
        }

        protected virtual void OnDisable()
        {
            if (UseInteractionStarted)
            {
                Interactable.OnInteractionStarted -= InteractionStartedCallback;
            }

            if (UseInteractionEnded)
            {
                Interactable.OnInteractionEnded -= InteractionEndedCallback;
            }
        }

        protected virtual void InteractionEndedCallback(GameObject context)
        {
            
        }

        protected virtual void InteractionStartedCallback(GameObject context)
        {
            
        }

        #endregion
    }
}