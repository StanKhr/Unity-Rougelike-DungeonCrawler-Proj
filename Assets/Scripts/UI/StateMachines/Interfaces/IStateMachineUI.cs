using Player.Inputs.Interfaces;
using UI.Presenters.Items;

namespace UI.StateMachines.Interfaces
{
    public interface IStateMachineUI
    {
        #region Properties

        IInputProvider InputProvider { get; }
        InventoryPresenter InventoryPresenter { get; }

        #endregion
        
        #region Methods

        void ToGameplayState();
        void ToInventoryState();

        #endregion
    }
}