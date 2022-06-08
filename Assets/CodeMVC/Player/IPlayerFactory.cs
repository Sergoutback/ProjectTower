using CodeMVC.Data;
using UnityEngine;

namespace CodeMVC.Player
{
    public interface IPlayerFactory
    {
        PlayerProvider CreatePlayer();
    }
}
