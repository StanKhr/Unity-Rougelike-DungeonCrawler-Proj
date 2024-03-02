using FSM.Creatures.Interfaces;
using Player.Cameras.Interfaces;
using Player.Inputs.Interfaces;
using Player.Interfaces;
using Player.Inventories.Interfaces;
using UnityEngine;

namespace Player.StateMachines.Interfaces
{
    public interface IStateMachinePlayer : IStateMachineHumanoid
    {
        #region Properties

        IInputProvider InputProvider { get; }
        ICameraWrapper CameraWrapper { get; }
        IEyeScanner EyeScanner { get; }
        IFootStepsTracker FootStepsTracker { get; }
        IGear Gear { get; }
        IPlayerAnimations PlayerAnimations { get; }
        IPlayerAttack PlayerAttack { get; }
        
        #endregion

        #region Methods

        void ToWeaponAttackState(IWeapon weapon);
        Vector3 CalculateCameraDirection();

        #endregion
    }
}