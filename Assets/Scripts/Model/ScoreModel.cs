using System;
using UnityEngine;

namespace SabanMete.MVC
{
    public class ScoreModel
    { 
        public int Score { get; private set; }
        public event Action<int> OnScoreChanged;

        public void IncrementScore(int score)
        {
            Score += score;
            OnScoreChanged?.Invoke(Score);
        }
    }
}