using Miscellaneous;
using Plugins.StanKhrEssentials.EventWrapper.Interfaces;
using Plugins.StanKhrEssentials.EventWrapper.Main;

namespace WorldGeneration.Interfaces
{
    public interface ILevelGenerator
    {
        #region Events

        public static IContextEvent<EventContext.LevelGeneratorEvent> OnLevelGeneratorLoaded { get; } =
            EventFactory.CreateContextEvent<EventContext.LevelGeneratorEvent>();
        IEvent OnGenerationStarted { get; }
        IEvent OnGenerationEnded { get; }

        #endregion

        #region Methods

        void GenerateNew();
        void Generate(int seed);
        void Clear();

        #endregion

        #region Interface Methods

        public void CallGeneratorLoadedEvent(ILevelGenerator levelGenerator)
        {
            OnLevelGeneratorLoaded?.NotifyListeners(new EventContext.LevelGeneratorEvent
            {
                LevelGenerator = levelGenerator
            });
        }

        #endregion
    }
}