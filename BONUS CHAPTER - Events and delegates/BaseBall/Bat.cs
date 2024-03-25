namespace BaseBall
{
    // The Bat object’s callback will point to a Ball object’s OnBallInPlay method, so the callback’s delegate needs to match the signature of OnBallInPlay() — so it needs to take a BallEventArgs parameter and have a void return value.
    delegate void BatCallback(BallEventArgs e);

    internal class Bat
    {
        private BatCallback hitBallCallback;

        public Bat(BatCallback callbackDelegate) => hitBallCallback = callbackDelegate;

        // The point of the callback is that the object doing the calling is in control of who’s listening.In an event, other objects demand to be notified by adding event handlers.In a callback, other objects simply turn over their delegates and politely ask to be notified.
        public void HitTheBall(BallEventArgs e) => hitBallCallback?.Invoke(e);

    }

}
