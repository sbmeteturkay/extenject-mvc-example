using UnityEngine;
using Zenject;

namespace SabanMete.Core.UI
{
    public class UISceneInstaller : MonoInstaller
    {
        [SerializeField] private LoadingScreenService loadingScreen;

        public override void InstallBindings()
        {
            Container.Bind<ILoadingScreenService>().To<LoadingScreenService>().FromInstance(loadingScreen).AsSingle();
        }
    }
}