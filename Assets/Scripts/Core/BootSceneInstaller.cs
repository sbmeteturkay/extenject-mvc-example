using SabanMete.Core.GameStates;
using SabanMete.Core.Utils;
using Zenject;

namespace SabanMete.Core.Installers
{
    public class BootSceneInstaller : MonoInstaller
    {
        [Inject] private IGameStateManager gameStateManager;

        public override void InstallBindings()
        {
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
        }
    }
}