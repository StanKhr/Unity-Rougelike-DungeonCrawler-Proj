using UI.StateMachines.Interfaces;
using UI.Utility;
using UnityEngine;

namespace UI.StateMachines.States
{
    public class StateUIPauseMenu : StateUI
    {
        #region Constructors

        public StateUIPauseMenu(IStateMachineUI stateMachineUI) : base(stateMachineUI)
        {
            
        }

        #endregion
        
        #region Constants

        private const float TimeScaleNormal = 1.0f;
        private const float TimeScalePaused = 0.0f;

        #endregion

        #region Methods

        public override void Enter()
        {
            EnableGameplayInputs(false);
            EnableCursor(true);
            SetPauseMenuCallback(ReturnToGame, true);

            Time.timeScale = TimeScalePaused;
            
            var pauseMenu = StateMachineUI.PauseMenu;

            pauseMenu.OnResumed.AddListener(ResumedCallback);
            pauseMenu.OnToMainMenuDirected.AddListener(ToMainMenuDirectedCallback);
            pauseMenu.OnRestarted.AddListener(RestartedCallback);
            
            pauseMenu.gameObject.SetActiveSmart(true);
        }

        public override void Exit()
        {
            EnableGameplayInputs(true);
            EnableCursor(false);
            SetPauseMenuCallback(ReturnToGame, false);

            Time.timeScale = TimeScaleNormal;
            
            var pauseMenu = StateMachineUI.PauseMenu;
            pauseMenu.OnResumed.RemoveListener(ResumedCallback);
            pauseMenu.OnToMainMenuDirected.RemoveListener(ToMainMenuDirectedCallback);
            pauseMenu.OnRestarted.RemoveListener(RestartedCallback);

            pauseMenu.gameObject.SetActiveSmart(false);
        }

        private void ResumedCallback()
        {
            StateMachineUI.ToGameplayState();
        }

        private void ToMainMenuDirectedCallback()
        {
            
        }

        private void RestartedCallback()
        {
            
        }

        private void ReturnToGame()
        {
            StateMachineUI.ToGameplayState();
        }

        #endregion
    }
}