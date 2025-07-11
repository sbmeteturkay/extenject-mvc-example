using R3;
using UnityEngine;

namespace SabanMete.Core.GameStates
{
    public class GameStateManager : IGameStateManager
    {
        public ReactiveProperty<GameState> CurrentState { get; } = new(GameState.Boot);

        public void ChangeState(GameState newState)
        {
            if (CurrentState.Value != newState)
                CurrentState.Value = newState;
        }
        
    }
}