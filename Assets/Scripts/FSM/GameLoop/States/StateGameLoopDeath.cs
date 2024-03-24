using FSM.GameLoop.Enums;
using FSM.GameLoop.Interfaces;
using UI.Presenters;

namespace FSM.GameLoop.States
{
    public class StateGameLoopDeath : StateGameLoop
    {
        #region Constructors

        public StateGameLoopDeath(IStateMachineGameLoop stateMachineGameLoop) : base(stateMachineGameLoop)
        {
            
        }

        #endregion

        #region Methods

        public override void Enter()
        {
            DeathPresenter.OnNewTryTriggered.AddListener(NewTryTriggeredCallback);
            DeathPresenter.OnToMainMenuLeft.AddListener(ToMainMenuLeftCallback);
            
            StateMachine.LoadScene(GameSceneType.Death);
        }

        public override void Exit()
        {
            DeathPresenter.OnNewTryTriggered.RemoveListener(NewTryTriggeredCallback);
            DeathPresenter.OnToMainMenuLeft.RemoveListener(ToMainMenuLeftCallback);

            StateMachine.LoadScene(GameSceneType.Death);
        }

        private void ToMainMenuLeftCallback()
        {
            StateMachine.ToMainMenuState();
        }

        private void NewTryTriggeredCallback()
        {
            StateMachine.ToDungeonState();
        }

        #endregion
    }
}