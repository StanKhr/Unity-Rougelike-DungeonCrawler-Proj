using UnityEngine;

namespace Miscellaneous
{
    public static class TransformExtensions
    {
        #region Methods

        public static void SetPositionSmart(this Transform transform, Vector3 position)
        {
            if ((transform.position - position).sqrMagnitude <= 0f)
            {
                return;
            }

            transform.position = position;
        }

        #endregion
    }
}