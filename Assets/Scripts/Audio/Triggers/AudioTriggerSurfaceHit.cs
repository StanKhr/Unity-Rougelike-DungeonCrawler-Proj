using System.Collections.Generic;
using Audio.ClipSelectors;
using Audio.Interfaces;
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
        [SerializeField, Range(0f, 1f)] private float _sfxVolume;

        [Header("Clip Selectors")]
        [SerializeField] private ClipSelectorScriptable _clipSelectorFlesh;
        [SerializeField] private ClipSelectorScriptable _clipSelectorAstral;
        [SerializeField] private ClipSelectorScriptable _clipSelectorPlate;
        [SerializeField] private ClipSelectorScriptable _clipSelectorWood;
        [SerializeField] private ClipSelectorScriptable _clipSelectorStone;
        [SerializeField] private ClipSelectorScriptable _clipSelectorWater;
        [SerializeField] private ClipSelectorScriptable _clipSelectorDirt;

        #endregion

        #region Fields

        private Dictionary<ObjectSurfaceType, IClipSelector> _sortedSelectors;

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
                // LogWriter.DevelopmentLog($"{context}: surface type not found");
                return;
            }
            
            // LogWriter.DevelopmentLog($"{context}: surface type found: {surfaceType.ToString()}");

            var clipSelector = GetClipSelectorFromPropType(surfaceType);
            clipSelector?.TryOneShotAtPosition(context.transform.position, _sfxVolume);
        }

        private IClipSelector GetClipSelectorFromPropType(ObjectSurfaceType objectSurfaceType)
        {
            return SortedSelectors.GetValueOrDefault(objectSurfaceType);
        }

        #endregion
    }
}