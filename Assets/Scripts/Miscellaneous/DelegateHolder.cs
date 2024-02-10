using UnityEngine;

namespace Miscellaneous
{
    public static class DelegateHolder
    {
        #region Delegates

        public delegate void GameObjectEvents(GameObject context);
        public delegate void ColliderEvents(Collider context);
        public delegate void FloatEvents(float context);

        #endregion
    }
}