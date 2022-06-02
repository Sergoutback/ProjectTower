using CodeMVC.Interface;
using CodeMVC.Model;
using UnityEngine;

namespace CodeMVC.Controller
{
    public sealed class MoveController : IExecute, ICleanup
    {
        private readonly GameObject _unit;
        private readonly IPlayerModel _unitData;
        private float _horizontal;
        private float _vertical;
        private Vector3 _move;
        private Rigidbody2D _rigidbody2D;
        
        private IUserInputProxy _horizontalInputProxy;
        private IUserInputProxy _verticalInputProxy;

        public MoveController((IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) input,
            GameObject unit, IPlayerModel unitData)
        {
            _unit = unit;
            _unitData = unitData;
            _horizontalInputProxy = input.inputHorizontal;
            _verticalInputProxy = input.inputVertical;
            _horizontalInputProxy.AxisOnChange += HorizontalOnAxisOnChange;
            _verticalInputProxy.AxisOnChange += VerticalOnAxisOnChange;

            _rigidbody2D = _unit.GetComponent<Rigidbody2D>();
        }

        private void VerticalOnAxisOnChange(float value)
        {
            _vertical = value;
        }

        private void HorizontalOnAxisOnChange(float value)
        {
            _horizontal = value;
        }

        public void Execute(float deltaTime)
        {
            _rigidbody2D.velocity = new Vector2(Mathf.Round(_horizontal) * _unitData.Speed, _rigidbody2D.velocity.y);
        }

        public void Cleanup()
        {
            _horizontalInputProxy.AxisOnChange -= HorizontalOnAxisOnChange;
            _verticalInputProxy.AxisOnChange -= VerticalOnAxisOnChange;
        }
    }
}
