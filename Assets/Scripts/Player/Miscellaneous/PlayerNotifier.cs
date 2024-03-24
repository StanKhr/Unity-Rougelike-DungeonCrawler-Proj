using Miscellaneous.EventWrapper.Events;
using Miscellaneous.EventWrapper.Interfaces;
using Miscellaneous.EventWrapper.Main;
using UnityEngine;

namespace Player.Miscellaneous
{
    public class PlayerNotifier : MonoBehaviour
    {
        #region Events

        public static IContextEvent<Events.GameObjectEvent> OnPlayerLoaded { get; } =
            new ContextEvent<Events.GameObjectEvent>();

        #endregion

        #region Unity Callbacks

        private void Start()
        {
            OnPlayerLoaded?.NotifyListeners(new Events.GameObjectEvent
            {
                GameObject = gameObject
            });
        }

        #endregion
    }
}