using UnityEngine;
using Zenject;
using SabanMete.Core.Utils;

namespace SabanMete.Core
{
    public class BootManager : MonoBehaviour
    {
        [Inject] private ISceneLoader sceneLoader;

        private async void Start()
        {
            await sceneLoader.LoadScenesAsync(new[] { "MainScene", "UIScene" });
            await sceneLoader.UnloadSceneAsync("BootScene");
        }
    }
}