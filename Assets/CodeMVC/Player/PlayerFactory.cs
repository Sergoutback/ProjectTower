using CodeMVC.Data;
using UnityEngine;

namespace CodeMVC.Player
{
    public sealed class PlayerFactory : IPlayerFactory
    {
        private readonly PlayerData _playerData;

        public PlayerFactory(PlayerData playerData)
        {
            _playerData = playerData;
        }

        public PlayerProvider CreatePlayer()
        {
            var playerProvider = _playerData.GetPlayer();
            return Object.Instantiate(playerProvider);
        }
    }
}
