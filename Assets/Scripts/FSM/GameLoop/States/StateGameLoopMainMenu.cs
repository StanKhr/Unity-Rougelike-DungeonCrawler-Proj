using FSM.GameLoop.Enums;
using FSM.GameLoop.Interfaces;
using UI.Presenters;

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
            MainMenuPresenter.OnDungeonRunStarted += DungeonRunStartedCallback;
            MainMenuPresenter.OnGameExited += GameExitedCallback;
            
            StateMachine.LoadScene(GameSceneType.MainMenu);
        }

        public override void Exit()
        {
            MainMenuPresenter.OnDungeonRunStarted -= DungeonRunStartedCallback;
            MainMenuPresenter.OnGameExited -= GameExitedCallback;
            
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