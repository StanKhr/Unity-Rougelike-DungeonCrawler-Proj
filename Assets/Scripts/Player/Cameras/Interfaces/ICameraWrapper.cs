using UnityEngine;

namespace Player.Inputs.Interfaces
{
    public interface ICameraWrapper
    {
        #region Methods

        void SetLookInputs(Vector2 inputs);

        #endregion
    }
}