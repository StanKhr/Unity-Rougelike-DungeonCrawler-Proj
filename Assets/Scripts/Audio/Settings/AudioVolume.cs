using System;
using Audio.Interfaces;
using Cysharp.Threading.Tasks;
using Miscellaneous;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Audio.Settings
{
    public class AudioVolume : MonoBehaviour, IAudioVolume
    {
        #region Constants

        private const float MinVolume = 0f;
        private const float MaxVolume = 1f;

        #endregion
        
        #region Events
        
        public event DelegateHolder.FloatEvents OnNewVolumeSet;

        #endregion
        
        #region Editor Fields

        [SerializeField] private AudioMixer _audioMixer;
        [SerializeField] private string _propertyName;
        [SerializeField, Range(0F, 1F)] private float _defaultVolume = 0.8f;

        #endregion

        #region Fields

        private float _volume;

        #endregion
        
        #region Properties

        public float Volume
        {
            get => _volume;
            set
            {
                float newVolume;
                if (value is >= MinVolume and <= MaxVolume)
                {
                    newVolume = value;
                }
                else if (value < MinVolume)
                {
                    newVolume = MaxVolume;
                }
                else
                {
                    newVolume = MinVolume;
                }

                if (Math.Abs(_volume - newVolume) < 0f)
                {
                    return;
                }

                _volume = newVolume;

                // hardcoded formula
                _audioMixer.SetFloat(_propertyName, Mathf.Log10(newVolume) * 20);
                
                OnNewVolumeSet?.Invoke(newVolume);
            }
        }

        #endregion

        #region Unity Callbacks

        private async void Start()
        {
            await UniTask.Yield();
            
            if (!PlayerPrefs.HasKey(_propertyName))
            {
                Volume = _defaultVolume;
                return;
            }

            Volume = PlayerPrefs.GetFloat(_propertyName);
        }

        private void OnDestroy()
        {
            if (Math.Abs(Volume - _defaultVolume) < 0f)
            {
                return;
            }
            
            PlayerPrefs.SetFloat(_propertyName, Volume);
        }

        #endregion
    }
}