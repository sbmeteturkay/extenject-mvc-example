using Zenject;

namespace SabanMete.Core.GameStates
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IGameStateManager>().To<GameStateManager>().AsSingle();
        }
    }
}