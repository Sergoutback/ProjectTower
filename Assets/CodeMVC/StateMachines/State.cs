using CodeMVC.Controller;
using CodeMVC.Interface;

namespace CodeMVC.StateMachines
{
    public abstract class State
    {
        protected IUserInputProxy _horizontalInputProxy;
        protected IUserInputProxy _verticalInputProxy;
        protected PlayerController _player;
        protected StateMachine _stateMachine;

        protected State(PlayerController player, StateMachine stateMachine, (IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) input)
        {
            _horizontalInputProxy = input.inputHorizontal;
            _verticalInputProxy = input.inputVertical;
            _player = player;
            _stateMachine = stateMachine;
        }

        public virtual void Enter()
        {
        }

        public virtual void HandleInput()
        {
        }

        public virtual void LogicUpdate()
        {
        }

        public virtual void PhysicsUpdate()
        {
        }

        public virtual void Exit()
        {
        }
    }
}