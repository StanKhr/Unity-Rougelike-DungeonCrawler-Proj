using System;
using Miscellaneous.EventWrapper.Events;
using Miscellaneous.EventWrapper.Interfaces;
using Miscellaneous.EventWrapper.Main;

namespace WorldGeneration.Interfaces
{
    public interface ILevelGenerator
    {
        #region Events

        public static IContextEvent<Events.LevelGeneratorEvent> OnLevelGeneratorLoaded { get; } =
            new ContextEvent<Events.LevelGeneratorEvent>();

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
            OnLevelGeneratorLoaded?.NotifyListeners(new Events.LevelGeneratorEvent
            {
                LevelGenerator = levelGenerator
            });
        }

        #endregion
    }
}