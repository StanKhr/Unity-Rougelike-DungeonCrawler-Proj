using Abilities.Interfaces;
using Miscellaneous;
using UnityEngine;

namespace Abilities.Locomotion
{
    public class LocomotionCharacterController : MonoBehaviour, ILocomotion
    {
        #region Constants

        private const float JumpConstScale = -3f;

        #endregion

        #region Editor Fields

        [SerializeField] private CharacterController _characterController;
        [SerializeField] private LocomotionData _locomotionData;
        [SerializeField] private GroundScanner _groundScanner;

        #endregion

        #region Fields

        private float _acceleration;
        private float _gravity;
        private Vector3 _targetDirection;
        private Vector3 _moveDirection;

        #endregion

        #region Properties

        public Vector3 Velocity => _characterController.velocity;

        private float Gravity
        {
            get => _gravity;
            set { _gravity = value; }
        }

        #endregion

        #region Unity Callbacks

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            _groundScanner.DrawGizmos();
        }
#endif

        #endregion

        #region Methods

        public void ApplyJump()
        {
            Gravity = Mathf.Sqrt(_locomotionData.JumpPower * JumpConstScale * Physics.gravity.y);
        }

        public void SetTargetDirection(Vector3 targetDirection)
        {
            _targetDirection = targetDirection;
        }

        public void TickMovement(float deltaTime)
        {
            var grounded = _groundScanner.ScanForGround(out _);
            LogWriter.DevelopmentLog($"Grounded: {grounded.ToString()}");
            
            if (grounded)
            {
                
            }
            else
            {
                
            }
            
            _moveDirection = Vector3.MoveTowards(_moveDirection, _targetDirection,
                deltaTime * _locomotionData.AccelerationRate);
            _moveDirection *= _locomotionData.Speed * deltaTime;

            _characterController.Move(_moveDirection);
        }

        #endregion
    }
}