using Cysharp.Threading.Tasks;
using SabanMete.Core.UI;
using SabanMete.Core.Utils;
using UnityEngine;
using Zenject;

namespace SabanMete.Core.GameStates
{
    public class GameStateManager : IGameStateManager
    {
        private readonly ISceneLoader sceneLoader;
        public GameState Current { get; private set; }

        private readonly LazyInject<ILoadingScreenService> loadingScreenService;

        public GameStateManager(ISceneLoader sceneLoader, LazyInject<ILoadingScreenService> loadingScreenService)
        {
            this.sceneLoader = sceneLoader;
            this.loadingScreenService = loadingScreenService;
        }

        public void SetState(GameState newState)
        {
            if (Current == newState)
                return;

            Current = newState;
            _ = HandleStateAsync(newState);
        }

        private async UniTaskVoid HandleStateAsync(GameState state)
        {
            switch (state)
            {
                case GameState.Boot:
                    // Boot sahnesi zaten açık
                    break;

                case GameState.MainMenu:
                    await sceneLoader.UnloadSceneAsync("GameScene");
                    await sceneLoader.LoadScenesAsync(new[] { "MainScene", "UIScene" });
                    break;

                case GameState.Gameplay:
                    await loadingScreenService.Value.ShowAsync("Loading Game...");
                    await sceneLoader.UnloadSceneAsync("MainScene");
                    await sceneLoader.LoadScenesAsync(new[] { "GameScene" });
                    await loadingScreenService.Value.HideAsync();
                    break;

                case GameState.GameOver:
                    // GameScene açık kalır, UI ile kontrol edilir
                    Debug.Log("Game Over. No scene transition.");
                    break;
            }
        }
    }
}
