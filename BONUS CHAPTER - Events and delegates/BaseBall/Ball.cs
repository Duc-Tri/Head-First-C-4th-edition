using System;
using System.Security.Cryptography;

namespace BaseBall
{
    internal class Ball
    {
        public event EventHandler<BallEventArgs> BallInPlay;
        protected void OnBallInPlay(BallEventArgs e) => BallInPlay?.Invoke(this, e);

        // The Ball’s new GetNewBat method creates a new Bat object, and it uses the BatCallBack delegate to pass a reference to its own OnBallInPlay method to the new bat.That’s the callback method the bat will use when it hits the ball.
        public Bat GetNewBat() => new Bat(new BatCallback(OnBallInPlay));
        // You’ll set up the callback in the Bat object’s constructor.But in some cases, it makes more sense to set up the callback method using a public method or property’s set accessor.
    }
}