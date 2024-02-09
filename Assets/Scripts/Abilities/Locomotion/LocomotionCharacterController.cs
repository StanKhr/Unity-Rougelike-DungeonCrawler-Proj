using Abilities.Interfaces;
using UnityEngine;

namespace Abilities.Locomotion
{
    public class LocomotionCharacterController : MonoBehaviour, ILocomotion
    {
        #region Constants

        private const float AccelerationMove = 1f;
        private const float AccelerationIdle = 0f;

        #endregion

        #region Editor Fields

        [SerializeField] private CharacterController _characterController;
        [SerializeField] private LocomotionData _locomotionData;

        #endregion

        #region Fields

        private float _acceleration;
        private Vector3 _targetDirection;
        private Vector3 _moveDirection;

        #endregion

        #region Properties

        public Vector3 Velocity => _characterController.velocity;

        #endregion

        #region Methods

        public void SetTargetDirection(Vector3 targetDirection)
        {
            _targetDirection = targetDirection;
        }

        public void TickMovement(float deltaTime)
        {
            // _moveDirection = Vector3.MoveTowards(_moveDirection, TargetDirection, )
            // _acceleration = Mathf.MoveTowards(_acceleration, _targetAcceleration,
            // deltaTime * _locomotionData.AccelerationRate);
            // _moveDirection = Vector3.MoveTowards(_moveDirection, _targetDirection, deltaTime);
            // _moveDirection = TargetDirection * (_acceleration * _locomotionData.Speed * deltaTime);
            _moveDirection = Vector3.MoveTowards(_moveDirection, _targetDirection,
                _locomotionData.AccelerationRate * deltaTime);
            _moveDirection *= _locomotionData.Speed * deltaTime;

            _characterController.Move(_moveDirection);
        }

        #endregion
    }
}