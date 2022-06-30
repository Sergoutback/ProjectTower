using CodeMVC.Controller;
using CodeMVC.Interface;
using UnityEngine;

namespace CodeMVC.StateMachines.PlayerState
{
    public class StandingState : GroundedState
    {
        private bool _jump;
        private bool _crounch;

        private float _horizontal;
        private float _vertical;

        public StandingState(PlayerController player, StateMachine stateMachine,
            (IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) input) : base(player, stateMachine, input)
        {
        }

        public override void Enter()
        {
            Debug.Log("stay");
            base.Enter();
            _horizontalInputProxy.AxisOnChange += HorizontalOnAxisOnChange;
            _verticalInputProxy.AxisOnChange += VerticalOnAxisOnChange;
            
            speed = _player.MovementSpeed;
            _crounch = false;
            _jump = false;
        }

        public override void HandleInput()
        {
            base.HandleInput();
            if (_vertical > 0.7f)
            {
                _jump = true;
            }
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (_jump)
            {
                _stateMachine.ChangeState(_player.jumping);
            }
        }


        private void HorizontalOnAxisOnChange(float value)
        {
            _horizontal = value;
        }

        private void VerticalOnAxisOnChange(float value)
        {
            _vertical = value;
        }
    }
}