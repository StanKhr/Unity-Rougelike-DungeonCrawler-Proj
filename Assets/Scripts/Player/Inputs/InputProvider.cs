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

        #endregion

        #region Properties

        private GameControlsAsset GameControlsAsset => _gameControlsAsset ??= new GameControlsAsset();
        public IMapWrapperCamera MapWrapperCamera => _mapWrapperCamera ??= new MapWrapperCamera(GameControlsAsset);

        #endregion
        
        #region Unity Callbacks

        private void Start()
        {
            
        }

        #endregion
    }
}