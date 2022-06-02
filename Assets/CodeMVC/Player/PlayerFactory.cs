using CodeMVC.Extension;
using CodeMVC.Model;
using UnityEngine;

namespace CodeMVC.Player
{
    public sealed class PlayerFactory : IPlayerFactory
    {
        private readonly IPlayerModel _playerData;

        public PlayerFactory(IPlayerModel playerData)
        {
            _playerData = playerData;
        }

        public GameObject CreatePlayer()
        {
            return new GameObject(_playerData.Name)
                .AddSprite(_playerData.Sprite)
                .AddPolygonCollider2D()
                .AddRigidbody2D(1);
        }
    }
}
