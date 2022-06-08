using CodeMVC.Data;
using CodeMVC.Interface;
using CodeMVC.StateMachines;
using CodeMVC.StateMachines.PlayerState;
using UnityEngine;

namespace CodeMVC.Controller
{
    public sealed class PlayerController: IExecute, ILateExecute, ICleanup
    {
        public float MovementSpeed { get; private set; }
        public bool IsGround { get; set; }
        
        
        private readonly IUserInputProxy _horizontalInputProxy;
        private readonly IUserInputProxy _verticalInputProxy;

        private float _horizontal;
        private float _vertical;

        private readonly PlayerProvider _playerProvider;
        private Rigidbody2D _rigidbody2D;

        public StateMachine movementSM;
        public StandingState standing;
        public JumpingState jumping;


        public PlayerController((IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) input, PlayerProvider playerProvider)
        {
            _verticalInputProxy = input.inputVertical;
            _playerProvider = playerProvider;
            _rigidbody2D = _playerProvider.GetComponent<Rigidbody2D>();

            MovementSpeed = _playerProvider.Speed;
            
            _horizontalInputProxy = input.inputHorizontal;
            _horizontalInputProxy.AxisOnChange += HorizontalOnAxisOnChange;
            _verticalInputProxy.AxisOnChange += VerticalOnAxisOnChange;
            _playerProvider.OnTriggetEnterChange += CheckTriggetOverlap;
            
            movementSM = new StateMachine();
            standing = new StandingState(this, movementSM, (_horizontalInputProxy, _verticalInputProxy));
            jumping = new JumpingState(this, movementSM, (_horizontalInputProxy, _verticalInputProxy));
            movementSM.Initialize(standing);
        }

        public void CheckTriggetOverlap(bool ground)
        {
            IsGround = ground;
        }

        public void Execute(float deltaTime)
        {
            movementSM.CurrentState.HandleInput();
            movementSM.CurrentState.LogicUpdate();
        }

        public void LateExecute(float deltaTime)
        {
            movementSM.CurrentState.PhysicsUpdate();
        }

        public void Cleanup()
        {
            _horizontalInputProxy.AxisOnChange -= HorizontalOnAxisOnChange;
            _verticalInputProxy.AxisOnChange -= VerticalOnAxisOnChange;
            _playerProvider.OnTriggetEnterChange -= CheckTriggetOverlap;
        }

        public void Move()
        {
            _rigidbody2D.velocity = new Vector2(Mathf.Round(_horizontal) * _playerProvider.Speed, _rigidbody2D.velocity.y);
        }

        public void Jump()
        {
            _rigidbody2D.velocity = Vector2.up * _playerProvider.JumpForce;
        }

        public void ResetMoveParams()
        {
            _rigidbody2D.velocity = Vector2.zero;
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