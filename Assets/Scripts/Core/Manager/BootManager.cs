using SabanMete.Core.GameStates;
using Zenject;
namespace SabanMete.Core
{
    public class BootManager : IInitializable
    {
        private readonly IGameStateManager gameStateManager;

        public BootManager(IGameStateManager gameStateManager)
        {
            this.gameStateManager = gameStateManager;
        }

        public void Initialize()
        {
            gameStateManager.SetState(GameState.MainMenu);
        }
    }


}