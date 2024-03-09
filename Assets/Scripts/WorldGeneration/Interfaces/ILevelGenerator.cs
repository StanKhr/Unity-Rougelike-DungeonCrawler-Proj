using System;
using Miscellaneous;

namespace WorldGeneration.Interfaces
{
    public interface ILevelGenerator
    {
        #region Events

        public static event DelegateHolder.LevelGeneratorEvents OnLevelGeneratorStarted;
        event Action OnGenerationStarted;
        event Action OnGenerationEnded;

        #endregion

        #region Methods

        void Generate(int seed);
        void Clear();

        #endregion

        #region Interface Methods

        public void CallGeneratorStartedEvent(ILevelGenerator levelGenerator)
        {
            OnLevelGeneratorStarted?.Invoke(levelGenerator);
        }

        #endregion
    }
}