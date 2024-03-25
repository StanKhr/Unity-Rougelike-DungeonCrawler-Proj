using Player.Inputs.Interfaces;
using UI.Presenters.Items;
using UI.Views;

namespace UI.StateMachines.Interfaces
{
    public interface IStateMachineUI
    {
        #region Properties

        IInputProvider InputProvider { get; }
        InventoryPresenter InventoryPresenter { get; }
        PauseMenu PauseMenu { get; }

        #endregion
        
        #region Methods

        void ToGameplayState();
        void ToPauseMenuState();
        void ToInventoryState();

        #endregion
    }
}