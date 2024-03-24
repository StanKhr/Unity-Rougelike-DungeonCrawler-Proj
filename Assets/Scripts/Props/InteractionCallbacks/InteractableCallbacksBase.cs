using Miscellaneous;
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
                Interactable.OnInteractionStarted.AddListener(InteractionStartedCallback);
            }

            if (UseEndCallback)
            {
                Interactable.OnInteractionEnded.AddListener(InteractionEndedCallback);
            }
        }

        protected virtual void OnDisable()
        {
            if (UseStartCallback)
            {
                Interactable.OnInteractionStarted.RemoveListener(InteractionStartedCallback);
            }

            if (UseEndCallback)
            {
                Interactable.OnInteractionEnded.RemoveListener(InteractionEndedCallback);
            }
        }

        protected virtual void InteractionEndedCallback(EventContext.GameObjectEvent context)
        {
            
        }

        protected virtual void InteractionStartedCallback(EventContext.GameObjectEvent context)
        {
            
        }

        #endregion
    }
}