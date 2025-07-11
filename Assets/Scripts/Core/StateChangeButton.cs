using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace SabanMete.Core.GameStates
{
    [RequireComponent(typeof(Button))]
    public class StateChangeButton : MonoBehaviour
    {
        [Inject] private IGameStateManager gameStateManager;

        [SerializeField] private GameState targetState;

        private void Start()
        {
            GetComponent<Button>().onClick.AddListener(() =>
            {
                gameStateManager.ChangeState(targetState);
                Debug.Log(targetState.ToString());
            });
        }
    }
}