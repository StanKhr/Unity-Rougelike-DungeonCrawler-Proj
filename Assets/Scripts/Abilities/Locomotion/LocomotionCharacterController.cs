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

        #region Properties

        private Vector3 _moveDirection;

        #endregion

        #region Methods

        public void SetMoveDirection(Vector3 direction)
        {
            _moveDirection = direction;
        }

        public void TickMovement(float deltaTime)
        {
            var velocity = _moveDirection * (deltaTime * _locomotionData.Speed);
            _characterController.Move(velocity);
        }

        #endregion
    }
}