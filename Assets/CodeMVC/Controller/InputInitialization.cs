using CodeMVC.Interface;
using CodeMVC.UserInput;

namespace CodeMVC.Controller
{
    internal sealed class InputInitialization : IInitialization
    {
        private IMobileInputFactory _joystick;
        
        private IUserInputProxy _InputHorizontal;
        private IUserInputProxy _InputVertical;

        public InputInitialization(IMobileInputFactory joystick)
        {
            _joystick = joystick;
            
            var inputJoystick = _joystick.Create();
            _InputHorizontal = new MobileInputHorizontal(inputJoystick);
            _InputVertical = new MobileInputVertical(inputJoystick);
        }
        
        public void Initialization()
        {
        }

        public (IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) GetInput()
        {
            (IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) result = (_InputHorizontal, _InputVertical);
            return result;
        }
    }
}
