using System;

namespace BaseBall
{
    internal class Pitcher
    {
        public Pitcher(Ball ball) => ball.BallInPlay += BallInPlayEventHandler;

        private int pitchNumber = 0;
        private void BallInPlayEventHandler(object sender, EventArgs e)
        {
            pitchNumber++;
            if (e is BallEventArgs ballEventArgs)
            {
                if (ballEventArgs.Distance < 95 && ballEventArgs.Angle < 60)
                    Console.WriteLine($"Pitch #{pitchNumber}: I caught the ball");
                else
                    Console.WriteLine($"Pitch #{pitchNumber}: I covered first base");
            }
        }
    }
}
