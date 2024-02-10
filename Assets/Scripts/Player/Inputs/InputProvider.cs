using System;
using Player.Inputs.Interfaces;
using Player.Inputs.MapWrappers;
using Scripts.Player.Inputs;
using UnityEngine;

namespace Player.Inputs
{
    public class InputProvider : MonoBehaviour, IInputProvider
    {
        #region Editor Fields

        

        #endregion

        #region Fields

        private GameControlsAsset _gameControlsAsset;
        private MapWrapperCamera _mapWrapperCamera;
        private MapWrapperMovement _mapWrapperMovement;
        private CursorVisibility _cursorVisibility;

        #endregion

        #region Properties

        private GameControlsAsset GameControlsAsset => _gameControlsAsset ??= new GameControlsAsset();
        public IMapWrapperCamera MapWrapperCamera => _mapWrapperCamera ??= new MapWrapperCamera(GameControlsAsset);
        public IMapWrapperMovement MapWrapperMovement =>
            _mapWrapperMovement ??= new MapWrapperMovement(GameControlsAsset);
        public ICursorVisibility CursorVisibility => _cursorVisibility ??= new CursorVisibility();

        #endregion
        
        #region Unity Callbacks

        private void Start()
        {
            
        }

        #endregion
    }
}