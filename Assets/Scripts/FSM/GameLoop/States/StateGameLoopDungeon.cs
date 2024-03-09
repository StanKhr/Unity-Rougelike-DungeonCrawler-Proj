using System;
using FSM.GameLoop.Enums;
using FSM.GameLoop.Interfaces;
using WorldGeneration.Interfaces;

namespace FSM.GameLoop.States
{
    public class StateGameLoopDungeon : StateGameLoop
    {
        #region Constants

        public StateGameLoopDungeon(IStateMachineGameLoop stateMachineGameLoop) : base(stateMachineGameLoop)
        {
            
        }

        #endregion

        #region Fields

        private ILevelGenerator LevelGenerator { get; set; }

        #endregion

        #region Methods

        public override void Enter()
        {
            ILevelGenerator.OnLevelGeneratorStarted += LevelGeneratorStartedCallback;
            StateMachine.LoadScene(GameSceneType.Dungeon);
        }

        public override void Exit()
        {
            ILevelGenerator.OnLevelGeneratorStarted -= LevelGeneratorStartedCallback;
            StateMachine.UnloadScene(GameSceneType.Dungeon);
        }

        private void LevelGeneratorStartedCallback(ILevelGenerator levelGenerator)
        {
            LevelGenerator = levelGenerator;
            var randomSeed = Guid.NewGuid().GetHashCode();
            
            LevelGenerator.Generate(randomSeed);
        }

        #endregion
    }
}