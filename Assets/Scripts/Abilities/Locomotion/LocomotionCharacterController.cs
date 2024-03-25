using Abilities.Interfaces;
using Miscellaneous;
using Plugins.StanKhrEssentials.Scripts.EventWrapper.Interfaces;
using Plugins.StanKhrEssentials.Scripts.EventWrapper.Main;
using UnityEngine;

namespace Abilities.Locomotion
{
    public class LocomotionCharacterController : MonoBehaviour, ILocomotion
    {
        #region Constants

        private const float GravityMaxForce = -100;
        private const float JumpConstScale = -3f;

        #endregion

        #region Events

        public IEvent OnJumped { get; } = EventFactory.CreateEvent();
        public IEvent OnGroundLanded { get; } = EventFactory.CreateEvent();
        public IContextEvent<EventContext.FloatEvent> OnFallDamageTriggered { get; } =
            EventFactory.CreateContextEvent<EventContext.FloatEvent>();

        #endregion

        #region Editor Fields

        [SerializeField] private CharacterController _characterController;
        [SerializeField] private LocomotionData _locomotionData;
        [SerializeField] private GroundScanner _groundScanner;

        #endregion

        #region Fields

        private bool _grounded;
        private float _gravity;
        private Vector3 _targetMotion;
        private Vector3 _currentMotion;
        
        #endregion

        #region Properties
        public bool Walking { get; set; }
        public bool Sprinting { get; set; }
        public bool Crouching { get; set; }
        public Vector3 BodyVelocity => _characterController.velocity;
        public Vector3 Position => _characterController.transform.position;
        public bool Grounded
        {
            get => _grounded;
            private set
            {
                var triggerFallDamage = !Grounded && value;

                if (!Grounded && value)
                {
                    OnGroundLanded?.NotifyListeners();
                }

                if (triggerFallDamage && Gravity <= _locomotionData.FallDamageGravityThreshold)
                {
                    OnFallDamageTriggered?.NotifyListeners(new EventContext.FloatEvent
                    {
                        Float = Gravity
                    });
                }
                
                if (Grounded != value)
                {
                    Gravity = Mathf.Max(Gravity, 0f);
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

            if (_locomotionData.JumpPower <= 0f)
            {
                return;
            }

            Gravity = Mathf.Sqrt(_locomotionData.JumpPower * JumpConstScale * Physics.gravity.y);
            OnJumped?.NotifyListeners();
        }

        public void SetTargetMotion(Vector3 newTargetDirection)
        {
            _targetMotion = newTargetDirection;
        }

        public void TickMotion(float deltaTime)
        {
            TickGravity(deltaTime);
            
            var speed = _locomotionData.GetSpeed(this);
            var motionChangeRate = _locomotionData.GetMotionChangeRate(this);

            var changeMotion = Mathf.Abs(_targetMotion.sqrMagnitude) > 0f;
            if (Grounded || changeMotion)
            {
                _currentMotion = Vector3.Lerp(_currentMotion, _targetMotion * speed, deltaTime * motionChangeRate);
            }
            
            var finalMotion = _currentMotion * deltaTime;
            
            finalMotion += new Vector3(0f, Gravity * deltaTime, 0f);

            _characterController.Move(finalMotion);
        }

        public void EnableCollider(bool enable)
        {
            _characterController.enabled = false;
        }

        public void Teleport(Vector3 position)
        {
            var reEnableController = _characterController.enabled;
            _characterController.enabled = false;
            _characterController.transform.position = position;
            if (reEnableController)
            {
                _characterController.enabled = true;
            }
        }

        private void TickGravity(float deltaTime)
        {
            Grounded = _groundScanner.ScanForGround(out _);
            if (Grounded && Gravity <= 0f)
            {
                Gravity = Physics.gravity.y;
                return;
            }
            
            Gravity -= deltaTime * _locomotionData.GravityScale;
        }

        #endregion
    }
}