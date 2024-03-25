using Abilities.Interfaces;
using Plugins.StanKhrEssentials.Scripts.Utility;
using UnityEngine;

namespace Abilities.Triggers
{
    public class TriggerDebug : MonoBehaviour
    {
        #region Unity Callbacks

#if UNITY_EDITOR || DEVELOPMENT_BUILD
        private void Start()
        {
            if (!TryGetComponent<IColliderTrigger>(out var colliderTrigger))
            {
                return;
            }

            colliderTrigger.OnEntered.AddListener(context =>
                LogWriter.DevelopmentLog($"{context.Collider.name} enters trigger owned by {name}", LogType.Log, gameObject));
            colliderTrigger.OnLeft.AddListener(context =>
                LogWriter.DevelopmentLog($"{context.Collider.name} leaves trigger owned by {name}", LogType.Log, gameObject));
        }
#endif

        #endregion
    }
}