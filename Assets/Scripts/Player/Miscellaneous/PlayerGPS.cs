using Player.Interfaces;
using UnityEngine;

namespace Player.Miscellaneous
{
    public class PlayerGps : MonoBehaviour, IPlayerGps
    {
        #region Properties

        public float X => transform.position.x;
        public float Y => transform.position.y;
        public float Z => transform.position.z;

        #endregion
    }
}