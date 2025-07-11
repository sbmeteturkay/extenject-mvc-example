using SabanMete.Core.GameStates;
using Zenject;

namespace SabanMete.Core.Installers
{
    public class BootSceneInstaller : MonoInstaller
    {
        [Inject] private IGameStateManager gameStateManager;

        public override void InstallBindings()
        {
            Container.Bind<IGameStateManager>().FromInstance(gameStateManager).AsSingle();
        }
    }
}