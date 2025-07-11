using R3;

namespace SabanMete.Core.GameStates
{
    public interface IGameStateManager
    {
        ReactiveProperty<GameState> CurrentState { get; }
        void ChangeState(GameState newState);
    }
    
    
}