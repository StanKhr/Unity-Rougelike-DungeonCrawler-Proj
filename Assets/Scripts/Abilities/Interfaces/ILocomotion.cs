using UnityEngine;

namespace Abilities.Interfaces
{
    public interface ILocomotion
    {
        #region Properties

        bool Grounded { get; }
        Vector3 Velocity { get; }

        #endregion
        
        #region Methods

        void ApplyJump();
        void SetTargetDirection(Vector3 newTargetDirection);
        void TickMovement(float deltaTime);

        #endregion
    }
}