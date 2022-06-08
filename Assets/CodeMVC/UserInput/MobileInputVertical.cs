using System;
using CodeMVC.Interface;
using UnityEngine;

namespace CodeMVC.UserInput
{
    internal sealed class MobileInputVertical : IUserInputProxy
    {
        public event Action<float> AxisOnChange = delegate(float f) {  };
        private readonly DynamicJoystick _joustick;

        public MobileInputVertical(DynamicJoystick joystick)
        {
            _joustick = joystick;
        }
        
        public void GetAxis()
        {
            AxisOnChange.Invoke(_joustick.Vertical);
        }
    }
}