using Miscellaneous;
using Plugins.StanKhrEssentials.EventWrapper.Events;
using Plugins.StanKhrEssentials.EventWrapper.Interfaces;
using Plugins.StanKhrEssentials.EventWrapper.Main;
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