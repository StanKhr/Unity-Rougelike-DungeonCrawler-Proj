using UnityEngine;

namespace UI.Utility
{
    public static class GameObjectExtensions
    {
        #region Methods

        public static void SetActiveSmart(this GameObject gameObject, bool active)
        {
            if (gameObject.activeSelf == active)
            {
                return;
            }
            
            gameObject.SetActive(active);
        }

        #endregion
    }
}