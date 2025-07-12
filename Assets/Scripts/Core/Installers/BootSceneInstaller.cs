using SabanMete.Core.GameStates;
using SabanMete.Core.Utils;
using Zenject;

namespace SabanMete.Core.Installers
{
    public class BootSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
            Container.Bind<IGameStateManager>().To<GameStateManager>().AsSingle();
            Container.BindInterfacesTo<BootManager>().AsSingle();
        }
    }
}