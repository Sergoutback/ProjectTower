using System;
using UnityEngine;

namespace CodeMVC.Data
{
    [CreateAssetMenu(fileName = "UnitSettings", menuName = "Data/Unit/UnitSettings")]
    public sealed class PlayerData : ScriptableObject
    {
        public PlayerProvider Prefab;

        public PlayerProvider GetPlayer()
        {
            var playerInfo = Prefab;
            if (playerInfo == null)
            {
                throw new InvalidOperationException($"Player not found");
            }

            return playerInfo;
        }
    }
}