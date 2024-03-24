using Miscellaneous.EventWrapper.Main;
using UnityEngine;

namespace Props.InteractionCallbacks
{
    public class InteractableCallbackSpriteColorChanger : InteractableCallbacksComponent
    {
        #region Editor Fields

        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Color _interactColor = new Color(1f, 1f, 1f, 1f);

        #endregion
        
        #region Properties

        protected override bool UseStartCallback => true;

        #endregion
        
        #region Methods

        protected override void InteractionStartedCallback(Events.GameObjectEvent context)
        {
            _spriteRenderer.color = _interactColor;
        }

        #endregion
    }
}