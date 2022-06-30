using CodeMVC.Data;
using UnityEngine;

namespace CodeMVC.UserInput
{
    internal sealed class MobileInputFactory : IMobileInputFactory
    {
        private readonly Canvas _canvas;
        private readonly DynamicJoystick _gameObject;

        public MobileInputFactory(InputData data)
        {
            _canvas = data.Parent;
            _gameObject = data.Joystick;
        }

        public DynamicJoystick Create()
        {
            var parent = Object.Instantiate(_canvas);
            
            var joystick = Object.Instantiate(_gameObject);
            joystick.transform.SetParent(parent.transform);

            return joystick;
        }
    }
}
