using Miscellaneous;

namespace Audio.Interfaces
{
    public interface IAudioVolume
    {
        #region Events

        event DelegateHolder.FloatEvents OnNewVolumeSet;

        #endregion
        
        #region Fields

        float Volume { get; set; }

        #endregion
    }
}