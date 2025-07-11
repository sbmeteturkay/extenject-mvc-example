using SabanMete.DITest;
using Zenject;

namespace SabanMete.MVC
{
    public class ScoreController : IInitializable
    {
        private readonly ScoreViewModel scoreViewModel;
        private readonly ScoreModel scoreModel;
        private readonly ILoggerService loggerService;

        public ScoreController(ScoreModel scoreModel, ScoreViewModel scoreViewModel, ILoggerService loggerService)
        {
            this.scoreModel = scoreModel;
            this.scoreViewModel = scoreViewModel;
            this.loggerService = loggerService;
        }
        public void Initialize()
        {
            scoreViewModel.AddClickListener(() =>
            {
                scoreModel.IncrementScore(1);
                loggerService.Log("Score added");
            });

            scoreModel.OnScoreChanged += (score) =>
            {
                scoreViewModel.SetScore(score);
            };
            scoreViewModel.SetScore(scoreModel.Score);
        }
    }
}