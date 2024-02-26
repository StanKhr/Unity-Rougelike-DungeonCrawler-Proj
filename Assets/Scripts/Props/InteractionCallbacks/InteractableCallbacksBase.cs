using Props.Interfaces;
using UnityEngine;

namespace Props.InteractionCallbacks
{
    public abstract class InteractableCallbacksBase : MonoBehaviour
    {
        #region Properties

        protected virtual bool UseStartCallback => false;
        protected virtual bool UseEndCallback => false;
        protected abstract IInteractable Interactable { get; }

        #endregion

        #region Unity Callbacks

        protected virtual void OnEnable()
        {
            if (UseStartCallback)
            {
                Interactable.OnInteractionStarted += InteractionStartedCallback;
            }

            if (UseEndCallback)
            {
                Interactable.OnInteractionEnded += InteractionEndedCallback;
            }
        }

        protected virtual void OnDisable()
        {
            if (UseStartCallback)
            {
                Interactable.OnInteractionStarted -= InteractionStartedCallback;
            }

            if (UseEndCallback)
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