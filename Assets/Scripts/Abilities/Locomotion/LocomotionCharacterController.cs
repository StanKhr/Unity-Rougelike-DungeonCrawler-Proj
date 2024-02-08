using Abilities.Interfaces;
using UnityEngine;

namespace Abilities.Locomotion
{
    public class LocomotionCharacterController : MonoBehaviour, ILocomotion
    {
        #region Editor Fields

        [SerializeField] private CharacterController _characterController;
        [SerializeField] private LocomotionData _locomotionData;

        #endregion

        #region Methods

        public void SetMoveDirection(Vector3 direction)
        {
            
        }

        public void TickMovement(float deltaTime)
        {
            
        }

        #endregion
    }
}