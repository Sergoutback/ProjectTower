using CodeMVC.Interface;
using UnityEngine;

namespace CodeMVC.Controller
{
    internal sealed class CameraController : ILateExecute
    {
        private readonly GameObject _player;
        private readonly Transform _mainCamera;
        private readonly Vector3 _offset;

        public CameraController(GameObject player, Transform mainCamera)
        {
            _player = player;
            _mainCamera = mainCamera;
            _offset = _mainCamera.position - _player.transform.position;
        }

        public void LateExecute(float deltaTime)
        {
            _mainCamera.position = _player.transform.position + _offset;
        }
    }
}
