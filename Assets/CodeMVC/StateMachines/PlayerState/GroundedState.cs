using CodeMVC.Controller;
using CodeMVC.Interface;
using UnityEngine;

namespace CodeMVC.StateMachines.PlayerState
{
    public class GroundedState : State
    {
        protected float speed;

        private float _horizontalInput;
        private float _verticalInput;

        public GroundedState(PlayerController player, StateMachine stateMachine, (IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) input) : base(player, stateMachine, input)
        {
        }

        public override void Enter()
        {
            base.Enter();
            _horizontalInput = _verticalInput = 0f;
        }

        public override void Exit()
        {
            base.Exit();
            _player.ResetMoveParams();
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            _player.Move();
        }
    }
}