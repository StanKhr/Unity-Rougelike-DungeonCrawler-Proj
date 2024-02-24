using UnityEngine;

namespace UI.Utility
{
    public static class MonoBehaviourExtensions
    {
        #region Methods

        public static void ActivateObjectSelf(this MonoBehaviour monoBehaviour, bool activate)
        {
            var gameObject = monoBehaviour.gameObject;
            if (gameObject.activeSelf == activate)
            {
                return;
            }
            
            gameObject.SetActive(activate);
        }

        #endregion
    }
}