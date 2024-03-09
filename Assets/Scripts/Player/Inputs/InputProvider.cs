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
        private MapWrapperCamera _camera;
        private MapWrapperMovement _movement;
        private MapWrapperAbilities _abilities;
        private MapWrapperUtility _utility;
        private CursorVisibility _cursorVisibility;

        #endregion

        #region Properties

        private GameControlsAsset GameControlsAsset => _gameControlsAsset ??= new GameControlsAsset();
        public IMapWrapperCamera Camera => _camera ??= new MapWrapperCamera(GameControlsAsset);
        public IMapWrapperMovement Movement =>
            _movement ??= new MapWrapperMovement(GameControlsAsset);
        public IMapWrapperAbilities Abilities =>
            _abilities ??= new MapWrapperAbilities(GameControlsAsset);
        public IMapWrapperUtility Utility => _utility ??= new MapWrapperUtility(GameControlsAsset);
        public ICursorVisibility CursorVisibility => _cursorVisibility ??= new CursorVisibility();

        #endregion
    }
}