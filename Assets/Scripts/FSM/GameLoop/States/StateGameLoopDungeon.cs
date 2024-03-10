using System;
using FSM.GameLoop.Enums;
using FSM.GameLoop.Interfaces;
using Player.StateMachines.States;
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
            ILevelGenerator.OnLevelGeneratorLoaded += LevelGeneratorStartedCallback;
            StatePlayerDeath.OnPlayerDied += PlayerDiedCallback;
            
            StateMachine.LoadScene(GameSceneType.Dungeon);
        }

        public override void Exit()
        {
            ILevelGenerator.OnLevelGeneratorLoaded -= LevelGeneratorStartedCallback;
            StatePlayerDeath.OnPlayerDied -= PlayerDiedCallback;
            
            StateMachine.UnloadScene(GameSceneType.Dungeon);
        }

        private void PlayerDiedCallback()
        {
            StateMachine.ToDeathState();
        }

        private void LevelGeneratorStartedCallback(ILevelGenerator levelGenerator)
        {
            LevelGenerator = levelGenerator;
        }

        #endregion
    }
}