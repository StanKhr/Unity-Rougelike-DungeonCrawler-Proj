using System;
using Audio.Interfaces;
using Miscellaneous;
using Player.Attacks;
using Player.Interfaces;
using Statuses.Enums;
using Statuses.Extras;
using UnityEngine;

namespace Audio.Triggers
{
    public class AudioTriggerSurfaceHit : MonoBehaviour
    {
        #region Editor Fields

        [SerializeField] private PlayerAttack _playerAttack;

        #endregion

        #region Properties

        private IPlayerAttack PlayerAttack => _playerAttack;

        #endregion
        
        #region Unity Callbacks

        private void OnEnable()
        {
            PlayerAttack.OnSurfaceHit += SurfaceHitCallback;
        }

        private void OnDisable()
        {
            PlayerAttack.OnSurfaceHit -= SurfaceHitCallback;
        }

        #endregion

        #region Methods
        
        private void SurfaceHitCallback(GameObject context)
        {
            if (!ObjectSurfaceTypeConverter.TryGetFromObject(context, out var surfaceType))
            {
                LogWriter.DevelopmentLog($"{context}: surface type not found");
                return;
            }
            
            LogWriter.DevelopmentLog($"{context}: surface type found: {surfaceType.ToString()}");
        }

        private IClipSelector GetClipSelectorFromPropType(ObjectSurfaceType objectSurfaceType)
        {
            switch (objectSurfaceType)
            {
                
            }

            return null;
        }

        #endregion
    }
}