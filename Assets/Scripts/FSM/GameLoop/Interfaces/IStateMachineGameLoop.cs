using FSM.GameLoop.Enums;

namespace FSM.GameLoop.Interfaces
{
    public interface IStateMachineGameLoop
    {
        #region States
        
        void ToMainMenuState();
        void ToDungeonState();
        void ToDeathState();
        
        #endregion
        
        #region Methods

        void LoadScene(GameSceneType type);
        void UnloadScene(GameSceneType type);
        void ExitGame();

        #endregion
    }
}