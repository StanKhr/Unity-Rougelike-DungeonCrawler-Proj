using Abilities.Interfaces;
using Miscellaneous;
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

            colliderTrigger.OnEntered += context =>
                LogWriter.DevelopmentLog($"{context.name} enters trigger owned by {name}", LogType.Log, gameObject);
            colliderTrigger.OnLeft += context =>
                LogWriter.DevelopmentLog($"{context.name} leaves trigger owned by {name}", LogType.Log, gameObject);
        }
#endif

        #endregion
    }
}