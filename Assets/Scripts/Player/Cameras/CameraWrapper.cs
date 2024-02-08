using Player.Inputs.Interfaces;
using UnityEngine;

namespace Player.Inputs
{
    public class CameraWrapper : MonoBehaviour, ICameraWrapper
    {
        #region Editor Fields

        [field: SerializeField] public CameraInputAiming CameraInputAiming { get; private set; }

        #endregion

        #region MyRegion

        public void SetLookInputs(Vector2 inputs)
        {
            CameraInputAiming.SetAxisStateValue(inputs);
            
            Debug.Log($"Camera inputs: {inputs.ToString()}");
        }

        #endregion
    }
}