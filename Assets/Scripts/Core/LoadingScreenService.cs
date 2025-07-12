using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

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
    }
}