using System;
using System.Collections.Generic;

namespace HW_1.Task4
{
    public class AllBallsCondition : BallsPopWinCondition
    {
        public AllBallsCondition(IReadOnlyList<Ball> balls, IBallPopper ballPopper) : base(balls, ballPopper)
        { }

        protected override int BallsToPop => _balls.Count;
        protected override bool IsBallSuitable(Ball ball) => true;
        protected override bool IsLoseCondition(Ball ball) => false;
    }
}