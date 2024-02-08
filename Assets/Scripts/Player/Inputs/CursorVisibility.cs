using Player.Inputs.Interfaces;
using UnityEngine;

namespace Player.Inputs
{
    public class CursorVisibility : ICursorVisibility
    {
        #region Fields

        private bool _cursorVisible;

        #endregion
        
        #region Properties

        public bool CursorVisible
        {
            get => _cursorVisible;
            private set
            {
                _cursorVisible = value;
                if (_cursorVisible)
                {
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    return;
                }
                
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }

        #endregion
        
        #region Methods

        public void SetVisibility(bool visible)
        {
            CursorVisible = visible;
        }

        #endregion
    }
}