using System;

namespace HW_1.Task4
{
    public class GameSessionStarter : IDisposable
    {
        private Game _game;

        public GameSessionStarter(Game game)
        {
            _game = game;
            _game.GameFinished += DisposeCondition;
        }

        public void StartGameWithAllBallsToPopCondition()
        {
            _game.Start(new AllBallsCondition(_game.Balls, _game.BallsPopper));
        }

        public void StartGameWithRedPopCondition()
        {
            _game.Start(new OneColorWinCondition(BallType.Red, _game.Balls, _game.BallsPopper));
        }

        public void StartGameWithWhitePopCondition()
        {
            _game.Start(new OneColorWinCondition(BallType.White, _game.Balls, _game.BallsPopper));
        }

        public void StartGameWithGreenPopCondition()
        {
            _game.Start(new OneColorWinCondition(BallType.Green, _game.Balls, _game.BallsPopper));
        }

        public void Dispose()
        {
            if (_game != null)
                _game.GameFinished -= DisposeCondition;
        }

        private void DisposeCondition(bool isWon)
        {
            ((BallsPopWinCondition)_game.CurrentGameWinCondition).Dispose();
        }
    }
}