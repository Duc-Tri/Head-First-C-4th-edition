using System;

namespace BaseBall
{
    internal class Program
    {
        static readonly Ball ball = new Ball();

        // The Fan and Pitcher object constructors chain their event handlers onto the BallInPlay event.
        static readonly Pitcher pitcher = new Pitcher(ball);
        static readonly Fan fan = new Fan(ball);

        // The Main method just has to call the Ball object's OnBallInPlay method.
        // The event takes care of signaling to the Pitcher and Fan that the ball is in play.
        // The Main method doesn't even need to know that's happening
        static void Main(string[] args)
        {
            var running = true;
            while (running)
            {
                Console.Write("Enter a number for the angle (or anything else to quit): ");
                if (int.TryParse(Console.ReadLine(), out int angle))
                {
                    Console.Write("Enter a number for the distance (or anything else to quit): ");
                    if (int.TryParse(Console.ReadLine(), out int distance))
                    {
                        BallEventArgs ballEventArgs = new BallEventArgs(angle, distance);
                        var bat = ball.GetNewBat();
                        bat.HitTheBall(ballEventArgs);
                    }
                    else
                        running = false;
                }
                else
                    running = false;
            }
            Console.WriteLine("Thanks for playing !");
        }
    }
}
