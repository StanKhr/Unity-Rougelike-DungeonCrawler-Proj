using System;
using Plugins.StanKhrEssentials.Scripts.Utility;
using Settings.Audio;
using Settings.Enums;
using Settings.Localization;
using UnityEngine;

namespace Settings
{
    public class GameSettings : Singleton<GameSettings>
    {
        #region Editor Fields

        [field: SerializeField] private AudioVolume AudioVolumeMusic { get; set; }
        [field: SerializeField] private AudioVolume AudioVolumeAmbient { get; set; }
        [field: SerializeField] private AudioVolume AudioVolumeEffects { get; set; }
        [field: SerializeField] public LocalizationSelection LocalizationSelection { get; private set; }

        #endregion

        #region Methods

        public AudioVolume GetVolumeFromChannelType(AudioChannelType audioChannelType)
        {
            return audioChannelType switch
            {
                AudioChannelType.Music => AudioVolumeMusic,
                AudioChannelType.Ambient => AudioVolumeAmbient,
                AudioChannelType.Effects => AudioVolumeEffects,
                _ => null
            };
        }

        #endregion
    }
}