using UnityEngine;

namespace CodeMVC.Data
{
    [CreateAssetMenu(fileName = "InputSettings", menuName = "Data/InputSettings")]
    public sealed class InputData : ScriptableObject
    {
        [SerializeField] private DynamicJoystick _dynamicJoystick;
        [SerializeField] private Canvas _canvas;
        
        public DynamicJoystick Joystick => _dynamicJoystick;
        public Canvas Parent => _canvas;
    }
}