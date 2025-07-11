using Zenject;

namespace SabanMete.DITest
{
    public class HelloContainer: IInitializable
    {
        private readonly ILoggerService logger;

        public HelloContainer(ILoggerService logger)
        {
            this.logger = logger;
            this.logger.Log("Hello world!");
        }

        public void Initialize()
        {
            logger.Log("Hello container created!");
        }
    }
}