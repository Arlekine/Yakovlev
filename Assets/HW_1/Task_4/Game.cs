using System;
using System.Collections.Generic;
using UnityEngine;

namespace HW_1.Task4
{
    public class Game : IDisposable
    {
        private List<Ball> _balls;
        private BallPopper _ballsPopper ;

        private IWinCondition _currentGameWinCondition;

        public Game(List<Ball> balls, BallPopper ballsPopper)
        {
            _balls = balls;
            _ballsPopper = ballsPopper;

            _ballsPopper.Disable();
            foreach (var ball in _balls)
            {
                ball.gameObject.SetActive(false);
            }
        }

        public event Action<bool> GameFinished;

        public List<Ball> Balls => _balls;
        public BallPopper BallsPopper => _ballsPopper;
        public IWinCondition CurrentGameWinCondition => _currentGameWinCondition;

        public void Start(IWinCondition winCondition)
        {
            _currentGameWinCondition = winCondition;

            _ballsPopper.Enable();
            foreach (var ball in _balls)
            {
                ball.gameObject.SetActive(true);
            }

            _currentGameWinCondition.Won += OnWon;
            _currentGameWinCondition.Lost += OnLost;
        }

        private void Finish()
        {
            _ballsPopper.Disable();
            foreach (var ball in _balls)
            {
                ball.gameObject.SetActive(false);
            }
            
            _currentGameWinCondition.Won -= OnWon;
            _currentGameWinCondition.Lost -= OnLost;
        }

        public void Dispose()
        {
            if (_currentGameWinCondition != null)
            {
                _currentGameWinCondition.Won -= OnWon;
                _currentGameWinCondition.Lost -= OnLost;
            }
        }

        private void OnWon()
        {
            Finish();
            GameFinished?.Invoke(true);
        }

        private void OnLost()
        {
            Finish();
            GameFinished?.Invoke(false);
        }
    }
}