using Miscellaneous;
using Plugins.StanKhrEssentials.EventWrapper.Interfaces;
using Plugins.StanKhrEssentials.EventWrapper.Main;

namespace Audio.Interfaces
{
    public interface IAudioVolume
    {
        #region Events

        IContextEvent<Events.FloatEvent> OnNewVolumeSet { get; }

        #endregion
        
        #region Fields

        float Volume { get; set; }

        #endregion
    }
}