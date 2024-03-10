using FSM.Main;
using Miscellaneous;
using NPCs.FSM.Interfaces;

namespace NPCs.FSM.States
{
    public class StateEnemyFreeLook : StateEnemy
    {
        #region Constructors
        
        public StateEnemyFreeLook(IStateMachineEnemy stateMachineEnemy) : base(stateMachineEnemy)
        {
        }

        #endregion

        #region Fields


        
        #endregion

        #region Methods

        public override void Enter()
        {
            
        }

        public override void Exit()
        {
            
        }

        public override void Tick(float deltaTime)
        {
            var playerFinder = StateMachineEnemy.PlayerFinder;
            playerFinder.Tick(deltaTime);
            
            LogWriter.DevelopmentLog($"Found player? {playerFinder.PlayerFound.ToString()}");
        }

        #endregion
    }
}