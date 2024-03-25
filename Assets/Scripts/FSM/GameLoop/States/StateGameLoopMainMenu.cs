using FSM.GameLoop.Enums;
using FSM.GameLoop.Interfaces;
using UI.Presenters;
using UI.Views;

namespace FSM.GameLoop.States
{
    public class StateGameLoopMainMenu : StateGameLoop
    {
        #region Constructors
        
        public StateGameLoopMainMenu(IStateMachineGameLoop stateMachineGameLoop) : base(stateMachineGameLoop)
        {
        }

        #endregion

        #region Methods

        public override void Enter()
        {
            MainMenu.OnDungeonRunStarted.AddListener(DungeonRunStartedCallback);
            MainMenu.OnGameExited.AddListener(GameExitedCallback);
            
            StateMachine.LoadScene(GameSceneType.MainMenu);
        }

        public override void Exit()
        {
            MainMenu.OnDungeonRunStarted.RemoveListener(DungeonRunStartedCallback);
            MainMenu.OnGameExited.RemoveListener(GameExitedCallback);
            
            StateMachine.UnloadScene(GameSceneType.MainMenu);
        }

        private void DungeonRunStartedCallback()
        {
            StateMachine.ToDungeonState();
        }

        private void GameExitedCallback()
        {
            StateMachine.ExitGame();
        }

        #endregion
    }
}