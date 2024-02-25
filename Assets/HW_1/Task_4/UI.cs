using UnityEngine;
using UnityEngine.UI;

namespace HW_1.Task4
{
    public class UI : MonoBehaviour
    {
        [SerializeField] private GameObject _buttonsParent;
        [SerializeField] private Button _startAllButton;
        [SerializeField] private Button _redButton;
        [SerializeField] private Button _whiteButton;
        [SerializeField] private Button _greenButton;

        private GameSessionStarter _gameSessionStarter;
        private Game _game;

        public void Init(GameSessionStarter gameSessionStarter, Game game)
        {
            _gameSessionStarter = gameSessionStarter;
            _game = game;

            game.GameFinished += OnGameFinished;
        }

        private void OnEnable()
        {
            _startAllButton.onClick.AddListener(() =>
            {
                _buttonsParent.SetActive(false);
                _gameSessionStarter.StartGameWithAllBallsToPopCondition();
            });

            _redButton.onClick.AddListener(() =>
            {
                _buttonsParent.SetActive(false);
                _gameSessionStarter.StartGameWithRedPopCondition();
            });

            _whiteButton.onClick.AddListener(() =>
            {
                _buttonsParent.SetActive(false);
                _gameSessionStarter.StartGameWithWhitePopCondition();
            });

            _greenButton.onClick.AddListener(() =>
            {
                _buttonsParent.SetActive(false);
                _gameSessionStarter.StartGameWithGreenPopCondition();
            });
        }

        private void OnDisable()
        {
            _startAllButton.onClick.RemoveAllListeners();
            _redButton.onClick.RemoveAllListeners();
            _whiteButton.onClick.RemoveAllListeners();
            _greenButton.onClick.RemoveAllListeners();

            _game.GameFinished -= OnGameFinished;
        }

        private void OnGameFinished(bool isWin)
        {
            print(isWin ? "Won!" : "Lost!");
            _buttonsParent.SetActive(true);
        }
    }
}