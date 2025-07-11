using UnityEngine;
using Zenject;

namespace SabanMete.DITest
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ILoggerService>().To<DebugLoggerService>().AsSingle();
        }
    }

    public interface ILoggerService
    {
        public void Log(string message);
    }

}