using CodeMVC.Controller;
using CodeMVC.Interface;
using UnityEngine;

namespace CodeMVC.StateMachines.PlayerState
{
    public class JumpingState : State
    {

        public JumpingState(PlayerController player, StateMachine stateMachine, (IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) input) : base(player, stateMachine, input)
        {
        }

        public override void Enter()
        {
            base.Enter();
            Debug.Log("jump");
            _player.Jump();
            _player.IsGround = false;
            Debug.Log(_player.IsGround);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (_player.IsGround)
            {
                _stateMachine.ChangeState(_player.standing);
            }
        }
    }
}