using System;
using System.Collections.Generic;
using UnityEngine;

namespace HW_1.Task4
{
    public class CompositeRoot : MonoBehaviour
    {
        [SerializeField] private List<Ball> _balls = new List<Ball>();
        [SerializeField] private BallPopper _ballsPopper = new BallPopper();

        [Space]
        [SerializeField] private UI _ui;

        private List<IDisposable> _disposables = new List<IDisposable>();

        private Game _game;
        private GameSessionStarter _gameSessionStarter;

        private void Start()
        {
            _game = new Game(_balls, _ballsPopper);
            _gameSessionStarter = new GameSessionStarter(_game);

            _ui.Init(_gameSessionStarter, _game);

            _disposables.Add(_game);
            _disposables.Add(_gameSessionStarter);
        }

        private void OnDestroy()
        {
            foreach (var disposable in _disposables)
            {
                disposable.Dispose();
            }
        }
    }
}