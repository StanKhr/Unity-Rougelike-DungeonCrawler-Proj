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

        void Generate(int seed);
        void Clear();

        #endregion
    }
}