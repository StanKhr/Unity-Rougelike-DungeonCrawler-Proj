using Miscellaneous.Interfaces;
using UnityEngine;

namespace Miscellaneous
{
    public class ForceApplierRigidbody : MonoBehaviour, IForceApplier
    {
        #region Editor Fields

        [SerializeField] private Rigidbody _rigidbody;

        #endregion
        
        #region Methods

        public void ApplyForce(Vector3 force)
        {
            _rigidbody.AddForce(force);
        }

        #endregion
    }
}