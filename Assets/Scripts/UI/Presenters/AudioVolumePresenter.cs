using Audio.Interfaces;
using Audio.Settings;
using Miscellaneous;
using TMPro;
using UI.Utility;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Presenters
{
    public class AudioVolumePresenter : MonoBehaviour
    {
        #region Editor Fields

        [SerializeField] private AudioVolume _audioVolume;
        [SerializeField, Range(0f, 1f)] private float _changeValueStep = 0.05f;
        
        [Header("Views")]
        [SerializeField] private Button _increaseButton;
        [SerializeField] private Button _decreaseButton;
        [SerializeField] private TextMeshProUGUI _volumeText;

        #endregion

        #region Properties

        private IAudioVolume AudioVolume => _audioVolume;

        #endregion

        #region Unity Callbacks

        private void Start()
        {
            AudioVolume.OnNewVolumeSet.AddListener(NewVolumeSetCallback);
            
            _increaseButton.onClick.AddListener(IncreaseVolume);
            _decreaseButton.onClick.AddListener(DecreaseVolume);

            ValidateVolume(AudioVolume.Volume);
        }

        private void OnDestroy()
        {
            AudioVolume.OnNewVolumeSet.RemoveListener(NewVolumeSetCallback);
            
            _increaseButton.onClick.RemoveListener(IncreaseVolume);
            _decreaseButton.onClick.RemoveListener(DecreaseVolume);
        }

        #endregion

        #region Methods

        private void NewVolumeSetCallback(EventContext.FloatEvent context)
        {
            ValidateVolume(context.Float);
        }

        private void ValidateVolume(float currentVolume)
        {
            _volumeText.SetTextSmart($"{currentVolume.ToString("P0")}");
        }

        private void IncreaseVolume()
        {
            AudioVolume.Volume += _changeValueStep;
        }

        private void DecreaseVolume()
        {
            AudioVolume.Volume -= _changeValueStep;
        }

        #endregion
    }
}