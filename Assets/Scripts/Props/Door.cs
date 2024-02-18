using System;
using Miscellaneous;
using Props.Interfaces;
using UnityEngine;

namespace Props
{
    public class Door : MonoBehaviour, IInteractable, IUsable
    {
        #region Constants

        private static readonly int OpenHash = Animator.StringToHash("Open");
        private static readonly int CloseHash = Animator.StringToHash("Close");

        #endregion
        
        #region Events
        
        public event DelegateHolder.GameObjectEvents OnInteractionStarted;
        public event DelegateHolder.GameObjectEvents OnInteractionEnded;

        #endregion

        #region Editor Fields

        [SerializeField] private float _useDistance = 2f;
        [SerializeField] private Animator _animator;

        #endregion

        #region Fields

        private bool _opened;

        #endregion

        #region Properties

        private bool Opened
        {
            get => _opened;
            set
            {
                if (Opened == value)
                {
                    return;
                }
                
                _opened = value;

                if (Opened)
                {
                    _animator.Play(OpenHash);
                    OnInteractionStarted?.Invoke(null);
                    return;
                }
                
                _animator.Play(CloseHash);
                OnInteractionEnded?.Invoke(null);
            }
        }

        #endregion

        #region Methods

        public bool TryUse(GameObject user)
        {
            var distance = Vector3.Distance(user.transform.position, transform.position);
            if (distance > _useDistance)
            {
                return false;
            }
            
            Opened = !Opened;
            return true;
        }

        #endregion
    }
}