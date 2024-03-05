using System;

namespace WorldGeneration.Interfaces
{
    public interface ILevelGenerator
    {
        #region Events

        event Action OnGenerationStarted;
        event Action OnGenerationEnded;

        #endregion

        #region Methods

        void StartGeneration();

        #endregion
    }
}