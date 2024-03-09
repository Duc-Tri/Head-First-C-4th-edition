using System;

namespace BaseBall
{
    internal class Fan
    {
        private int pitchNumber = 0;
        public Fan(Ball ball) => ball.BallInPlay += BallInPlayEventHandler;

        private void BallInPlayEventHandler(object sender, System.EventArgs e)
        {
            pitchNumber++;
            if (e is BallEventArgs ballEventArgs)
            {
                // The fan’s BallInPlay event handler looks for any ball that’s high and long.
                if (ballEventArgs.Distance > 400 && ballEventArgs.Angle > 30)
                    Console.WriteLine($"Fan : #{pitchNumber} Homerun ! I'm going for the ball !");
                else
                    Console.WriteLine($"Fan : #{pitchNumber} Not A Homerun !");
            }
        }
    }
}