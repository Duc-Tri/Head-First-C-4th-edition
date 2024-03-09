using System;

namespace BaseBall
{
    internal class Ball
    {
        public event EventHandler<BallEventArgs> BallInPlay;
        public void OnBallInPlay(BallEventArgs e) => BallInPlay?.Invoke(this, e);
    }
}