using Abilities.Interfaces;
using FSM.Creatures.Interfaces;
using Player.Cameras.Interfaces;
using Player.Inputs.Interfaces;
using Player.Interfaces;

namespace Player.StateMachines.Interfaces
{
    public interface IStateMachinePlayer : IStateMachineHumanoid
    {
        #region Properties

        IInputProvider InputProvider { get; }
        ICameraWrapper CameraWrapper { get; }
        IEyeScanner EyeScanner { get; }
        IFootStepsTracker FootStepsTracker { get; }

        #endregion
    }
}