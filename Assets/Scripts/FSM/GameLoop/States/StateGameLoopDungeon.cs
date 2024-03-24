using Abilities.Interfaces;
using FSM.GameLoop.Enums;
using FSM.GameLoop.Interfaces;
using Miscellaneous.EventWrapper.Main;
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
            ILevelGenerator.OnLevelGeneratorLoaded.AddListener(LevelGeneratorStartedCallback);
            StatePlayerDeath.OnPlayerDied.AddListener(PlayerDiedCallback);
            NextFloorLadder.OnNextFloorTriggered.AddListener(NextFloorTriggeredCallback);
            PlayerNotifier.OnPlayerLoaded.AddListener(PlayerLoadedCallback);
            
            StateMachine.LoadScene(GameSceneType.Dungeon);
        }

        public override void Exit()
        {
            ILevelGenerator.OnLevelGeneratorLoaded.RemoveListener(LevelGeneratorStartedCallback);
            StatePlayerDeath.OnPlayerDied.RemoveListener(PlayerDiedCallback);
            NextFloorLadder.OnNextFloorTriggered.RemoveListener(NextFloorTriggeredCallback);
            PlayerNotifier.OnPlayerLoaded.RemoveListener(PlayerLoadedCallback);
            
            StateMachine.UnloadScene(GameSceneType.Dungeon);
        }

        private void PlayerLoadedCallback(Events.GameObjectEvent context)
        {
            PlayerObject = context.GameObject;
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

        private void LevelGeneratorStartedCallback(Events.LevelGeneratorEvent context)
        {
            LevelGenerator = context.LevelGenerator;
        }

        #endregion
    }
}