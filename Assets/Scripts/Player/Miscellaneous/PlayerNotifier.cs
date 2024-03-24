using Miscellaneous;
using Plugins.StanKhrEssentials.EventWrapper.Interfaces;
using Plugins.StanKhrEssentials.EventWrapper.Main;
using UnityEngine;

namespace Player.Miscellaneous
{
    public class PlayerNotifier : MonoBehaviour
    {
        #region Events

        public static IContextEvent<EventContext.GameObjectEvent> OnPlayerLoaded { get; } =
            EventFactory.CreateContextEvent<EventContext.GameObjectEvent>();

        #endregion

        #region Unity Callbacks

        private void Start()
        {
            OnPlayerLoaded?.NotifyListeners(new EventContext.GameObjectEvent
            {
                GameObject = gameObject
            });
        }

        #endregion
    }
}