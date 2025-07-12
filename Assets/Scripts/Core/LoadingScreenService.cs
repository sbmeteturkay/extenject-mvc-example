using System;
using Cysharp.Threading.Tasks;
using SabanMete.Core.Utils;
using TMPro;
using UnityEngine;
using Zenject;

namespace SabanMete.Core.UI
{
    public interface ILoadingScreenService
    {
        UniTask ShowAsync(string message = "");
        UniTask HideAsync();
    }
    public class LoadingScreenService : MonoBehaviour, ILoadingScreenService
    {
        [SerializeField] private CanvasGroup rootCanvas;
        [SerializeField] private TextMeshProUGUI messageText;
        
        [Inject]private SignalBus signalBus;

        private void Awake()
        {
            signalBus.Subscribe<GameSceneReadySignal>(OnGameSceneReady);
            signalBus.Subscribe<ShowLoadingScreenSignal>(OnShowLoadingRequested);
            signalBus.Subscribe<HideLoadingScreenSignal>(OnHideLoadingRequested);
        }

        private async void OnShowLoadingRequested()
        {
            await ShowAsync();
        }

        private async void OnHideLoadingRequested()
        {
            await HideAsync();
        }

        private void OnGameSceneReady()
        {
            signalBus.Fire<HideLoadingScreenSignal>();
        }
        public async UniTask ShowAsync(string message = "Loading...")
        {
            if (rootCanvas == null) return;
            messageText.text = message;
            rootCanvas.alpha = 1;
            await UniTask.Yield(); // frame atla
        }

        public async UniTask HideAsync()
        {
            if (rootCanvas == null) return;
            rootCanvas.alpha = 0;
            await UniTask.Yield();
        }
        private void OnDestroy()
        {
            signalBus?.Unsubscribe<GameSceneReadySignal>(OnGameSceneReady);
            signalBus?.Unsubscribe<ShowLoadingScreenSignal>(OnShowLoadingRequested);
            signalBus?.Unsubscribe<HideLoadingScreenSignal>(OnHideLoadingRequested);
        }
    }
}