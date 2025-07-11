using SabanMete.MVC;
using Zenject;

namespace SabanMete.DITest
{
    public class SceneInstaller: MonoInstaller
    {
        public ScoreViewModel scoreViewModel;
        public override void InstallBindings()
        {
            Container.Bind<ScoreModel>().AsSingle();
            Container.BindInstance(scoreViewModel).AsSingle();
            Container.BindInterfacesAndSelfTo<ScoreController>().AsSingle();
        }
    }
}