using UnityEngine;

namespace Abilities.Interfaces
{
    public interface ILocomotion
    {
        #region Methods

        void SetMoveDirection(Vector3 direction);
        void TickMovement(float deltaTime);

        #endregion
    }
}