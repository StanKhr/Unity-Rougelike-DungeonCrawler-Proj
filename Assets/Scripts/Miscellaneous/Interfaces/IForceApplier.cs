using UnityEngine;

namespace Miscellaneous.Interfaces
{
    public interface IForceApplier
    {
        #region Methods

        void ApplyForce(Vector3 force);

        #endregion
    }
}