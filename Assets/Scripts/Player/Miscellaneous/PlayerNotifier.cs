using System;
using Miscellaneous;
using UnityEngine;

namespace Player.Miscellaneous
{
    public class PlayerNotifier : MonoBehaviour
    {
        #region Events

        public static event DelegateHolder.GameObjectEvents OnPlayerLoaded;

        #endregion

        #region Unity Callbacks

        private void Start()
        {
            OnPlayerLoaded?.Invoke(gameObject);
        }

        #endregion
    }
}