using System;
using Abilities.Interfaces;
using FSM.GameLoop.Enums;
using FSM.GameLoop.Interfaces;
using Player.Miscellaneous;
using Player.StateMachines.States;
using Props.Common;
using Statuses.Interfaces;
using UnityEngine;
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

        private GameObject PlayerObject { get; set; }
        private ILevelGenerator LevelGenerator { get; set; }

        #endregion

        #region Methods

        public override void Enter()
        {
            ILevelGenerator.OnLevelGeneratorLoaded += LevelGeneratorStartedCallback;
            StatePlayerDeath.OnPlayerDied += PlayerDiedCallback;
            NextFloorLadder.OnNextFloorTriggered += NextFloorTriggeredCallback;
            PlayerNotifier.OnPlayerLoaded += PlayerLoadedCallback;
            
            StateMachine.LoadScene(GameSceneType.Dungeon);
        }

        public override void Exit()
        {
            ILevelGenerator.OnLevelGeneratorLoaded -= LevelGeneratorStartedCallback;
            StatePlayerDeath.OnPlayerDied -= PlayerDiedCallback;
            NextFloorLadder.OnNextFloorTriggered -= NextFloorTriggeredCallback;
            PlayerNotifier.OnPlayerLoaded -= PlayerLoadedCallback;
            
            StateMachine.UnloadScene(GameSceneType.Dungeon);
        }

        private void PlayerLoadedCallback(GameObject context)
        {
            PlayerObject = context;
        }

        private void NextFloorTriggeredCallback()
        {
            if (PlayerObject.TryGetComponent<IHealth>(out var health))
            {
                health.Resurrect();
            }
            
            if (PlayerObject.TryGetComponent<ILocomotion>(out var locomotion))
            {
                locomotion.Teleport(Vector3.zero);
            }
            
            LevelGenerator.GenerateNew();
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