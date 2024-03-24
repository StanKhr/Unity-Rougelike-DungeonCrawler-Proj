using System.Collections.Generic;
using Audio.ClipSelectors;
using Audio.Interfaces;
using Audio.Sources;
using Miscellaneous.CustomEvents.Contexts;
using Miscellaneous.ObjectPooling;
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

        [SerializeField] private AudioSourcePooled _audioSourcePooledPrefab;
        [SerializeField] private PlayerAttack _playerAttack;
        [SerializeField, Range(0f, 1f)] private float _sfxVolume;

        [Header("Clip Selectors")]
        [SerializeField] private ClipSelector _clipSelectorFlesh;
        [SerializeField] private ClipSelector _clipSelectorAstral;
        [SerializeField] private ClipSelector _clipSelectorPlate;
        [SerializeField] private ClipSelector _clipSelectorWood;
        [SerializeField] private ClipSelector _clipSelectorStone;
        [SerializeField] private ClipSelector _clipSelectorWater;
        [SerializeField] private ClipSelector _clipSelectorDirt;

        #endregion

        #region Fields

        private Dictionary<ObjectSurfaceType, IClipSelector> _sortedSelectors;
        private ObjectPoolWrapper _objectPoolWrapper;
        
        #endregion

        #region Properties

        private IPlayerAttack PlayerAttack => _playerAttack;

        private Dictionary<ObjectSurfaceType, IClipSelector> SortedSelectors
        {
            get
            {
                if (_sortedSelectors != null)
                {
                    return _sortedSelectors;
                }

                _sortedSelectors = new()
                {
                    {ObjectSurfaceType.Flesh, _clipSelectorFlesh},
                    {ObjectSurfaceType.Astral, _clipSelectorAstral},
                    {ObjectSurfaceType.Plate, _clipSelectorPlate},
                    {ObjectSurfaceType.Wood, _clipSelectorWood},
                    {ObjectSurfaceType.Stone, _clipSelectorStone},
                    {ObjectSurfaceType.Water, _clipSelectorWater},
                    {ObjectSurfaceType.Dirt, _clipSelectorDirt},
                };

                return _sortedSelectors;
            }
        }

        private ObjectPoolWrapper PoolWrapper
        {
            get
            {
                if (_objectPoolWrapper != null)
                {
                    return _objectPoolWrapper;
                }

                _objectPoolWrapper = new ObjectPoolWrapper(_audioSourcePooledPrefab);

                return _objectPoolWrapper;
            }
        }

        #endregion
        
        #region Unity Callbacks

        private void OnEnable()
        {
            PlayerAttack.OnSurfaceHit.AddListener(SurfaceHitCallback);
        }

        private void OnDisable()
        {
            PlayerAttack.OnSurfaceHit.RemoveListener(SurfaceHitCallback);
        }

        #endregion

        #region Methods
        
        private void SurfaceHitCallback(EventContext.GameObjectEvent context)
        {
            if (!ObjectSurfaceTypeConverter.TryGetFromObject(context.GameObject, out var surfaceType))
            {
                // LogWriter.DevelopmentLog($"{context}: surface type not found");
                return;
            }
            
            // LogWriter.DevelopmentLog($"{context}: surface type found: {surfaceType.ToString()}");

            var clipSelector = GetClipSelectorFromPropType(surfaceType);
            if (clipSelector == null)
            {
                return;
            }
            
            var audioSourcePooled = (AudioSourcePooled) PoolWrapper.Get();
            audioSourcePooled.transform.position = context.GameObject.transform.position;
            
            clipSelector.TryOneShotOnAudioSource(audioSourcePooled.Source, _sfxVolume);
        }

        private IClipSelector GetClipSelectorFromPropType(ObjectSurfaceType objectSurfaceType)
        {
            return SortedSelectors.GetValueOrDefault(objectSurfaceType);
        }

        #endregion
    }
}