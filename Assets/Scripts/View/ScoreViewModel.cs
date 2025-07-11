using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SabanMete.MVC
{
    public class ScoreViewModel: MonoBehaviour
    {
        [SerializeField] private Button incrementButton;
        [SerializeField] private TextMeshProUGUI scoreText;

        public void SetScore(int score)
        {
            scoreText.text = $"Score: {score}";
        }

        public void AddClickListener(System.Action onClick)
        {
            incrementButton.onClick.AddListener(() => onClick?.Invoke());
        }
    }
}