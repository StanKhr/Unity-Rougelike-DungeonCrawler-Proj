using FSM.Creatures.Machines;
using NPCs.Components.Interfaces;
using NPCs.Components.Navigation;
using NPCs.FSM.Interfaces;
using NPCs.FSM.States;
using UnityEngine;

namespace NPCs.FSM.Machines
{
    public class StateMachineEnemy : StateMachineHumanoid, IStateMachineEnemy
    {
        #region Editor Fields

        [SerializeField] private NavMeshAgentWrapper _navMeshAgentWrapper;
        [SerializeField] private PlayerFinder _playerFinder;

        #endregion

        #region Properties

        public INavMeshAgentWrapper NavMeshAgentWrapper => _navMeshAgentWrapper;
        public IPlayerFinder PlayerFinder => _playerFinder;

        #endregion

        #region Unity Callbacks

        protected override void Start()
        {
            base.Start();
            NavMeshAgentWrapper.SetPositionRotationUpdate(false);
            
            ToFreeLookState();
        }

        #endregion
        
        #region Methods

        public override void ToFreeLookState()
        {
            SwitchState(new StateEnemyFreeLook(this));
        }

        public override void ToDeathState()
        {
            
        }

        #endregion

    }
}