using System;
using Abilities.Interfaces;
using Miscellaneous;
using UnityEngine;

namespace Abilities.Locomotion
{
    public class LocomotionCharacterController : MonoBehaviour, ILocomotion
    {
        #region Constants

        private const float GravityMaxForce = -100;
        private const float JumpConstScale = -3f;
        private const float CoyoteTime = 0.3f;

        #endregion

        #region Events
        
        public event Action OnJumped;
        public event Action OnGroundLanded;

        #endregion

        #region Editor Fields

        [SerializeField] private CharacterController _characterController;
        [SerializeField] private LocomotionData _locomotionData;
        [SerializeField] private GroundScanner _groundScanner;

        #endregion

        #region Fields

        private bool _grounded;
        private float _acceleration;
        private float _gravity;
        private Vector3 _targetDirection;
        private Vector3 _moveDirection;

        #endregion

        #region Properties

        public Vector3 Velocity => _characterController.velocity;

        public bool Grounded
        {
            get => _grounded;
            private set
            {
                if (Grounded != value)
                {
                    Gravity = Mathf.Max(Gravity, 0f);
                }

                if (!Grounded && value)
                {
                    OnGroundLanded?.Invoke();
                }

                _grounded = value;
            }
        }
        private float Gravity
        {
            get => _gravity;
            set => _gravity = Mathf.Max(GravityMaxForce, value);
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
            if (!Grounded)
            {
                return;
            }
            
            Gravity = Mathf.Sqrt(_locomotionData.JumpPower * JumpConstScale * Physics.gravity.y);
            OnJumped?.Invoke();
        }

        public void SetTargetDirection(Vector3 newTargetDirection)
        {
            if (!Grounded)
            {
                return;
            }
            
            _targetDirection = newTargetDirection;
        }

        public void TickMovement(float deltaTime)
        {
            Grounded = _groundScanner.ScanForGround(out _);
            
            if (Grounded && Gravity <= 0f)
            {
                Gravity = Physics.gravity.y;
            }
            else
            {
                Gravity -= deltaTime * _locomotionData.GravityScale;
            }
            
            _moveDirection = _targetDirection;
            _moveDirection *= _locomotionData.Speed * deltaTime;
            _moveDirection += new Vector3(0f, Gravity * deltaTime, 0f);

            _characterController.Move(_moveDirection);
        }

        #endregion
    }
}