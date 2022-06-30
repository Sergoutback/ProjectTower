using System;

namespace CodeMVC.Enemy
{
    public interface IEnemy : IMove
    {
        event Action<int> OnTriggerEnterChange;
    }
}
