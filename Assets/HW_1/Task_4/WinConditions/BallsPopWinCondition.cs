using System;
using System.Collections.Generic;

namespace HW_1.Task4
{
    /// <summary>
    /// Делаю отписки в Dispose, а как думаешь лучше это делать?
    /// Еще хотел уточнить про двойные отписки
    /// </summary>
    public abstract class BallsPopWinCondition : IWinCondition, IDisposable
    {
        private IBallPopper _ballPopper;

        private int _poppedBalls;

        protected IReadOnlyList<Ball> _balls;

        public event Action Won;
        public event Action Lost;

        public BallsPopWinCondition(IReadOnlyList<Ball> balls, IBallPopper ballPopper)
        {
            _ballPopper = ballPopper;
            _balls = balls;

            _ballPopper.BallPopped += OnBallPopped;
        }

        public void Dispose()
        {
            _ballPopper.BallPopped -= OnBallPopped;
        }

        protected abstract int BallsToPop { get; }
        protected abstract bool IsBallSuitable(Ball ball);
        protected abstract bool IsLoseCondition(Ball ball);

        private void OnBallPopped(Ball ball)
        {
            if (IsLoseCondition(ball))
            {
                _ballPopper.BallPopped -= OnBallPopped;
                Lost?.Invoke();
            }

            if (IsBallSuitable(ball))
            {
                _poppedBalls++;
                if (_poppedBalls >= BallsToPop)
                {
                    _ballPopper.BallPopped -= OnBallPopped;
                    Won?.Invoke();
                }
            }
        }
    }
}