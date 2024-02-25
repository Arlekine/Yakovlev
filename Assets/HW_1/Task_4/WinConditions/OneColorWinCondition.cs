using System.Collections.Generic;
using System.Linq;

namespace HW_1.Task4
{
    public class OneColorWinCondition : BallsPopWinCondition
    {
        private BallType _targetType;
        private int _ballsToPop = -1;
        
        public OneColorWinCondition(BallType targetType, IReadOnlyList<Ball> balls, IBallPopper ballPopper) : base(balls, ballPopper)
        {
            _targetType = targetType;
        }

        protected override int BallsToPop
        {
            get
            {
                if (_ballsToPop == -1)
                {
                    CalculateBallsToPop();
                }

                return _ballsToPop;
            }
        }

        protected override bool IsBallSuitable(Ball ball) => ball.Type == _targetType;
        protected override bool IsLoseCondition(Ball ball) => ball.Type != _targetType;
        private void CalculateBallsToPop() => _ballsToPop = _balls.Count(b => b.Type == _targetType);
    }
}