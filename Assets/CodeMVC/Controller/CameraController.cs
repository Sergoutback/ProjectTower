using CodeMVC.Data;
using CodeMVC.Interface;
using UnityEngine;

namespace CodeMVC.Controller
{
    internal sealed class CameraController : ILateExecute
    {
        private readonly PlayerProvider _playerProvider;
        private readonly Transform _mainCamera;
        private readonly Vector3 _offset;

        public CameraController(PlayerProvider playerProvider, Transform mainCamera)
        {
            _playerProvider = playerProvider;
            _mainCamera = mainCamera;
            _offset = _mainCamera.position - _playerProvider.transform.position;
        }

        public void LateExecute(float deltaTime)
        {
            _mainCamera.position = _playerProvider.transform.position + _offset;
        }
    }
}
