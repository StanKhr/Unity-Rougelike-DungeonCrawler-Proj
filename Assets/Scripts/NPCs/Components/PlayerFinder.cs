using System;
using NPCs.Components.Interfaces;
using UnityEngine;

namespace NPCs.Components.Navigation
{
    public class PlayerFinder : MonoBehaviour, IPlayerFinder
    {
        #region Constants

        private const string PlayerTag = "Player";

        #endregion
        
        #region Editor Fields

        [SerializeField] private float _scanDelay = 0.5f;
        [SerializeField] private float _scanRadius = 5f;
        [SerializeField] private LayerMask _scanLayers;

        #endregion

        #region Fields

        private float _delay;

        private GameObject _playerObject;

        private static readonly Collider[] ScanResults = new Collider[20];

        #endregion

        #region Properties

        public bool PlayerFound { get; private set; }
        public Vector3 PlayerPosition => _playerObject ? _playerObject.transform.position : Vector3.zero;

        #endregion

        #region Unity Callbacks

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, _scanRadius);
        }
#endif

        #endregion

        #region Methods

        public void Tick(float deltaTime)
        {
            if (PlayerFound)
            {
                return;
            }

            if (_delay > 0f)
            {
                _delay -= deltaTime;
                return;
            }

            _delay = _scanDelay;

            PlayerFound = TryFindPlayer();
        }

        private bool TryFindPlayer()
        {
            Array.Clear(ScanResults, 0, ScanResults.Length);

            if (Physics.OverlapSphereNonAlloc(transform.position, _scanRadius, ScanResults, _scanLayers) <= 0)
            {
                return false;
            }

            for (int i = 0; i < ScanResults.Length; i++)
            {
                if (!ScanResults[i])
                {
                    continue;
                }

                if (!ScanResults[i].gameObject.CompareTag(PlayerTag))
                {
                    continue;
                }

                _playerObject = ScanResults[i].gameObject;
                return true;
            }
            
            return false;
        }

        #endregion
    }
}