using System;
using UnityEngine;

namespace Abilities.Locomotion
{
    [Serializable]
    public class GroundScanner
    {
        #region Editor Fields

        [SerializeField] private Transform _groundScanDummy;
        [SerializeField] private LayerMask _walkableLayers;
        [SerializeField] private Vector3 _boxCastSize = Vector3.one * 0.5f;

        #endregion

        #region Fields

        private static readonly Collider[] ScanResult = new Collider[1];

        #endregion

        #region Properties

        #endregion

        #region Unity Callbacks

#if UNITY_EDITOR
        public void DrawGizmos()
        {
            if (!_groundScanDummy)
            {
                return;
            }

            Gizmos.color = Color.yellow;
            var center = CalculateCastCenter();
            Gizmos.DrawWireCube(center, _boxCastSize);
        }
#endif

        #endregion

        #region Methods

        public bool ScanForGround(out Collider groundCollision)
        {
            Array.Clear(ScanResult, 0, ScanResult.Length);

            var center = CalculateCastCenter();
            var grounded = Physics.OverlapBoxNonAlloc(center, _boxCastSize * 0.5f, ScanResult, 
                Quaternion.identity, _walkableLayers, QueryTriggerInteraction.Ignore) > 0;

            groundCollision = grounded ? ScanResult[0] : null;

            return grounded;
        }

        private Vector3 CalculateCastCenter()
        {
            return _groundScanDummy.position;
        }

        #endregion
    }
}