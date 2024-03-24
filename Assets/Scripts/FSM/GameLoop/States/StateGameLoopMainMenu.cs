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
            MainMenuPresenter.OnDungeonRunStarted.AddListener(DungeonRunStartedCallback);
            MainMenuPresenter.OnGameExited.AddListener(GameExitedCallback);
            
            StateMachine.LoadScene(GameSceneType.MainMenu);
        }

        public override void Exit()
        {
            MainMenuPresenter.OnDungeonRunStarted.RemoveListener(DungeonRunStartedCallback);
            MainMenuPresenter.OnGameExited.RemoveListener(GameExitedCallback);
            
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