using CodeMVC.Controller;
using CodeMVC.Interface;

namespace CodeMVC.StateMachines.PlayerState
{
    public class DuckingState : GroundedState
    {
        private bool belowCeiling;
        private bool crouchHeld;

        public DuckingState(PlayerController player, StateMachine stateMachine, (IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) input) : base(player, stateMachine, input)
        {
        }
    }
}