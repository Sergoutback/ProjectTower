using UnityEngine;

namespace CodeMVC.StateMachines
{
    public class StateMachine
    {
        public State CurrentState { get; protected set; }

        public void Initialize(State startingState)
        {
            CurrentState = startingState;
            startingState.Enter();
        }

        public void ChangeState(State newState)
        {
            CurrentState.Exit();

            CurrentState = newState;
            CurrentState.Enter();
        }
    }
}