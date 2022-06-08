using CodeMVC.Controller;
using CodeMVC.Interface;
using UnityEngine;

namespace CodeMVC.StateMachines.PlayerState
{
    public class JumpingState : State
    {
        private bool _grounded;

        public JumpingState(PlayerController player, StateMachine stateMachine, (IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) input) : base(player, stateMachine, input)
        {
        }

        public override void Enter()
        {
            Debug.Log("jump");
            base.Enter();
            _grounded = false;
            _player.Jump();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (_grounded)
            {
                _stateMachine.ChangeState(_player.standing);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            _grounded = _player.IsGround;
            Debug.Log(_grounded);
        }
    }
}