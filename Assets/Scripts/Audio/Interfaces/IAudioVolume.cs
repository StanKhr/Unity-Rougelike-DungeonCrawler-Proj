using Miscellaneous;
using Plugins.StanKhrEssentials.Scripts.EventWrapper.Interfaces;

namespace Audio.Interfaces
{
    public interface IAudioVolume
    {
        #region Events

        IContextEvent<EventContext.FloatEvent> OnNewVolumeSet { get; }

        #endregion
        
        #region Fields

        float Volume { get; set; }

        #endregion
    }
}