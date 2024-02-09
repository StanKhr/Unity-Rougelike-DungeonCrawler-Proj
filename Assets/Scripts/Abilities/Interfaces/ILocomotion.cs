using UnityEngine;

namespace Abilities.Interfaces
{
    public interface ILocomotion
    {
        #region Properties

        Vector3 Velocity { get; }

        #endregion
        
        #region Methods

        void ApplyJump();
        void SetTargetDirection(Vector3 targetDirection);
        void TickMovement(float deltaTime);

        #endregion
    }
}